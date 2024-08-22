using System;
using System.Collections.Generic;
using VacinacaoPOO.Entities;

class Program
{
    static void Main(string[] args)
    {
        List<Cidadao> cidadaosCadastrados = new List<Cidadao>();
        Funcionario funcionario = new Funcionario("Carlos", 1234, "12345678901234", "1234-5678", "carlos@empresa.com");

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Cadastrar novo cidadão");
            Console.WriteLine("2. Consultar cidadãos cadastrados");
            Console.WriteLine("3. Sair");
            Console.Write("Escolha uma opção: ");

            int opcao;
            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
                continue;
            }

            switch (opcao)
            {
                case 1:
                    CadastrarCidadao(cidadaosCadastrados, funcionario);
                    break;
                case 2:
                    ConsultarCidadaos(cidadaosCadastrados);
                    break;
                case 3:
                    Console.WriteLine("Saindo...");
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void CadastrarCidadao(List<Cidadao> listaCidadaos, Funcionario funcionario)
    {
        Console.Write("Digite o nome do cidadão: ");
        string nome = Console.ReadLine();

        Console.Write("Digite o CPF do cidadão: ");
        string cpf = Console.ReadLine();

        Console.Write("Digite a idade do cidadão: ");
        int idade;
        while (!int.TryParse(Console.ReadLine(), out idade) || idade < 0)
        {
            Console.WriteLine("Idade inválida. Digite novamente.");
            Console.Write("Digite a idade do cidadão: ");
        }

        Console.Write("O cidadão foi vacinado? (s/n): ");
        bool vacinado = Console.ReadLine().ToLower() == "s";

        Console.Write("Digite o telefone do cidadão (opcional): ");
        string telefone = Console.ReadLine();

        Console.Write("Digite o e-mail do cidadão (opcional): ");
        string email = Console.ReadLine();

        Cidadao novoCidadao = new Cidadao(nome, cpf, idade, vacinado, telefone, email);
        
        Console.Write("Deseja agendar a vacinação? (s/n): ");
        if (Console.ReadLine().ToLower() == "s")
        {
            Console.Write("Digite a data para a vacinação (dd/MM/yyyy): ");
            DateTime dataVacina;
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataVacina))
            {
                Console.WriteLine("Data inválida. Digite novamente.");
                Console.Write("Digite a data para a vacinação (dd/MM/yyyy): ");
            }
            novoCidadao.AgendarVacina(dataVacina);
        }

        funcionario.CadastrarCidadao(novoCidadao, listaCidadaos);
        Console.WriteLine("Cidadão cadastrado com sucesso!");
    }

    static void ConsultarCidadaos(List<Cidadao> listaCidadaos)
    {
        Console.WriteLine("\nCidadãos cadastrados:");
        foreach (var cidadao in listaCidadaos)
        {
            Console.WriteLine($"Nome: {cidadao.Nome}, CPF: {cidadao.Cpf}, Idade: {cidadao.Idade}, Vacinado: {(cidadao.Vacinado ? "Sim" : "Não")}, Telefone: {cidadao.Telefone}, Email: {cidadao.Email}, Agendamento: {(cidadao.Agendamento.HasValue ? cidadao.Agendamento.Value.ToShortDateString() : "Não agendado")}");
        }
    }
}
