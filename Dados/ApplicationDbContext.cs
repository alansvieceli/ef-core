using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Dados
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    //mapeamento de classes para o Banco de dados
    public DbSet<Categoria> Categorias { get; set; }
  }
}


