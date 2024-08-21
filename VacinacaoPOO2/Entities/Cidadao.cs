using System;

namespace VacinacaoPOO.Entities
{
    public class Cidadao
    {
        public string Nome { get; private set; }
        private string _cpf;
        public int Idade { get; private set; }
        public bool Vacinado { get; private set; }

        public Cidadao(string nome, string cpf, int idade, bool vacinado)
        {
            Nome = nome;
            _cpf = cpf;
            Idade = idade;
            Vacinado = vacinado;
        }

        public string Cpf
        {
            get => _cpf;
            set
            {
                if (AuthorizeAdmin())
                {
                    _cpf = value;
                    Console.WriteLine("CPF alterado com sucesso.");
                }
                else
                {
                    Console.WriteLine("Senha incorreta. O CPF não foi alterado.");
                }
            }
        }

        public void AlterarNome(string novoNome)
        {
            if (AuthorizeAdmin())
            {
                Nome = novoNome;
                Console.WriteLine("Nome alterado com sucesso.");
            }
            else
            {
                Console.WriteLine("Senha incorreta. O nome não foi alterado.");
            }
        }

        public void AlterarIdade(int novaIdade)
        {
            if (AuthorizeAdmin())
            {
                Idade = novaIdade;
                Console.WriteLine("Idade alterada com sucesso.");
            }
            else
            {
                Console.WriteLine("Senha incorreta. A idade não foi alterada.");
            }
        }

        public void AlterarVacinado(bool vacinado)
        {
            if (AuthorizeAdmin())
            {
                Vacinado = vacinado;
                Console.WriteLine("Status de vacinação alterado com sucesso.");
            }
            else
            {
                Console.WriteLine("Senha incorreta. O status de vacinação não foi alterado.");
            }
        }

        private bool AuthorizeAdmin()
        {
            Console.Write("Digite a senha de administrador para autorizar a alteração: ");
            string senha = Console.ReadLine();
            return senha == Funcionario.adminPassword;
        }
    }
}