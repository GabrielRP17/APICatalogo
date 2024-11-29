using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Context;

public class AppDbContext : DbContext 
{
    public AppDbContext(DbContextOptions<AppDbContext> options ) : base(options)
    {
    }

    public DbSet<Categoria>? Categorias { get; set; }
    public DbSet<Produto>? Produtos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuração do relacionamento Categoria -> Produto
        modelBuilder.Entity<Produto>()
            .HasOne(p => p.Categoria) // Cada Produto tem uma Categoria
            .WithMany(c => c.Produtos) // Cada Categoria tem muitos Produtos
            .HasForeignKey(p => p.CategoriaId);
    }

}
