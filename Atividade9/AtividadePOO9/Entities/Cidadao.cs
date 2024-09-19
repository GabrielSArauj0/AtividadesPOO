using System;
using VacinacaoPOO.Entities;

public class Cidadao : IVacinacao
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public int Idade { get; set; }
    public bool Vacinado { get; set; }
    public Funcionario FuncionarioResponsavelAgendamento { get; private set; }
    public Funcionario FuncionarioResponsavelVacinacao { get; private set; }
    public DateTime DataAgendamento { get; private set; }

    public Cidadao(string nome, string cpf, int idade, bool vacinado)
    {
        Nome = nome;
        Cpf = cpf;
        Idade = idade;
        Vacinado = vacinado;
    }

    public void AgendarVacinacao(Funcionario funcionario, string dataAgendamento)
    {
        FuncionarioResponsavelAgendamento = funcionario;
        DataAgendamento = DateTime.Parse(dataAgendamento);
    }

    public void Vacinar(Funcionario funcionario, ICadastroService cadastroService)
    {
        Vacinado = true;
        FuncionarioResponsavelVacinacao = funcionario;
        cadastroService.VacinarCidadao(this);
    }
}