namespace VacinacaoPOO.Entities;

public class Funcionario {
    public string Nome { get; set; }
    public int Matricula { get; set; }
    public string CNPJ_PrestadoraServico { get; set; }

    public Funcionario(string nome, int matricula, string cnpj) {
        Nome = nome;
        Matricula = matricula;
        CNPJ_PrestadoraServico = cnpj;
    }
    public void CadastrarCidadao(Cidadao cidadao, List<Cidadao> listaCidadaos) {
        Console.WriteLine($"Cidadão cadastrado por {Nome}");
        listaCidadaos.Add(cidadao);
    }
}