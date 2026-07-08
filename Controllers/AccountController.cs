using Microsoft.AspNetCore.Mvc;
using PruebaAHVA.Models;

namespace PruebaAHVA.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // TODO: Implement actual login logic against the database
                // For now, simulate a successful login if the fields are not empty
                if (model.Email == "test@test.com" && model.Password == "password123")
                {
                    // Redirect to home on success
                    return RedirectToAction("Index", "Home");
                }
                
                ModelState.AddModelError(string.Empty, "Intento de inicio de sesión no válido.");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
    }
}
