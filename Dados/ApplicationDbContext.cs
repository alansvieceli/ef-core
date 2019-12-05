using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Dados
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      //https://www.entityframeworktutorial.net/efcore/fluent-api-in-entity-framework-core.aspx
      //configurações dos modelos, ao inves de mexer direto na tabela..altera aqui
      //pode ser feito direto na classe tbm, mas o contra é que suja a classe
      modelBuilder.Entity<Produto>().ToTable("Produto");
      modelBuilder.Entity<Produto>().Property(p => p.Nome).HasMaxLength(50);
      //modelBuilder.Entity<Produto>().HasKey(p => p.Nome); //caso não tenha ID, pode setar qume quiser pra PK
    }

    //mapeamento de classes para o Banco de dados
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }
  }
}


