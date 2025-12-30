using FintechApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

public class AuthController : Controller
{
    // Simulación de clientes (por ahora)
    private static List<Cliente> clientes = new List<Cliente>()
    {
        new Cliente
        {
            IdCliente = 1,
            Nombre = "Juan",
            Apellido = "Perez",
            Email = "juan@mail.com",
            Password = "1234"
        }
    };

    // GET: Login
    public IActionResult Login()
    {
        return View();
    }

    // POST: Login
    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        var cliente = clientes.FirstOrDefault(c =>
            c.Email == email && c.Password == password);

        if (cliente != null)
        {
            HttpContext.Session.SetString("Usuario", cliente.Email);
            return RedirectToAction("Index", "Home");
        }

        ViewBag.Error = "Credenciales incorrectas";
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }


    //REGISTRO DE CLIENTES (ASP.NET Core MVC)
    // GET: Acción GET (mostrar formulario)
    public IActionResult Register()
    {
        return View();
    }
    //Acción POST (guardar cliente)
    [HttpPost]
    public IActionResult Register(Cliente nuevoCliente)
    {
        //Validar email duplicado
        if(clientes.Any(c => c.Email == nuevoCliente.Email))
        {
            ViewBag.Error = "El email ya está registrado";
            return View();
        }

        nuevoCliente.IdCliente = clientes.Count + 1;
        clientes.Add(nuevoCliente);

        return RedirectToAction("Login");
    }

}
