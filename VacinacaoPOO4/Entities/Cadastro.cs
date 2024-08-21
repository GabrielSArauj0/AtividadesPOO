using System;
using System.Collections.Generic;

namespace Pessoa
{
    public class CadastroService
    {
        private List<Pessoas> listaPessoas;

        public CadastroService()
        {
            listaPessoas = new List<Pessoas>();
        }

        public void AdicionarPessoa(Pessoas pessoa)
        {
            listaPessoas.Add(pessoa);
        }

        public Pessoas BuscarPessoaPorCPF(string cpf)
        {
            return listaPessoas.Find(p => p.CPF == cpf);
        }

        public void AgendarVacinação(Cidadao cidadao, DateTime data, Funcionario funcionario)
        {
            cidadao.AgendarVacina(data);
        }

        public void Vacinar(Cidadao cidadao)
        {
            cidadao.AgendarVacina(cidadao.AgendamentoVacina);
        }

        public void ConsultarPessoasCadastradas()
        {
            Console.WriteLine("\nPessoas cadastradas:");
            foreach (var pessoa in listaPessoas)
            {
                Console.WriteLine($"Nome: {pessoa.Nome}, CPF: {pessoa.CPF}, Idade: {pessoa.Idade}, Telefone: {pessoa.Telefone}, Email: {pessoa.Email}");
            }
        }

        public void ConsultarAgendamento(string cpf)
        {
            var pessoa = BuscarPessoaPorCPF(cpf);
            if (pessoa != null && pessoa is Cidadao cidadao && cidadao.AgendamentoVacina.HasValue)
            {
                Console.WriteLine($"O cidadão {cidadao.Nome} está agendado para vacinação em {cidadao.AgendamentoVacina.Value.ToString("dd/MM/yyyy")}.");
            }
            else
            {
                Console.WriteLine("Pessoa não encontrada ou não agendada para vacinação.");
            }
        }
    }
}