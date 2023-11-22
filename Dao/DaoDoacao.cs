using API_DoeMais.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_DoeMais.Dao
{
    public class DaoDoacao
    {

        string conection = @"Data Source=localhost\MSSQLSERVER01; Initial Catalog=DoeMais; Integrated Security=True;TrustServerCertificate=true;";

        //Server=localhost\MSSQLSERVER01;Database=DoeMais;User Id = sa; Password=teste123;TrustServerCertificate=true

        //BUSCA TODOS AS DOACOES
        public List<Doacao> GetDoacoes()
        {
            List<Doacao> doac = new List<Doacao>();

            using (SqlConnection conn = new SqlConnection(conection))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM DOACAO", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                Doacao doacao = new Doacao();
                                doacao.id = int.Parse(reader["id"].ToString());
                                doacao.titulo = reader["titulo"].ToString();
                                doacao.descricao = reader["descricao"].ToString();
                                doacao.categoria = reader["categoria"].ToString();
                                doacao.endereco = reader["endereco"].ToString();
                                doacao.contato = reader["contato"].ToString();
                                doacao.datPublicacao = reader["datPublicacao"].ToString();
                                byte[] imageBytes = (byte[])reader["imagem"];
                                string imageBlob64 = Convert.ToBase64String(imageBytes);
                                doacao.img = imageBlob64;


                                doac.Add(doacao);
                            }
                        }
                    }

                    conn.Close();
                }
                return doac;
            }
        }

        //BUSCA POR ID
        public Doacao GetDoacaoId(int id)
        {
            Doacao doac = new Doacao();

            using (SqlConnection conn = new SqlConnection(conection))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM DOACAO Where id = {id}", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                Doacao doacao = new Doacao();
                                doacao.id = int.Parse(reader["id"].ToString());
                                doacao.titulo = reader["titulo"].ToString();
                                doacao.descricao = reader["descricao"].ToString();
                                doacao.categoria = reader["categoria"].ToString();
                                doacao.endereco = reader["endereco"].ToString();
                                doacao.contato = reader["contato"].ToString();
                                doacao.datPublicacao = reader["datPublicacao"].ToString();
                                byte[] imageBytes = (byte[])reader["imagem"];
                                string imageBlob64 = Convert.ToBase64String(imageBytes);
                                doacao.img = imageBlob64;

                                doac = doacao;
                            }
                        }
                    }
                }
                conn.Close();
            }

            return doac;
        }

        //ADICIONAR DOACAO
        public async Task<ActionResult<Doacao>> InsertDoacao(Doacao doacao)
        {
            using (SqlConnection conn = new SqlConnection(conection))
            {
                conn.Open();

                string insertQuery = "INSERT INTO Produto (titulo, descricao, categoria, endereco, contato, datPublicacao, imagem) VALUES (@titulo, @descricao, @categoria, @endereco, @contato, @datPublicacao, @imagem)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {

                    cmd.Parameters.AddWithValue("@titulo", doacao.titulo);
                    cmd.Parameters.AddWithValue("@descricao", doacao.descricao);
                    cmd.Parameters.AddWithValue("@categoria", doacao.categoria);
                    cmd.Parameters.AddWithValue("@endereco", doacao.endereco);
                    cmd.Parameters.AddWithValue("@contato", doacao.contato);
                    cmd.Parameters.AddWithValue("@datPublicacao", doacao.datPublicacao);
                    byte[] imageBytes = Convert.FromBase64String(doacao.img);
                    cmd.Parameters.AddWithValue("@imagem", imageBytes);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            return doacao;
        }

        //ATUALIAR DOACAO
        public async Task<ActionResult<Doacao>> UpdateDoacao(Doacao doacao)
        {
            using (SqlConnection conn = new SqlConnection(conection))
            {
                try
                {
                    conn.Open();

                    string updateQuery = "UPDATE Produto SET titulo = @titulo, descricao = @descricao, categoria = @categoria, endereco = @endereco, contato = @contato, datPublicacao = @datPublicacao, imagem = @imagem WHERE id = @id";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", doacao.id);
                        cmd.Parameters.AddWithValue("@titulo", doacao.titulo);
                        cmd.Parameters.AddWithValue("@descricao", doacao.descricao);
                        cmd.Parameters.AddWithValue("@categoria", doacao.categoria);
                        cmd.Parameters.AddWithValue("@endereco", doacao.endereco);
                        cmd.Parameters.AddWithValue("@contato", doacao.contato);
                        cmd.Parameters.AddWithValue("@datPublicacao", doacao.datPublicacao);
                        byte[] imageBytes = Convert.FromBase64String(doacao.img);
                        cmd.Parameters.AddWithValue("@imagem", imageBytes);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
                return doacao;
            }
        }

        public void DeleteDoacao(int doacaoId)
        {
            using (SqlConnection conn = new SqlConnection(conection))
            {
                try
                {
                    conn.Open();

                    string deleteQuery = "DELETE FROM Produto WHERE id = @id";

                    using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", doacaoId);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // MESMO CASO, O QUE COLOCAR AQUI AAAAA
                    Console.WriteLine("Erro ao excluir doação: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
