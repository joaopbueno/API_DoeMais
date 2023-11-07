using API_DoeMais.Dao;
using API_DoeMais.Model;

namespace API_DoeMais.Repositorio
{
    public class ProdutoRepositorio
    {
        private readonly DaoProduto _daoProduto;

        public ProdutoRepositorio()
        {
            _daoProduto = new DaoProduto();
        }

        public List<Produto> GetProdutos()
        {
           return _daoProduto.GetProdutos();
        }

        public Produto GetProdutoId(int id)
        {
            return _daoProduto.GetProdutoId(id);
        }
    }
}
