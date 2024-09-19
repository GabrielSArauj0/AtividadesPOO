using System;
using System.Collections.Generic;
using VacinacaoPOO.Entities;

class Program
{
    static void Main(string[] args)
    {
        ICadastroService cadastroService = new CadastroService();
        IValidator validator = new CadastroValidator();

        Funcionario funcionario = new Funcionario("João", 123, "12345678000199");
        cadastroService.AdicionarFuncionario(funcionario);
        Console.Clear();
        
        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Cadastrar novo cidadão");
            Console.WriteLine("2. Consultar cidadãos cadastrados");
            Console.WriteLine("3. Agendar vacinação");
            Console.WriteLine("4. Realizar vacinação");
            Console.WriteLine("5. Sair");
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
                    CadastrarCidadao(cadastroService, funcionario, validator);
                    break;
                case 2:
                    ConsultarCidadãosCadastrados(cadastroService);
                    break;
                case 3:
                    AgendarVacinacao(cadastroService, funcionario);
                    break;
                case 4:
                    RealizarVacinacao(cadastroService, funcionario);
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

    static void CadastrarCidadao(ICadastroService cadastroService, Funcionario funcionario, IValidator validator)
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

        try
        {
            validator.ValidarNome(nome);
            validator.ValidarCpf(cpf);

            Console.Write("Digite a data da última vacinação (dd/MM/yyyy): ");
            string ultimaVacinação = Console.ReadLine();
            
            validator.ValidarData(ultimaVacinação, false);

            Cidadao novoCidadao = new Cidadao(nome, cpf, idade, vacinado);
            funcionario.CadastrarCidadao(novoCidadao, cadastroService);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void AgendarVacinacao(ICadastroService cadastroService, Funcionario funcionario)
    {
        Console.Write("Digite o CPF do cidadão: ");
        string cpf = Console.ReadLine();
        
        Console.Write("Digite a data da vacinação (dd/MM/yyyy): ");
        string dataAgendamento = Console.ReadLine();

        Cidadao cidadao = cadastroService.BuscarCidadaoPorCpfEDataAgendamento(cpf, DateTime.Parse(dataAgendamento));

        if (cidadao != null)
        {
            funcionario.AgendarVacinacao(cidadao, dataAgendamento);
        }
        else
        {
            Console.WriteLine("Cidadão não encontrado ou data inválida.");
        }
    }

    static void RealizarVacinacao(ICadastroService cadastroService, Funcionario funcionario)
    {
        Console.Write("Digite o CPF do cidadão: ");
        string cpf = Console.ReadLine();
        
        Cidadao cidadao = cadastroService.BuscarCidadaoPorCpf(cpf);

        if (cidadao != null)
        {
            funcionario.Vacinar(cidadao, cadastroService);
        }
        else
        {
            Console.WriteLine("Cidadão não encontrado.");
        }
    }

    static void ConsultarCidadãosCadastrados(ICadastroService cadastroService)
    {
        foreach (var cidadao in cadastroService.Cidadaos)
        {
            Console.WriteLine($"Nome: {cidadao.Nome}, CPF: {cidadao.Cpf}, Idade: {cidadao.Idade}, Vacinado: {cidadao.Vacinado}");
        }
    }
}