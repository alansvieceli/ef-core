using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Mvc.Controllers
{
  public class CategoriaController : Controller
  {
    [HttpGet]
    public IActionResult Salvar()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Salvar(Categoria categoria)
    {
      return View();
    }

  }
}