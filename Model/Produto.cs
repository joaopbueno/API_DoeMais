namespace API_DoeMais.Model
{
    public class Produto
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }

        public Produto() { }
        public Produto(string nome, string descricao)
        {
            this.nome = nome;
            this.descricao = descricao;
        }
    }
}
