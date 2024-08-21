using Pessoa;

public class Funcionario : Pessoas {
    public int Matricula { get; set; }
    public string CNPJ_PrestadoraServico { get; set; }

    public Funcionario(string nome, int matricula, string cnpj, string email, string telefone, string cpf, int idade)
        : base(nome, cpf, idade, telefone, email) {
        Matricula = matricula;
        CNPJ_PrestadoraServico = cnpj;
    }
}