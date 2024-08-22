using System;

namespace VacinacaoPOO.Entities
{
    public class Funcionario
    {
        public string Nome { get; set; }
        public int Matricula { get; set; }
        public string CNPJ_PrestadoraServico { get; set; }

        public Funcionario(string nome, int matricula, string cnpj)
        {
            Nome = nome;
            Matricula = matricula;
            CNPJ_PrestadoraServico = cnpj;
        }

        public void CadastrarCidadao(Cidadao cidadao, CadastroService cadastroService)
        {
            Console.WriteLine($"Cidadão cadastrado por {Nome}");
            cadastroService.AdicionarCidadao(cidadao, this);
        }

        public void AgendarVacinacao(Cidadao cidadao, CadastroService cadastroService)
        {
            Console.WriteLine($"{Nome} agendou vacinação para o cidadão {cidadao.Nome}");
            cidadao.AgendarVacinacao(this);
        }

        public void Vacinar(Cidadao cidadao, CadastroService cadastroService)
        {
            Console.WriteLine($"{Nome} vacinou o cidadão {cidadao.Nome}");
            cidadao.Vacinar(this);
        }
    }
}