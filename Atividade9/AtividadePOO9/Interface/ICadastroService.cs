using System;
using System.Collections.Generic;
using VacinacaoPOO.Entities;

public interface ICadastroService
{
    void AdicionarCidadao(Cidadao cidadao, Funcionario funcionario);
    void AdicionarFuncionario(Funcionario funcionario);
    Cidadao BuscarCidadaoPorCpf(string cpf);
    Funcionario BuscarFuncionarioPorMatricula(int matricula);
    Cidadao BuscarCidadaoPorCpfEDataAgendamento(string cpf, DateTime dataAgendamento);
    List<Cidadao> Cidadaos { get; }
    void VacinarCidadao(Cidadao cidadao);
}