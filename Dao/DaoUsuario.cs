using API.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API.Dao
{
    public class DaoUsuario
    {
        string conection = @"Server=DESKTOP-P314HRH\SQLEXPRESS;Database=DoeMais;User Id=sa; Password=teste123;TrustServerCertificate=true";

        //BUSCA TODOS OS PRODUTOS
        public List<Usuario> GetUsuarios()
        {
            List<Usuario> usu = new List<Usuario>();

            using (SqlConnection conn = new SqlConnection(conection))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Usuario", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                Usuario usuario = new Usuario();
                                usuario.id = int.Parse(reader["id"].ToString());
                                usuario.nome = reader["nome"].ToString();
                                usuario.email = reader["email"].ToString();
                                usu.Add(usuario);
                            }
                        }
                    }
                }
            }

            return usu;
        }
    }
}
