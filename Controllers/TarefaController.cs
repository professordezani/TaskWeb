using Microsoft.AspNetCore.Mvc;
using TaskWeb.Models;
using TaskWeb.Repositories;

namespace TaskWeb.Controllers;

public class TarefaController : Controller
{

    private ITarefaRepository repository;
    private ITagRepository tagRepository;
    private int usuarioId;

    public TarefaController(ITarefaRepository repository, ITagRepository tagRepository)
    {
        this.repository = repository;
        this.tagRepository = tagRepository;
        
    }

    public ActionResult Index()
    {
        var usuarioId = (int)HttpContext.Session.GetInt32("UsuarioId");
        return View(repository.ReadAll(usuarioId));
    }

    [HttpGet]
    public ActionResult Create()
    {
        ViewBag.Tags = tagRepository.Read();
        return View();
    }

    [HttpPost]
    public ActionResult Create(Tarefa model)
    {
        var usuarioId = (int)HttpContext.Session.GetInt32("UsuarioId");
        model.UsuarioId = usuarioId;

        repository.Create(model);
        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
        repository.Delete(id);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public ActionResult Update(int id)
    {
        var Tarefa = repository.Read(id);
        ViewBag.Tags = tagRepository.Read();
        return View(Tarefa);
    }

    [HttpPost]
    public ActionResult Update(int id, Tarefa model)
    {
        model.TarefaId = id;
        repository.Update(model);

        return RedirectToAction("Index");
    }
}