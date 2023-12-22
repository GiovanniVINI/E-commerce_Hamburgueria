using EcommerceCCO2023.Models;
using EcommerceCCO2023.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceCCO2023.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult IndexCli()
        {
            ClienteData data = new ClienteData();
                return View(data.Read());
           
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cliente cli)
        {
            if (cli.Nome != null)
            {
                ClienteData data = new ClienteData();
                data.Create(cli);
            }          

            return RedirectToAction("IndexLogin", "Login");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ClienteData data = new ClienteData();
            return View(data.Read(id));
        }

        [HttpPost]
        public IActionResult Update(int id, Cliente cli)
        {
            cli.IdCliente = id;

            if (cli.Nome == null)
                return View(cli);

            ClienteData data = new ClienteData();
                data.Update(cli);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int id)
        {
            ClienteData data = new ClienteData();
                data.Delete(id);

            return RedirectToAction("Index", "Home");
        }
    }
}
