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
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usu)
        {
            return await _daoUsuario.InsertUsuario(usu);
        }

        private bool Ok(object v)
        {
            throw new NotImplementedException();
        }

        public void UpdateUsuario(Usuario usu)
        {
            _daoUsuario.UpdateUsuario(usu);
        }

        public void DeleteUsuario(int id)
        {
            _daoUsuario.DeleteUsuario(id);
        }


    }
}
