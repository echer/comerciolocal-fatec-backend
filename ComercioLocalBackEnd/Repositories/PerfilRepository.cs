using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ComercioLocalBackEnd.Models;

namespace ComercioLocalBackEnd.Repositories
{

  public interface IPerfilRepository
  {
    Perfil FindByuser(Guid idUser);
    void Create(Perfil e);
    void UpdateByUser(Guid idUser, Perfil e);
    void DeleteByUser(Guid idUser);
  }
  public class PerfilRepository : IPerfilRepository
  {
    private readonly DataContext _context;

    public PerfilRepository(DataContext context) 
    {
      _context = context;
    }

    public void Create(Perfil e)
    {
      e.Id = Guid.NewGuid();
      _context.Perfis.Add(e);
      _context.SaveChanges();
    }

    public void DeleteByUser(Guid idUser)
    {
      var obj = FindByuser(idUser);
      _context.Entry(obj).State = EntityState.Deleted;
      _context.SaveChanges();
    }

    public Perfil FindByuser(Guid idUser)
    {
      var perfil = _context.Perfis.Where(p => p.Usuario.Id == idUser).SingleOrDefault();
      if(perfil != null)
        _context.Entry(perfil).Reference(p => p.Usuario).Load();
      return perfil;
    }

    public void UpdateByUser(Guid idUser, Perfil e)
    {
      var _perfil = FindByuser(idUser);

      _perfil.Descricao = e.Descricao;
      _perfil.Fantasia = e.Fantasia;
      _perfil.Razao = e.Razao;
      _perfil.Site = e.Site;
      _perfil.CNPJ = e.CNPJ;
      _perfil.CEP = e.CEP;
      _perfil.Logradouro = e.Logradouro;
      _perfil.Endereco = e.Endereco;
      _perfil.DataAbertura = e.DataAbertura;
      _perfil.Complemento = e.Complemento;
      _perfil.UF = e.UF;
      _perfil.Pais = e.Pais;
      _context.Entry(_perfil).State = EntityState.Modified;
      _context.SaveChanges();
    }
  }
}