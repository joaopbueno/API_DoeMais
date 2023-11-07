using API.Model;
using API.Repositorio;
using API_DoeMais.Model;
using API_DoeMais.Repositorio;
using Microsoft.AspNetCore.Mvc;

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
    }
}
