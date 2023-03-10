using Cadastro_Clientes___Back_end.Models;

namespace Cadastro_Clientes___Back_end.Repositories.Interfaces
{
    public interface IPessoaRepository
    {
        Task<List<PessoaModel>> GetAllPeoples();
        Task<PessoaModel> GetPeopleById(int id);
        Task<PessoaModel> CreatePeople(PessoaModel pessoa);
        Task<PessoaModel> UpdatePeople(PessoaModel pessoa, int id);
        Task<bool> DeletePeople(int id);

        Task<bool> isCpfExists(string cpf);
    }
}
