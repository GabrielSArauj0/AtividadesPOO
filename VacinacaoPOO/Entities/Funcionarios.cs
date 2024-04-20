public class Funcionario {
    public string Nome { get; set; }
    public int Matricula { get; set; }
    public string CNPJ_PrestadoraServico { get; set; }
    
    public string Email { get; set; }
    
    public string Telefone { get; set; }
    
    public string CPF { get; set; }
    
    public int Idade { get; set; }

    public Funcionario(string nome, int matricula, string cnpj, string email, string telefone, string cpf, int idade) {
        Nome = nome;
        Matricula = matricula;
        CNPJ_PrestadoraServico = cnpj;
        Email = email;
        Telefone = telefone;
        CPF = cpf;
        Idade = idade;
    }
    
    public void CadastrarCidadao(Cidadao cidadao, List<Cidadao> listaCidadaos) {
        Console.WriteLine($"Cidadão cadastrado por {Nome}");
        listaCidadaos.Add(cidadao);
    }
}