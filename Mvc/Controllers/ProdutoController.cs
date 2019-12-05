using System.Linq;
using System.Threading.Tasks;
using Dados;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mvc.Controllers
{
  public class ProdutoController : Controller
  {

    public readonly ApplicationDbContext _contexto;

    public ProdutoController(ApplicationDbContext contexto)
    {
      _contexto = contexto;
    }

    [HttpGet]
    public IActionResult Index()
    {
      //var produtos = _contexto.Produtos.Include(p => p.Categoria).ToList();
      var produtos = _contexto.Produtos.ToList();
      return View(produtos);
    }

    [HttpGet]
    public IActionResult Salvar()
    {      
      ViewBag.Categorias = _contexto.Categorias.ToList();
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Salvar(Produto produto) //assincrono (systema nao vai travar..vai ir atendendo outras requisições)
    {

      //*** Pra nao precisar fazer essa requisição, foi incluindo um campo CategoriaId no Dominio do Produto ***
      //var prodNew = _contexto.Categorias.First(c => c.Id == produto.Id);
      //produto.Categoria = prodNew;

      if (produto.Id == 0)
        _contexto.Produtos.Add(produto);
      else {
        var prodNew = _contexto.Produtos.First(c => c.Id == produto.Id);
        prodNew.Nome = produto.Nome;
        prodNew.CategoriaId = produto.CategoriaId;
        //prodNew.Categoria = produto.Categoria;
      }

      await _contexto.SaveChangesAsync(); //commit; await espera terminar
      return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Editar(int id)
    {
      ViewBag.Categorias = _contexto.Categorias.ToList();
      var produto = _contexto.Produtos.First(c => c.Id == id);
      return View("Salvar", produto);
    }

    [HttpGet]
    public async Task<IActionResult> Excluir(int id)
    {
      var produto = _contexto.Produtos.First(c => c.Id == id);
      _contexto.Produtos.Remove(produto);
      await _contexto.SaveChangesAsync(); //commit; await espera terminar
      return RedirectToAction("Index");
    }

  }
}