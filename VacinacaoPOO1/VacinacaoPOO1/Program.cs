﻿using System;
using System.Collections.Generic;
using VacinacaoPOO.Entities;

class Program {
    static void Main(string[] args) {
       
        List<Cidadao> cidadaosCadastrados = new List<Cidadao>();

        while (true) {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Cadastrar novo cidadão");
            Console.WriteLine("2. Consultar cidadãos cadastrados");
            Console.WriteLine("3. Sair");
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

        Console.Write("O cidadão foi vacinado? (s/n): ");
        bool vacinado = Console.ReadLine().ToLower() == "s";

        Cidadao novoCidadao = new Cidadao(nome, cpf, idade, vacinado);
        listaCidadaos.Add(novoCidadao);

        Console.WriteLine("Cidadão cadastrado com sucesso!");
    }
   
    static void ConsultarCidadaos(List<Cidadao> listaCidadaos) {
        Console.WriteLine("\nCidadãos cadastrados:");
        foreach (var cidadao in listaCidadaos) {
            Console.WriteLine($"Nome: {cidadao.Nome}, CPF: {cidadao.Cpf}, Idade: {cidadao.Idade}, Vacinado: {(cidadao.Vacinado ? "Sim" : "Não")}");
        }
    }
}