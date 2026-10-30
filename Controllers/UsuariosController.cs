
using Exo.WebApi.Models;
using Exo.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Exo.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuariosController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // GET: api/usuarios
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_usuarioRepository.Listar());
        }

        // GET: api/usuarios/1
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var usuario = _usuarioRepository.BuscaPorId(id);

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        // POST: api/usuarios
        [HttpPost]
        public IActionResult Cadastrar([FromBody] Usuario usuario)
        {
            _usuarioRepository.Cadastrar(usuario);
            return StatusCode(201);
        }

        // PUT: api/usuarios/1
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] Usuario usuario)
        {
            bool atualizado = _usuarioRepository.Atualizar(id, usuario);

            if (!atualizado)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/usuarios/1
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            bool excluido = _usuarioRepository.Deletar(id);

            if (!excluido)
                return NotFound();

            return NoContent();
        }
    }
}
