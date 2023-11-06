using API_DoeMais.Model;
using Microsoft.Data.SqlClient;
using System.Data;
//using System.Data.SqlClient;
//using System.Reflection.Metadata.Ecma335;

namespace API_DoeMais.Dao
{
    public class DaoProduto
    {

        string conection = @"Server=DESKTOP-P314HRH\SQLEXPRESS;Database=DoeMais;User Id =sa; Password=teste123;";
        //"Data Source=DESKTOP-P314HRH\SQLEXPRESS;Initial Catalog=DoeMais;Integrated Security=True";

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
    }
}
