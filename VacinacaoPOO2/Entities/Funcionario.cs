using System;
using System.Collections.Generic;

namespace VacinacaoPOO.Entities
{
    public class Funcionario
    {
        private static int _nextId = 1;
        public static readonly string adminPassword = "admin123";

        public string Nome { get; set; }
        private int _matricula;
        private string _cnpjPrestadoraServico;
        private int _identificador;

        public Funcionario(string nome, int matricula, string cnpj)
        {
            Nome = nome;
            _matricula = matricula;
            _cnpjPrestadoraServico = cnpj;
            _identificador = _nextId++;
        }

        public int Identificador => _identificador;

        public int Matricula
        {
            get => _matricula;
            set
            {
                Console.Write("Digite a senha de administrador para alterar a matrícula: ");
                string senha = Console.ReadLine();
                if (senha == adminPassword)
                {
                    _matricula = value;
                    Console.WriteLine("Matrícula alterada com sucesso.");
                }
                else
                {
                    Console.WriteLine("Senha incorreta. A matrícula não foi alterada.");
                }
            }
        }

        public string CNPJ_PrestadoraServico
        {
            get => _cnpjPrestadoraServico;
            set => _cnpjPrestadoraServico = value;
        }

        public void CadastrarCidadao(Cidadao cidadao, List<Cidadao> listaCidadaos)
        {
            Console.WriteLine($"Cidadão cadastrado por {Nome}");
            listaCidadaos.Add(cidadao);
        }
    }
}