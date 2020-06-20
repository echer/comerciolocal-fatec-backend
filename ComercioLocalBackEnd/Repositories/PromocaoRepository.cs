using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ComercioLocalBackEnd.Models;

namespace ComercioLocalBackEnd.Repositories
{

  public interface IPromocaoRepository
  {
    List<Promocao> Find(Guid idPerfil);
    List<Promocao> Find();
    void Create(Promocao e);
    void Delete(Guid idPromocao, Guid idPerfil);
  }
  public class PromocaoRepository : IPromocaoRepository
  {
    private readonly DataContext _context;

    public PromocaoRepository(DataContext context) 
    {
      _context = context;
    }

    public void Create(Promocao e)
    {
      e.Id = Guid.NewGuid();
      _context.Promocoes.Add(e);
      _context.SaveChanges();
    }

    public void Delete(Guid idPromocao, Guid idPerfil)
    {
      var obj = Find(idPromocao, idPerfil);
      if(obj != null){
        _context.Entry(obj).State = EntityState.Deleted;
        _context.SaveChanges();
      }
    }

    public List<Promocao> Find(Guid idPerfil)
    {
      return _context.Promocoes.Where(p => p.PerfilId == idPerfil).ToList();
    }

    public List<Promocao> Find()
    {
      var list = _context.Promocoes.ToList();
      foreach (var promo in list) {
          _context.Entry(promo).Reference(p => p.Perfil).Load();
      }
      return list;
    }

    public Promocao Find(Guid idPromocao, Guid idPerfil){
      return _context.Promocoes.Where(p => p.PerfilId == idPerfil && p.Id == idPromocao).SingleOrDefault();
    }
  }
}