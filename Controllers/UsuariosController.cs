using API.DTO;
using API.Model;
using API.Repositorio;
using API_DoeMais.Model;
using API_DoeMais.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Exchange.WebServices.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private UsuarioRepositorio _usuarioRepositorio;
        

        // GET api/produtos
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> GetUsuarios()
        {
            _usuarioRepositorio = new UsuarioRepositorio();
            return _usuarioRepositorio.GetUsuarios();
        }

        [HttpGet("{id}")]
        public Usuario Get(int id)
        {
            _usuarioRepositorio = new UsuarioRepositorio();
            return _usuarioRepositorio.GetUsuarioId(id);
        }


        [HttpPost]
        public async Task<ActionResult<Usuario>> CriarEvento([FromBody] Usuario dtoUsuaro)
        {
            _usuarioRepositorio = new UsuarioRepositorio();

            return Ok(await _usuarioRepositorio.PostUsuario(dtoUsuaro));
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            _usuarioRepositorio = new UsuarioRepositorio();

            _usuarioRepositorio.DeleteUsuario(id);
            return true;
        }
    }
}
