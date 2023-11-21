using API.Model;
using API_DoeMais.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API.Dao
{
    public class DaoUsuario
    {
        string conection = @"Data Source=localhost\MSSQLSERVER01; Initial Catalog=DoeMais; Integrated Security=True;TrustServerCertificate=true;";
        
        
        //BUSCA TODOS USUARIOS DO BANCO
        public List<Usuario> GetUsuarios()
        {
            List<Usuario> usu = new List<Usuario>();

            using (SqlConnection conn = new SqlConnection(conection))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM USUARIOS", conn))
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
                                usuario.senha = reader["senha"].ToString();
                                usuario.cpf = reader["cpf"].ToString();
                                usuario.bairro = reader["bairro"].ToString();
                                usuario.telefone = reader["telefone"].ToString();
                                usuario.tipo_usuario = reader["tipo_usuario"].ToString();

                                usu.Add(usuario);
                            }
                        }
                    }
                }
            }

            return usu;
        }

        //BUSCA USUÁRIO POR ID
        public Usuario GetUsuarioId(int id)
        {
            Usuario usu = new Usuario();

            using (SqlConnection conn = new SqlConnection(conection))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM USUARIOS Where id = {id}", conn))
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
                                usuario.senha = reader["senha"].ToString();
                                usuario.cpf = reader["cpf"].ToString();
                                usuario.bairro = reader["bairro"].ToString();
                                usuario.telefone = reader["telefone"].ToString();
                                usuario.tipo_usuario = reader["tipo_usuario"].ToString();

                                usu = usuario;
                            }
                        }
                    }
                }
                conn.Close();
            }

            return usu;
        }

        //ADICIONAR USUARIO
        public void InsertUsuario(Usuario usuario)
        {
            using (SqlConnection conn = new SqlConnection(conection))
            {
                conn.Open();

                string insertQuery = "INSERT INTO USUARIOS (nome, email, senha, cpf, bairro, telefone, tipo_usuario) " +
                                     "VALUES (@nome, @email, @senha, @cpf, @bairro, @telefone, @tipo_usuario)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", usuario.nome);
                    cmd.Parameters.AddWithValue("@email", usuario.email);
                    cmd.Parameters.AddWithValue("@senha", usuario.senha);
                    cmd.Parameters.AddWithValue("@cpf", usuario.cpf);
                    cmd.Parameters.AddWithValue("@bairro", usuario.bairro);
                    cmd.Parameters.AddWithValue("@telefone", usuario.telefone);
                    cmd.Parameters.AddWithValue("@tipo_usuario", usuario.tipo_usuario);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        //EXCLUIR USUARIO
        public void DeleteUsuario(int id)
        {
            using (SqlConnection conn = new SqlConnection(conection))
            {
                conn.Open();

                string insertQuery = "DELETE FROM USUARIOS WHERE id = @id";

                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }
}
