using API_DoeMais.Model;
using API_DoeMais.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace API_DoeMais.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private ProdutoRepositorio _produtoRepositorio;
        // CONFERIR SE ESTA FUNCIONANDO
        public void ValuesController()
        {
            _produtoRepositorio = new ProdutoRepositorio();
        }
        // GET api/produtos
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> GetProdutos()
        {
            _produtoRepositorio = new ProdutoRepositorio();
            return _produtoRepositorio.GetProdutos();
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "funcionou";
        }


        [HttpPost]
        public ActionResult<string> Post(int id)
        {
            return "funcionou";
        }
    }
}
