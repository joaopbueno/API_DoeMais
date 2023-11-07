using API_DoeMais.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_DoeMais.Dao
{
    public class DaoProduto
    {

        string conection = @"Server=DESKTOP-P314HRH\SQLEXPRESS;Database=DoeMais;User Id=sa; Password=teste123;TrustServerCertificate=true";

        //BUSCA TODOS OS PRODUTOS
        public List<Produto> GetProdutos()
        {
            List<Produto> prod = new List<Produto>();

            using (SqlConnection conn = new SqlConnection(conection))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Produto", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                Produto produto = new Produto();
                                produto.id = int.Parse(reader["id"].ToString());
                                produto.nome = reader["nome"].ToString();
                                produto.descricao = reader["descricao"].ToString();
                                prod.Add(produto);
                            }
                        }
                    }
                }
            }

            return prod;
        }

        //BUSCA POR ID
        public Produto GetProdutoId(int id)
        {
            Produto prod = new Produto();

            using (SqlConnection conn = new SqlConnection(conection))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM Produto Where id = {id}", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            Produto produto = new Produto();
                            produto.id = int.Parse(reader["id"].ToString());
                            produto.nome = reader["nome"].ToString();
                            produto.descricao = reader["descricao"].ToString();
                            prod = produto;

                        }
                    }
                }
            }

            return prod;
        }

        //ADICIONAR PRODUTO
        public void InsertProduto(Produto produto)
        {
            using (SqlConnection conn = new SqlConnection(conection))
            {
                conn.Open();

                string insertQuery = "INSERT INTO Produto (nome, descricao) VALUES (@nome, @descricao)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", produto.nome);
                    cmd.Parameters.AddWithValue("@descricao", produto.descricao);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //ATUALIAR PRODUTO
        public void UpdateProduto(Produto produto)
        {
            using (SqlConnection conn = new SqlConnection(conection))
            {
                conn.Open();

                string insertQuery = "UPDATE Produto SET nome = @nome, descricao = @descricao WHERE id = @id";

                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", produto.nome);
                    cmd.Parameters.AddWithValue("@descricao", produto.descricao);
                    cmd.Parameters.AddWithValue("@id", produto.descricao);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //EXCLUIR PRODUTO
        public void DeleteProduto(Produto produto)
        {
            using (SqlConnection conn = new SqlConnection(conection))
            {
                conn.Open();

                string insertQuery = "DELETE FROM Produto WHERE id = @id";

                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@id", produto.descricao);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
