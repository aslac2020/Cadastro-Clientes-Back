using Cadastro_Clientes___Back_end.Data;
using Cadastro_Clientes___Back_end.Models;
using Cadastro_Clientes___Back_end.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cadastro_Clientes___Back_end.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly PessoaDBContext _dbContext;

        public PessoaRepository(PessoaDBContext pessoaDBContext)
        {
            _dbContext = pessoaDBContext;
        }

        public async Task<List<PessoaModel>> GetAllPeoples()
        {
            return await _dbContext.Pessoas.ToListAsync();
        }

        public async Task<PessoaModel> GetPeopleById(int id)
        {
            return await _dbContext.Pessoas.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<PessoaModel> CreatePeople(PessoaModel pessoa)
        {
             await _dbContext.Pessoas.AddAsync(pessoa);
              await _dbContext.SaveChangesAsync();

            return  pessoa;
        }

        public async Task<PessoaModel> UpdatePeople(PessoaModel pessoa, int id)
        {
            PessoaModel pessoaId = await GetPeopleById(id);

            if(pessoaId == null)
            {
                throw new Exception($"Usuario para o ID: {id} não foi encontrado no banco de dados.");
            }

            pessoaId.Nome = pessoa.Nome;
            pessoaId.Sobrenome = pessoa.Sobrenome;
            pessoaId.Nacionalidade = pessoa.Nacionalidade;
            pessoaId.Email = pessoa.Email;
            pessoaId.Cpf = pessoa.Cpf;
            pessoaId.Telefone = pessoa.Telefone;
            pessoaId.Cep = pessoa.Cep;
            pessoaId.Cidade = pessoa.Cidade;
            pessoaId.Estado = pessoa.Estado;
            pessoaId.Logradouro = pessoa.Logradouro;

            _dbContext.Pessoas.Update(pessoaId);
           await _dbContext.SaveChangesAsync();

            return pessoaId;
        }

        public async Task<bool> DeletePeople(int id)
        {

            PessoaModel pessoaId = await GetPeopleById(id);

            if (pessoaId == null)
            {
                throw new Exception($"Usuario para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Pessoas.Remove(pessoaId);
            await _dbContext.SaveChangesAsync();
            return true;
          
        }


       
    }
}
