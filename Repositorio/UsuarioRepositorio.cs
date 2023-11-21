using API.Dao;
using API.Model;
using API_DoeMais.Dao;
using API_DoeMais.Model;

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
        public void PostUsuario(Usuario prod)
        {
            _daoUsuario.InsertUsuario(prod);
        }
        public void DeleteUsuario(int id)
        {
            _daoUsuario.DeleteUsuario(id);
        }
    }
}
