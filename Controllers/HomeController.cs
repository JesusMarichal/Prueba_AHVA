using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaAHVA.Data;
using PruebaAHVA.Models;

namespace PruebaAHVA.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var usuario = await UsuarioActualAsync();

        if (usuario == null)
        {
            return RedirectToAction("Login", "Account");
        }

        return View(usuario);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditarPerfil(PerfilEditViewModel model)
    {
        var usuario = await UsuarioActualAsync();

        if (usuario == null)
        {
            return RedirectToAction("Login", "Account");
        }

        if (ModelState.IsValid)
        {
            usuario.Nombre = model.Nombre;
            usuario.ApellidoPaterno = model.ApellidoPaterno;
            usuario.ApellidoMaterno = model.ApellidoMaterno;
            usuario.TipoDocumento = model.TipoDocumento;
            usuario.NumeroDocumento = model.NumeroDocumento;
            usuario.FechaNacimiento = model.FechaNacimiento;
            usuario.Nacionalidad = model.Nacionalidad;
            usuario.Sexo = model.Sexo;
            usuario.Email = model.Email;
            usuario.CorreoSecundario = model.CorreoSecundario;
            usuario.TelefonoMovil = model.TelefonoMovil;
            usuario.TelefonoSecundario = model.TelefonoSecundario;
            usuario.TipoContratacion = model.TipoContratacion;
            usuario.FechaContratacion = model.FechaContratacion;

            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Index");
    }

    private async Task<Usuario?> UsuarioActualAsync()
    {
        var idClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!int.TryParse(idClaim, out var id))
        {
            return null;
        }

        return await _context.Usuarios.Include(u => u.Rol).FirstOrDefaultAsync(u => u.Id == id);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
