using Cadastro_Clientes___Back_end.Models;
using Cadastro_Clientes___Back_end.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro_Clientes___Back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {

        private readonly IPessoaRepository _pessoaRepository;

        public PessoaController(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }


        [HttpGet]
        public async Task<ActionResult<List<PessoaModel>>> GetAllPeoples()
        {
            List<PessoaModel> pessoas = await _pessoaRepository.GetAllPeoples();
            return Ok(pessoas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PessoaModel>> GetPeopleById(int id)
        {
            PessoaModel pessoa = await _pessoaRepository.GetPeopleById(id);
            return Ok(pessoa);
        }

        [HttpPost]
        public async Task<ActionResult<PessoaModel>> CreatePeople([FromBody] PessoaModel pessoaModel)
        {
            PessoaModel pessoa = await _pessoaRepository.CreatePeople(pessoaModel);
            return Ok(pessoa);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<PessoaModel>> UpdatePeople([FromBody] PessoaModel pessoaModel, int id)
        {
            pessoaModel.Id = id;
            PessoaModel pessoa = await _pessoaRepository.UpdatePeople(pessoaModel, id);
            return Ok(pessoa);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<PessoaModel>> DeletePeople(int id)
        {
            bool isDelete = await _pessoaRepository.DeletePeople(id);
            return Ok(isDelete);
        }


    }
}
