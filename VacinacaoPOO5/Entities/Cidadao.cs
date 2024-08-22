namespace VacinacaoPOO.Entities
{
    public class Cidadao
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }
        public bool Vacinado { get; set; }
        public Funcionario FuncionarioResponsavelAgendamento { get; private set; }
        public Funcionario FuncionarioResponsavelVacinacao { get; private set; }

        public Cidadao(string nome, string cpf, int idade, bool vacinado)
        {
            Nome = nome;
            Cpf = cpf;
            Idade = idade;
            Vacinado = vacinado;
        }

        public void AgendarVacinacao(Funcionario funcionario)
        {
            FuncionarioResponsavelAgendamento = funcionario;
        }

        public void Vacinar(Funcionario funcionario)
        {
            Vacinado = true;
            FuncionarioResponsavelVacinacao = funcionario;
        }

        public bool Any()
        {
            throw new NotImplementedException();
        }
    }
}