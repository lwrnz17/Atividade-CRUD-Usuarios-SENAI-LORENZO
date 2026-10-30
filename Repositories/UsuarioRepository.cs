
using Exo.WebApi.Contexts;
using Exo.WebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace Exo.WebApi.Repositories
{
    public class UsuarioRepository
    {
        private readonly ExoContext _context;

        public UsuarioRepository(ExoContext context)
        {
            _context = context;
        }

        public Usuario? Login(string email, string senha)
        {
            return _context.Usuarios
                .FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public List<Usuario> Listar()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario? BuscaPorId(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public void Cadastrar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public bool Atualizar(int id, Usuario usuario)
        {
            var usuarioBuscado = _context.Usuarios.Find(id);

            if (usuarioBuscado == null)
                return false;

            usuarioBuscado.Email = usuario.Email;
            usuarioBuscado.Senha = usuario.Senha;

            _context.SaveChanges();
            return true;
        }

        public bool Deletar(int id)
        {
            var usuarioBuscado = _context.Usuarios.Find(id);

            if (usuarioBuscado == null)
                return false;

            _context.Usuarios.Remove(usuarioBuscado);
            _context.SaveChanges();
            return true;
        }
    }
}
