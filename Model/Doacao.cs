namespace API_DoeMais.Model
{
    public class Doacao
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public string categoria { get; set; }
        public string endereco { get; set; }
        public string contato { get; set; }
        public string datPublicacao { get; set; }
        public string img { get; set; }



        public Doacao() { }
        public Doacao(int id, string titulo, string descricao, string categoria, string endereco, string contato, string datPublicacao, string img)
        {
            this.id = id;
            this.titulo = titulo;
            this.descricao = descricao;
            this.categoria = categoria;
            this.endereco = endereco;
            this.contato = contato;
            this.datPublicacao = datPublicacao;
            this.img = img;
        }
    }
}
