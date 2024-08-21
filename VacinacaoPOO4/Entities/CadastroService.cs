using Pessoa;
using System.Collections.Generic;

public class CadastroService
{
    private List<Pessoas> pessoasCadastradas = new List<Pessoas>();
    private List<Funcionario> funcionarios = new List<Funcionario>();

    public void AdicionarPessoa(Pessoas pessoa)
    {
        pessoasCadastradas.Add(pessoa);
    }

    public void AdicionarFuncionario(Funcionario funcionario)
    {
        funcionarios.Add(funcionario);
    }

    public List<Pessoas> ObterPessoasCadastradas()
    {
        return pessoasCadastradas;
    }

    public Pessoas BuscarPessoaPorCpf(string cpf)
    {
        return pessoasCadastradas.Find(p => p.CPF == cpf);
    }

    public Funcionario BuscarFuncionarioPorMatricula(int matricula)
    {
        return funcionarios.Find(f => f.Matricula == matricula);
    }
}