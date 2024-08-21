using System;
using System.Collections.Generic;
using Pessoa;

class Program {
    static void Main(string[] args) {
        List<Pessoas> pessoasCadastradas = new List<Pessoas>();

        while (true) {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Cadastrar novo cidadão");
            Console.WriteLine("2. Consultar pessoas cadastradas");
            Console.WriteLine("3. Agendar vacinação");
            Console.WriteLine("4. Consultar agendamento de vacinação");
            Console.WriteLine("5. Sair");
            Console.Write("Escolha uma opção: ");

            int opcao;
            if (!int.TryParse(Console.ReadLine(), out opcao)) {
                Console.WriteLine("Opção inválida. Tente novamente.");
                continue;
            }

            switch (opcao) {
                case 1:
                    CadastrarPessoa(pessoasCadastradas);
                    break;
                case 2:
                    ConsultarPessoas(pessoasCadastradas);
                    break;
                case 3:
                    AgendarVacina(pessoasCadastradas);
                    break;
                case 4:
                    ConsultarAgendamento(pessoasCadastradas);
                    break;
                case 5:
                    Console.WriteLine("Saindo...");
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
   
    static void CadastrarPessoa(List<Pessoas> listaPessoas) {
        Console.WriteLine("Cadastro de nova pessoa:");
        Console.Write("Digite o nome: ");
        string nome = Console.ReadLine();

        Console.Write("Digite o CPF: ");
        string cpf = Console.ReadLine();

        Console.Write("Digite a idade: ");
        int idade;
        while (!int.TryParse(Console.ReadLine(), out idade) || idade < 0) {
            Console.WriteLine("Idade inválida. Digite novamente.");
            Console.Write("Digite a idade: ");
        }

        Console.Write("Digite o telefone: ");
        string telefone = Console.ReadLine();

        Console.Write("Digite o email: ");
        string email = Console.ReadLine();

        Pessoas novaPessoa = new Pessoas(nome, cpf, idade, telefone, email);
        listaPessoas.Add(novaPessoa);

        Console.WriteLine("Pessoa cadastrada com sucesso!");

        
        if (novaPessoa is Cidadao cidadao && !cidadao.Vacinado) {
            Console.Write("Deseja agendar a vacinação? (s/n): ");
            if (Console.ReadLine().ToLower() == "s") {
                AgendarVacina(listaPessoas, novaPessoa);
            }
        }
    }
   
    static void ConsultarPessoas(List<Pessoas> listaPessoas) {
        Console.WriteLine("\nPessoas cadastradas:");
        foreach (var pessoa in listaPessoas) {
            Console.WriteLine($"Nome: {pessoa.Nome}, CPF: {pessoa.CPF}, Idade: {pessoa.Idade}, Telefone: {pessoa.Telefone}, Email: {pessoa.Email}");
        }
    }

    static void AgendarVacina(List<Pessoas> listaPessoas) {
        Console.WriteLine("\nPessoas disponíveis para agendamento de vacinação:");
        for (int i = 0; i < listaPessoas.Count; i++) {
            Console.WriteLine($"{i + 1}. {listaPessoas[i].Nome}");
        }

        Console.Write("Escolha o número da pessoa para agendar vacinação: ");
        int escolha;
        while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > listaPessoas.Count) {
            Console.WriteLine("Escolha inválida. Digite novamente.");
            Console.Write("Escolha o número da pessoa para agendar vacinação: ");
        }

        AgendarVacina(listaPessoas, listaPessoas[escolha - 1]);
    }

    static void AgendarVacina(List<Pessoas> listaPessoas, Pessoas pessoa) {
        if (pessoa is Cidadao cidadao) {
            Console.Write("Digite a data de agendamento (dd/mm/aaaa): ");
            DateTime data;
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out data)) {
                Console.WriteLine("Data inválida. Digite novamente no formato dd/mm/aaaa.");
                Console.Write("Digite a data de agendamento (dd/mm/aaaa): ");
            }

            cidadao.AgendarVacina(data);
            Console.WriteLine($"Vacinação agendada para {cidadao.Nome} com sucesso!");
        } else {
            Console.WriteLine("Apenas cidadãos podem agendar vacinação.");
        }
    }

    static void ConsultarAgendamento(List<Pessoas> listaPessoas) {
        Console.Write("Digite o CPF da pessoa para consultar o agendamento: ");
        string cpf = Console.ReadLine();

        var pessoa = listaPessoas.Find(p => p.CPF == cpf);
        if (pessoa != null && pessoa is Cidadao cidadao && cidadao.AgendamentoVacina.HasValue) {
            Console.WriteLine($"O cidadão {cidadao.Nome} está agendado para vacinação em {cidadao.AgendamentoVacina.Value.ToString("dd/MM/yyyy")}.");
        } else {
            Console.WriteLine("Pessoa não encontrada ou não agendada para vacinação.");
        }
    }
}