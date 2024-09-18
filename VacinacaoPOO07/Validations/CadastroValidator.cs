using System;

public class CadastroValidator
{
    public bool ValidarCpf(string cpf)
    {
        if (!ValidarFormatoCpf(cpf))
        {
            throw new ArgumentException("CPF inválido. O CPF deve conter exatamente 11 dígitos.");
        }
        
        return true;
    }

    private bool ValidarFormatoCpf(string cpf)
    {
        string cpfFormatado = cpf.Replace(".", "").Replace("-", "");
        return cpfFormatado.Length == 11 && char.IsDigit(cpf[0]) && char.IsDigit(cpf[1]);
    }

    public void ValidarNome(string nome)
    {
        if (!string.IsNullOrEmpty(nome))
        {
            foreach (char c in nome)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                {
                    throw new ArgumentException("Nome inválido. O nome pode conter apenas letras e espaços.");
                }
            }
        }
    }

    public bool ValidarData(string data, bool isFuturo)
    {
        DateTime parsedDate;
        while (!DateTime.TryParse(data, out parsedDate))
        {
            Console.WriteLine("Data inválida. Por favor, insira uma data no formato dd/MM/yyyy:");
            data = Console.ReadLine();
        }

        if (isFuturo)
        {
            return parsedDate >= DateTime.Now;
        }
        else
        {
            return parsedDate <= DateTime.Now;
        }
    }
}