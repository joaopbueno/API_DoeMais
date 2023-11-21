namespace API.Model
{
    public class Usuario
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string cpf { get; set; }
        public string bairro { get; set; }
        public string telefone { get; set; }
        public string tipo_usuario { get; set; }

        public Usuario() { }
        public Usuario(string nome, string descricao)
        {
            this.nome = nome;
            this.email = descricao;
        }
    }
}
