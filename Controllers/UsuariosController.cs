using API.Model;
using API.Repositorio;
using API_DoeMais.Model;
using API_DoeMais.Repositorio;
using Microsoft.AspNetCore.Mvc;
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


        [HttpPost("/post")]
        public ActionResult<bool> Post([FromBody] JObject jsonData)
        {
            _usuarioRepositorio = new UsuarioRepositorio();



            //Produto prod = new Produto();
            //prod.nome = nome;
            //prod.descricao = descricao;
            //_produtoRepositorio.PostProduto(prod);
            return true;
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
