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
      _contexto.Categorias.Add(categoria);
      await _contexto.SaveChangesAsync(); //commit; await espera terminar
      return RedirectToAction("Index");
    }

  }
}