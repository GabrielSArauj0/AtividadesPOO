using System;
using System.Text.RegularExpressions;

namespace VacinacaoPOO.Validators
{
    public class CadastroValidator
    {
        public bool VerificarNome(string nome)
        {
            if (!string.IsNullOrWhiteSpace(nome) && nome.Length >= 3)
            {
                return true;
            }
            throw new ArgumentException("Nome inválido. Deve conter pelo menos 3 caracteres.");
        }

        public bool VerificarCpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf) || !Regex.IsMatch(cpf, @"^\d{11}$"))
            {
                throw new ArgumentException("CPF inválido. Deve conter exatamente 11 dígitos.");
            }

            return true;
        }

        public bool VerificarIdade(int idade)
        {
            if (idade >= 0 && idade < 200)
            {
                return true;
            }
            throw new ArgumentException("Idade inválida. Deve ser positiva e menor que 200.");
        }

        public bool VerificarVacinacao(string vacinacao)
        {
            if (vacinacao.ToLower() == "s" || vacinacao.ToLower() == "n")
            {
                return true;
            }
            throw new ArgumentException("Informação de vacinação inválida. Deve ser 's' ou 'n'.");
        }
    }
}