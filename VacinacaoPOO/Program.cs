using System;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        List<Cidadao> cidadaosCadastrados = new List<Cidadao>();

        while (true) {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Cadastrar novo cidadão");
            Console.WriteLine("2. Consultar cidadãos cadastrados");
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
                    CadastrarCidadao(cidadaosCadastrados);
                    break;
                case 2:
                    ConsultarCidadaos(cidadaosCadastrados);
                    break;
                case 3:
                    AgendarVacina(cidadaosCadastrados);
                    break;
                case 4:
                    ConsultarAgendamento(cidadaosCadastrados);
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
    static void CadastrarCidadao(List<Cidadao> listaCidadaos) {
        Console.Write("Digite o nome do cidadão: ");
        string nome = Console.ReadLine();

        Console.Write("Digite o CPF do cidadão: ");
        string cpf = Console.ReadLine();

        Console.Write("Digite a idade do cidadão: ");
        int idade;
        while (!int.TryParse(Console.ReadLine(), out idade) || idade < 0) {
            Console.WriteLine("Idade inválida. Digite novamente.");
            Console.Write("Digite a idade do cidadão: ");
        }

        Console.Write("Digite o telefone do cidadão: ");
        string telefone = Console.ReadLine();

        Console.Write("Digite o email do cidadão: ");
        string email = Console.ReadLine();

        Console.Write("O cidadão foi vacinado? (s/n): ");
        bool vacinado = Console.ReadLine().ToLower() == "s";

        Cidadao novoCidadao = new Cidadao(nome, cpf, idade, telefone, email, vacinado);
        listaCidadaos.Add(novoCidadao);

        if (!vacinado) {
            Console.Write("Deseja agendar a vacinação? (s/n): ");
            if (Console.ReadLine().ToLower() == "s") {
                AgendarVacina(listaCidadaos, novoCidadao);
            }
        }

        Console.WriteLine("Cidadão cadastrado com sucesso!");
    }
    static void ConsultarCidadaos(List<Cidadao> listaCidadaos) {
        Console.WriteLine("\nCidadãos cadastrados:");
        foreach (var cidadao in listaCidadaos) {
            Console.WriteLine($"Nome: {cidadao.Nome}, CPF: {cidadao.Cpf}, Idade: {cidadao.Idade}, Telefone: {cidadao.Telefone}, Email: {cidadao.Email}, Vacinado: {(cidadao.Vacinado ? "Sim" : "Não")}");
        }
    }
    static void AgendarVacina(List<Cidadao> listaCidadaos) {
        Console.WriteLine("\nCidadãos disponíveis para agendamento de vacinação:");
        for (int i = 0; i < listaCidadaos.Count; i++) {
            Console.WriteLine($"{i + 1}. {listaCidadaos[i].Nome}");
        }

        Console.Write("Escolha o número do cidadão para agendar vacinação: ");
        int escolha;
        while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > listaCidadaos.Count) {
            Console.WriteLine("Escolha inválida. Digite novamente.");
            Console.Write("Escolha o número do cidadão para agendar vacinação: ");
        }

        AgendarVacina(listaCidadaos, listaCidadaos[escolha - 1]);
    }
    static void AgendarVacina(List<Cidadao> listaCidadaos, Cidadao cidadao) {
        Console.Write("Digite a data de agendamento (dd/mm/aaaa): ");
        DateTime data;
        while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out data)) {
            Console.WriteLine("Data inválida. Digite novamente no formato dd/mm/aaaa.");
            Console.Write("Digite a data de agendamento (dd/mm/aaaa): ");
        }

        cidadao.AgendarVacina(data);
        Console.WriteLine($"Vacinação agendada para {cidadao.Nome} com sucesso!");
    }
    static void ConsultarAgendamento(List<Cidadao> listaCidadaos) {
        Console.Write("Digite o CPF do cidadão para consultar o agendamento: ");
        string cpf = Console.ReadLine();

        var cidadao = listaCidadaos.Find(c => c.Cpf == cpf);
        if (cidadao != null && cidadao.AgendamentoVacina.HasValue) {
            Console.WriteLine($"O cidadão {cidadao.Nome} está agendado para vacinação em {cidadao.AgendamentoVacina.Value.ToString("dd/MM/yyyy")}.");
        } else {
            Console.WriteLine("Cidadão não encontrado ou não agendado para vacinação.");
        }
    }
}