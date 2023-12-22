using EcommerceCCO2023.Models;
using EcommerceCCO2023.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace EcommerceCCO2023.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult IndexLogin(Cliente cliente)
        {
            ClienteData data = new ClienteData();
            Cliente usuario = data.Read(cliente.Email);
            if (usuario != null)
            {
                if (usuario.Senha == cliente.Senha && usuario.Email == cliente.Email)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["Status"] = "Senha Incorreta!";
                    return View("IndexLogin");
                }
            }
            return RedirectToAction("Create", "Cliente");
        }
        public IActionResult IndexLogin()
        {

            return View();
        }
    }
}
