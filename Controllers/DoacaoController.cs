using API.Model;
using API.Repositorio;
using API_DoeMais.Dao;
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
    public class DoacaoController : ControllerBase
    {
        private DoacaoRepositorio _doacaoRepositorio;


        // GET api/produtos
        [HttpGet]
        public ActionResult<IEnumerable<Doacao>> GetUsuarios()
        {
            _doacaoRepositorio = new DoacaoRepositorio();

            return _doacaoRepositorio.GetDoacao();
        }

        [HttpGet("{id}")]
        public Doacao Get(int id)
        {
            _doacaoRepositorio = new DoacaoRepositorio();
            return _doacaoRepositorio.GetDoacaoId(id);
        }


        [HttpPost]
        public async Task<ActionResult<Doacao>> PostUsuario([FromBody] Doacao dtoDoacao)
        {
            _doacaoRepositorio = new DoacaoRepositorio();

            return Ok(await _doacaoRepositorio.PostUsuario(dtoDoacao));
        }

        [HttpPut]
        public async Task<ActionResult<Doacao>> PutUsuario([FromBody] Doacao dtoDoacao)
        {
            _doacaoRepositorio = new DoacaoRepositorio();

            return Ok(await _doacaoRepositorio.UpdateUsuario(dtoDoacao));
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            _doacaoRepositorio = new DoacaoRepositorio();

            _doacaoRepositorio.DeleteUsuario(id);
            return true;
        }
    }
}
