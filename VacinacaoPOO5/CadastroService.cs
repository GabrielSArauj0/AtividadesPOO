using System;
using System.Collections.Generic;
using VacinacaoPOO.Entities;

public class CadastroService
{
    private List<Cidadao> cidadaos;
    private List<Funcionario> funcionarios;

    public CadastroService()
    {
        cidadaos = new List<Cidadao>();
        funcionarios = new List<Funcionario>();
    }

    public void AdicionarCidadao(Cidadao cidadao, Funcionario funcionario)
    {
        cidadaos.Add(cidadao);
        Console.WriteLine($"Cidadão {cidadao.Nome} adicionado pelo funcionário {funcionario.Nome}.");
    }

    public void AdicionarFuncionario(Funcionario funcionario)
    {
        funcionarios.Add(funcionario);
        Console.WriteLine($"Funcionário {funcionario.Nome} adicionado.");
    }

    public Cidadao BuscarCidadaoPorCpf(string cpf)
    {
        return cidadaos.Find(c => c.Cpf == cpf);
    }

    public Funcionario BuscarFuncionarioPorMatricula(int matricula)
    {
        return funcionarios.Find(f => f.Matricula == matricula);
    }
}