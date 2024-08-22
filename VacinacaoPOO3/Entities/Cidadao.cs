using System;

namespace VacinacaoPOO.Entities
{
    public class Cidadao
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }
        public bool Vacinado { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime? Agendamento { get; set; } 
        
        public Cidadao(string nome, string cpf, int idade, bool vacinado)
        {
            Nome = nome;
            Cpf = cpf;
            Idade = idade;
            Vacinado = vacinado;
        }
        public Cidadao(string nome, string cpf, int idade, bool vacinado, string telefone, string email, DateTime? agendamento = null)
        {
            Nome = nome;
            Cpf = cpf;
            Idade = idade;
            Vacinado = vacinado;
            Telefone = telefone;
            Email = email;
            Agendamento = agendamento;
        }
        public void AgendarVacina(DateTime data)
        {
            Agendamento = data;
            Console.WriteLine($"Vacinação agendada para {data.ToShortDateString()}");
        }
    }
}