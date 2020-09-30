namespace WebService
{
    public class Produtos
    {
        public Produtos()
        {

        }

        public Produtos(int id, string nome, double preco, int estoque, string descricao)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Estoque = estoque;
            Descricao = descricao;
        }

        public int Id { get;  set; }
        public string Nome { get;  set; }
        public double Preco { get;  set; }
        public int Estoque { get;  set; }
        public string Descricao { get;  set; }
    }
}