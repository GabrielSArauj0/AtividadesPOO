public interface IValidator
{
    bool ValidarCpf(string cpf);
    void ValidarNome(string nome);
    bool ValidarData(string data, bool isFuturo);
}