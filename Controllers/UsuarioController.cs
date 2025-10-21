using Microsoft.AspNetCore.Mvc;
using TaskWeb.Models;
using TaskWeb.Repositories;

namespace TaskWeb.Controllers;

public class UsuarioController : Controller
{

    private IUsuarioRepository repository;

    public UsuarioController(IUsuarioRepository repository)
    {
        this.repository = repository;
    }

    public ActionResult Login()
    {
        return View(new LoginViewModel());
    }

    [HttpPost]
    public ActionResult Login(LoginViewModel model)
    {
        Usuario usuario = repository.Login(model);

        if (usuario == null)
        {
            ViewBag.Error = "Usuário ou senha inválidos";
            return View(model);
        }

        HttpContext.Session.SetInt32("UsuarioId", usuario.UsuarioId);
        HttpContext.Session.SetString("Nome", usuario.Nome);

        return RedirectToAction("Index", "Tarefa");
    }

    public ActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}