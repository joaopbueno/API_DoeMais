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

        // GET api/produtos
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> GetProdutos()
        {
            _produtoRepositorio = new ProdutoRepositorio();
            return _produtoRepositorio.GetProdutos();
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> Get(int id)
        {
            _produtoRepositorio = new ProdutoRepositorio();
            return _produtoRepositorio.GetProdutoId(id);
        }


        [HttpPost("{nome}/{descricao}")]
        public ActionResult<bool> Post(string nome, string descricao)
        {
            _produtoRepositorio = new ProdutoRepositorio();

            Produto prod = new Produto();
            prod.nome = nome;
            prod.descricao = descricao;
            _produtoRepositorio.PostProduto(prod);
            return true;
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            _produtoRepositorio = new ProdutoRepositorio();

            _produtoRepositorio.DeleteProduto(id);
            return true;
        }
    }
}
