using System;
using VacinacaoPOO.Entities;

class Program
{
    static void Main(string[] args)
    {
        CadastroService cadastroService = new CadastroService();

        Funcionario funcionario1 = new Funcionario("João", 123, "12345678000199");
        cadastroService.AdicionarFuncionario(funcionario1);

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
                    CadastrarCidadao(cadastroService, funcionario1);
                    break;
                /* Lembrar de tentar tratar isso fazendo uma lista antes de subir e entregar.
                case 2:
                    ConsultarCidadaos(cadastroService);
                    break;
                    */
                case 3:
                    AgendarVacinacao(cadastroService, funcionario1);
                    break;
                case 4:
                    RealizarVacinacao(cadastroService, funcionario1);
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

    static void CadastrarCidadao(CadastroService cadastroService, Funcionario funcionario)
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

        Cidadao novoCidadao = new Cidadao(nome, cpf, idade, vacinado);
        funcionario.CadastrarCidadao(novoCidadao, cadastroService);
    }

  /*
   Lembrar de tentar tratar isso fazendo uma lista antes de subir e entregar.
   
   static void ConsultarCidadaos(CadastroService cadastroService)
    {
        Console.WriteLine("\nCidadãos cadastrados:");
        var cidadaos = cadastroService.BuscarCidadaoPorCpf(null);
        foreach (var cidadao in cidadaos)
        {
            Console.WriteLine($"Nome: {cidadao.Nome}, CPF: {cidadao.Cpf}, Idade: {cidadao.Idade}, Vacinado: {(cidadao.Vacinado ? "Sim" : "Não")}");
        }
    }
*/ 
    static void AgendarVacinacao(CadastroService cadastroService, Funcionario funcionario)
    {
        Console.Write("Digite o CPF do cidadão: ");
        string cpf = Console.ReadLine();
        Cidadao cidadao = cadastroService.BuscarCidadaoPorCpf(cpf);

        if (cidadao != null)
        {
            funcionario.AgendarVacinacao(cidadao, cadastroService);
        }
        else
        {
            Console.WriteLine("Cidadão não encontrado.");
        }
    }

    static void RealizarVacinacao(CadastroService cadastroService, Funcionario funcionario)
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
}