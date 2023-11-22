using API.Dao;
using API.Model;
using API_DoeMais.Dao;
using API_DoeMais.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Repositorio
{
    public class UsuarioRepositorio
    {
        private readonly DaoUsuario _daoUsuario;

        public UsuarioRepositorio()
        {
            _daoUsuario = new DaoUsuario();
        }

        public List<Usuario> GetUsuarios()
        {
            return _daoUsuario.GetUsuarios();
        }

        public Usuario GetUsuarioId(int id)
        {
            return _daoUsuario.GetUsuarioId(id);
        }

        public bool GetUsuarioLogin(string email, string senha)
        {
            return _daoUsuario.GetUsuarioLogin(email, senha);
        }

        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usu)
        {
            return await _daoUsuario.InsertUsuario(usu);
        }


        public async Task<ActionResult<Usuario>> UpdateUsuario(Usuario usu)
        {
           return await _daoUsuario.UpdateUsuario(usu);
        }

        public void DeleteUsuario(int id)
        {
            _daoUsuario.DeleteUsuario(id);
        }


    }
}
