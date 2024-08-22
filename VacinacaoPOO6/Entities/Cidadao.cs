namespace VacinacaoPOO.Entities
{
    public class Cidadao
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }
        public bool Vacinado { get; set; }

        public Cidadao(string nome, string cpf, int idade, bool vacinado)
        {
            Nome = nome;
            Cpf = cpf;
            Idade = idade;
            Vacinado = vacinado;
        }
    }
}