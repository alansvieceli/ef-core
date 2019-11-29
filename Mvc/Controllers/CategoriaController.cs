using System.Linq;
using System.Threading.Tasks;
using Dados;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Mvc.Controllers
{
  public class CategoriaController : Controller
  {
    public readonly ApplicationDbContext _contexto;

    public CategoriaController(ApplicationDbContext contexto)
    {
      _contexto = contexto;
    }   

    [HttpGet]
    public IActionResult Index()
    {
      var categorias = _contexto.Categorias.ToList();
      return View(categorias);
    }

    [HttpGet]
    public IActionResult Salvar()
    {      
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Salvar(Categoria categoria) //assincrono (systema nao vai travar..vai ir atendendo outras requisições)
    {
      if (categoria.Id == 0)
        _contexto.Categorias.Add(categoria);
      else {
        var catNew = _contexto.Categorias.First(c => c.Id == categoria.Id);
        catNew.Nome = categoria.Nome;
      }

      await _contexto.SaveChangesAsync(); //commit; await espera terminar
      return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Editar(int id)
    {
      var categoria = _contexto.Categorias.First(c => c.Id == id);
      return View("Salvar", categoria);
    }

    [HttpGet]
    public async Task<IActionResult> Excluir(int id)
    {
      var categoria = _contexto.Categorias.First(c => c.Id == id);
      _contexto.Categorias.Remove(categoria);
      await _contexto.SaveChangesAsync(); //commit; await espera terminar
      return RedirectToAction("Index");
    }

  }
}