using API.Dao;
using API.Model;
using API_DoeMais.Dao;
using API_DoeMais.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Repositorio
{
    public class DoacaoRepositorio
    {
        private readonly DaoDoacao _daoDoacao;

        public DoacaoRepositorio()
        {
            _daoDoacao = new DaoDoacao();
        }

        public List<Doacao> GetDoacao()
        {
            return _daoDoacao.GetDoacoes();
        }

        public Doacao GetDoacaoId(int id)
        {
            return _daoDoacao.GetDoacaoId(id);
        }

        public async Task<ActionResult<Doacao>> PostUsuario(Doacao doacao)
        {
            return await _daoDoacao.InsertDoacao(doacao);
        }

        public async Task<ActionResult<Doacao>> UpdateUsuario(Doacao doacao)
        {
            return await _daoDoacao.UpdateDoacao(doacao);
        }

        public void DeleteUsuario(int id)
        {
            _daoDoacao.DeleteDoacao(id);
        }


    }
}
