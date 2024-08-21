namespace Pessoa;

public class Pessoas {
    public string Nome { get; set; }
    public string CPF { get; set; }
    public int Idade { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    
    public Pessoas(string nome, string cpf, int idade, string telefone, string email) {
        Nome = nome;
        CPF = cpf;
        Idade = idade;
        Telefone = telefone;
        Email = email;
    }
}