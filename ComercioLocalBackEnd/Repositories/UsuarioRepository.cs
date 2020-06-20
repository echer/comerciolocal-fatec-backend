using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ComercioLocalBackEnd.Models;

namespace ComercioLocalBackEnd.Repositories
{

  public interface IUsuarioRepository
  {
    Usuario Read(Guid id);
    Usuario Login(string email, string senha);
    Usuario Create(Usuario e);
    void Update(Guid id, UsuarioUpdate e);
    void Delete(Guid e);
  }
  public class UsuarioRepository : IUsuarioRepository
  {
    private readonly DataContext _context;

    public UsuarioRepository(DataContext context) 
    {
      _context = context;
    }

    public Usuario Create(Usuario e)
    {
      var _usuario = _context.Usuarios.SingleOrDefault(
        obj => obj.Email == e.Email
      );
      if(_usuario == null){
        e.Id = Guid.NewGuid();
        _context.Usuarios.Add(e);
        _context.SaveChanges();
      }
      return e;
    }

    public void Delete(Guid id)
    {
      var obj = _context.Usuarios.Find(id);
      _context.Entry(obj).State = EntityState.Deleted;
      _context.SaveChanges();
    }

    public Usuario Read(Guid id)
    {
      return _context.Usuarios.Find(id);
    }

    public Usuario Login(string email, string senha)
    {
      return _context.Usuarios.SingleOrDefault(
        obj => obj.Email == email && obj.Senha == senha
      );
    }

    public void Update(Guid id, UsuarioUpdate e)
    {
      var _usuario = _context.Usuarios.Find(id);

      _usuario.Nome = e.Nome;
      _usuario.DataNascimento = e.DataNascimento;
      _usuario.TelefoneFixo = e.TelefoneFixo;
      _usuario.TelefoneMovel = e.TelefoneMovel;
      if(e.Senha != null && e.Senha != "")
        _usuario.Senha = e.Senha;
      _context.Entry(_usuario).State = EntityState.Modified;
      _context.SaveChanges();
    }

  }
}