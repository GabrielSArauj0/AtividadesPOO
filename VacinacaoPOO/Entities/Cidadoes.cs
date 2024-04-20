public class Cidadao {
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public int Idade { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public bool Vacinado { get; set; }
    public DateTime? AgendamentoVacina { get; set; }

    public Cidadao(string nome, string cpf, int idade, string telefone, string email, bool vacinado) {
        Nome = nome;
        Cpf = cpf;
        Idade = idade;
        Telefone = telefone;
        Email = email;
        Vacinado = vacinado;
    }
    public void AgendarVacina(DateTime data) {
        AgendamentoVacina = data;
    }
}