using FintechApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

public class CuentaController : Controller
{
    private static List<Cuenta> cuentas = new List<Cuenta>();

    public IActionResult Index()
    {
        var email = HttpContext.Session.GetString("Usuario");
        if (email == null)
        {
            return RedirectToAction("Login", "Auth");
        }

        var cuentasUsuario = cuentas
            .Where(c => c.EmailCliente == email)
            .ToList();

        return View(cuentasUsuario);
    }

    public IActionResult Create()
    {
        if (HttpContext.Session.GetString("Usuario") == null)
        {
            return RedirectToAction("Login", "Auth");
        }

        return View();
    }

    [HttpPost]
    public IActionResult Create(decimal saldoInicial)
    {
        var email = HttpContext.Session.GetString("Usuario");
        if (email == null)
        {
            return RedirectToAction("Login", "Auth");
        }

        var cuenta = new Cuenta(saldoInicial)
        {
            CodigoCuenta = "CTA-" + (cuentas.Count + 1),
            EmailCliente = email
        };

        cuentas.Add(cuenta);

        return RedirectToAction("Index");
    }


    //Agregar Acción para VER movimientos
    public IActionResult Movimientos(string codigoCuenta)
    {
        var email = HttpContext.Session.GetString("Usuario");
        if (email == null)
            return RedirectToAction("Login", "Auth");

        var cuenta = cuentas.FirstOrDefault(c =>
            c.CodigoCuenta == codigoCuenta &&
            c.EmailCliente == email);

        if (cuenta == null)
            return RedirectToAction("Index");

        return View(cuenta);
    }

    //Acción GET – Depositar
    public IActionResult Depositar(string codigoCuenta)
    {
        var email = HttpContext.Session.GetString("Usuario");
        if (email == null)
            return RedirectToAction("Login", "Auth");

        ViewBag.CodigoCuenta = codigoCuenta;
        return View();
    }
    
    //Acción POST – Depositar
    [HttpPost]
    public IActionResult Depositar(string codigoCuenta, decimal monto)
    {
        var email = HttpContext.Session.GetString("Usuario");
        if (email == null)
            return RedirectToAction("Login", "Auth");

        var cuenta = cuentas.First(c =>
            c.CodigoCuenta == codigoCuenta &&
            c.EmailCliente == email);

        cuenta.Depositar(monto);

        return RedirectToAction("Movimientos", new { codigoCuenta });
    }
    
    //Acción GET – Retirar
    public IActionResult Retirar(string codigoCuenta)
    {
        var email = HttpContext.Session.GetString("Usuario");
        if (email == null)
            return RedirectToAction("Login", "Auth");

        ViewBag.CodigoCuenta = codigoCuenta;
        return View();
    }
    
    //Acción POST – Retirar
    [HttpPost]
    public IActionResult Retirar(string codigoCuenta, decimal monto)
    {
        var email = HttpContext.Session.GetString("Usuario");
        if (email == null)
            return RedirectToAction("Login", "Auth");

        var cuenta = cuentas.First(c =>
            c.CodigoCuenta == codigoCuenta &&
            c.EmailCliente == email);

        if (!cuenta.Retirar(monto))
        {
            ViewBag.Error = "Saldo insuficiente o monto inválido";
            ViewBag.CodigoCuenta = codigoCuenta;
            return View();
        }

        return RedirectToAction("Movimientos", new { codigoCuenta });
    }


}
