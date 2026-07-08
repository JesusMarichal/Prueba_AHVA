using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaAHVA.Data;
using PruebaAHVA.Models;

namespace PruebaAHVA.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Welcome()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        private const int MaxIntentosFallidos = 5;
        private static readonly TimeSpan DuracionBloqueo = TimeSpan.FromMinutes(15);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _context.Usuarios
                    .Include(u => u.Rol)
                    .FirstOrDefaultAsync(u => u.NumeroDocumento == model.Usuario);

                if (usuario != null && usuario.BloqueadoHasta.HasValue && usuario.BloqueadoHasta > DateTime.Now)
                {
                    ViewBag.CuentaBloqueada = true;
                    return View(model);
                }

                if (usuario != null && usuario.Password == model.Password)
                {
                    usuario.IntentosFallidos = 0;
                    usuario.BloqueadoHasta = null;
                    await _context.SaveChangesAsync();

                    var claims = new List<Claim>
                    {
                        new(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                        new(ClaimTypes.Email, usuario.Email),
                        new(ClaimTypes.GivenName, usuario.Nombre),
                        new(ClaimTypes.Role, usuario.Rol?.Nombre ?? string.Empty)
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                    return RedirectToAction("Index", "Home");
                }

                if (usuario != null)
                {
                    usuario.IntentosFallidos++;

                    if (usuario.IntentosFallidos >= MaxIntentosFallidos)
                    {
                        usuario.BloqueadoHasta = DateTime.Now.Add(DuracionBloqueo);
                        ViewBag.CuentaBloqueada = true;
                    }

                    await _context.SaveChangesAsync();
                }

                if (ViewBag.CuentaBloqueada != true)
                {
                    ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrectos.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExtendSession()
        {
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, User);
            return Ok();
        }
    }
}
