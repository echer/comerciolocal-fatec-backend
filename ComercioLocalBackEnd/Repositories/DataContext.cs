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

        modelBuilder.Entity<Usuario>().ToTable("Usuario");
        modelBuilder.Entity<Usuario>().Property(e => e.Id);
        modelBuilder.Entity<Usuario>().Property(e => e.Nome).IsRequired();
        modelBuilder.Entity<Usuario>().Property(e => e.DataNascimento);
        modelBuilder.Entity<Usuario>().Property(e => e.Email).IsRequired();
        modelBuilder.Entity<Usuario>().Property(e => e.Senha).IsRequired();
        modelBuilder.Entity<Usuario>().Property(e => e.TelefoneMovel).IsRequired();
        modelBuilder.Entity<Usuario>().Property(e => e.TelefoneFixo);

        modelBuilder.Entity<Perfil>().ToTable("Perfil");
        modelBuilder.Entity<Perfil>().Property(e => e.Id);
        modelBuilder.Entity<Perfil>().Property(e => e.UsuarioId).IsRequired();
        modelBuilder.Entity<Perfil>().Property(e => e.Razao).IsRequired();
        modelBuilder.Entity<Perfil>().Property(e => e.Fantasia).IsRequired();
        modelBuilder.Entity<Perfil>().Property(e => e.DataAbertura).IsRequired(); 
        modelBuilder.Entity<Perfil>().Property(e => e.CNPJ).IsRequired(); 
        modelBuilder.Entity<Perfil>().Property(e => e.Site);
        modelBuilder.Entity<Perfil>().Property(e => e.Descricao).IsRequired();
        modelBuilder.Entity<Perfil>().Property(e => e.CEP).IsRequired();
        modelBuilder.Entity<Perfil>().Property(e => e.Logradouro).IsRequired();
        modelBuilder.Entity<Perfil>().Property(e => e.Numero);
        modelBuilder.Entity<Perfil>().Property(e => e.Complemento);
        modelBuilder.Entity<Perfil>().Property(e => e.UF).IsRequired();
        modelBuilder.Entity<Perfil>().Property(e => e.Pais).IsRequired();
        modelBuilder.Entity<Perfil>().Property(e => e.Segmento).IsRequired();

        modelBuilder.Entity<Promocao>().ToTable("Promocao");
        modelBuilder.Entity<Promocao>().Property(e => e.Id);
        modelBuilder.Entity<Promocao>().Property(e => e.PerfilId).IsRequired();
        modelBuilder.Entity<Promocao>().Property(e => e.DataInicio);
        modelBuilder.Entity<Promocao>().Property(e => e.DataFim);
        modelBuilder.Entity<Promocao>().Property(e => e.Descricao).IsRequired();
        modelBuilder.Entity<Promocao>().Property(e => e.MidiaPromocao);
        modelBuilder.Entity<Promocao>().Property(e => e.CupomPromocao);

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