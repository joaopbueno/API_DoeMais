namespace API.Model
{
    public class Usuario
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }

        public Usuario() { }
        public Usuario(string nome, string descricao)
        {
            this.nome = nome;
            this.email = descricao;
        }
    }
}
