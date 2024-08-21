using Pessoa;

public class Cidadao : Pessoas {
    public bool Vacinado { get; set; }
    public DateTime? AgendamentoVacina { get; set; }

    public Cidadao(string nome, string cpf, int idade, string telefone, string email, bool vacinado)
        : base(nome, cpf, idade, telefone, email) {
        Vacinado = vacinado;
    }

    public void AgendarVacina(DateTime? data) {
        AgendamentoVacina = data;
    }
}