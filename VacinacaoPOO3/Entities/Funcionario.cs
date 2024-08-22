using System;
using System.Collections.Generic;

namespace VacinacaoPOO.Entities
{
    public class Funcionario
    {
        public string Nome { get; set; }
        public int Matricula { get; set; }
        public string CNPJ_PrestadoraServico { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        // Construtor com campos obrigatórios
        public Funcionario(string nome, int matricula, string cnpj)
        {
            Nome = nome;
            Matricula = matricula;
            CNPJ_PrestadoraServico = cnpj;
        }

        // Construtor com todos os campos
        public Funcionario(string nome, int matricula, string cnpj, string telefone, string email)
        {
            Nome = nome;
            Matricula = matricula;
            CNPJ_PrestadoraServico = cnpj;
            Telefone = telefone;
            Email = email;
        }

        public void CadastrarCidadao(Cidadao cidadao, List<Cidadao> listaCidadaos)
        {
            Console.WriteLine($"Cidadão cadastrado por {Nome}");
            listaCidadaos.Add(cidadao);
        }
    }
}