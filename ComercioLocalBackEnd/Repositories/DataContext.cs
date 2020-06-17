using ComercioLocalBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace ComercioLocalBackEnd.Repositories
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options) {
      
     }

    public DbSet<Perfil> Perfis { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Promocao> Promocoes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Perfil>()
            .HasOne(p => p.Usuario)
            .WithOne();
            //.IsRequired();

        modelBuilder.Entity<Promocao>()
            .HasOne(p => p.Perfil)
            .WithOne();

        
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder) 
    //{
      //modelBuilder.Entity<Perfil>().ToTable("Perfis");
      //modelBuilder.Entity<Perfil>().Property(e => e.Id);
      //modelBuilder.Entity<Perfil>().Property(e => e.Nome).IsRequired();
      //modelBuilder.Entity<Perfil>().Property(e => e.CPF).IsRequired();
      //modelBuilder.Entity<Perfil>().Property(e => e.Razao).IsRequired();
      //modelBuilder.Entity<Perfil>().Property(e => e.Fantasia).IsRequired(); 
      //modelBuilder.Entity<Perfil>().Property(e => e.CNPJ).IsRequired(); 
      //modelBuilder.Entity<Perfil>().Property(e => e.Email).IsRequired();
      //modelBuilder.Entity<Perfil>().Property(e => e.Senha).IsRequired();
      //modelBuilder.Entity<Perfil>().Property(e => e.Site);
      //modelBuilder.Entity<Perfil>().Property(e => e.Telefone);
      //modelBuilder.Entity<Perfil>().Property(e => e.Descricao).IsRequired();
    //}
  }
  
}