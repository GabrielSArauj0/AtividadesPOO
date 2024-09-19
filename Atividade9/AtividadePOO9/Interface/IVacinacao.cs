using VacinacaoPOO.Entities;

public interface IVacinacao
{
    void AgendarVacinacao(Funcionario funcionario, string dataAgendamento);
    void Vacinar(Funcionario funcionario, ICadastroService cadastroService);

    string Nome { get; set; }
}