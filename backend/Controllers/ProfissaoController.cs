using System.Collections.Generic;
using backend.Model;
using backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
 
    [Route("profissao")]
    [ApiController]
    public class ProfissaoController:ControllerBase
    {
        private readonly IDataRepository<Profissao> _dataRepository;
        
        public ProfissaoController(IDataRepository<Profissao> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // ############################################################
        // ############################################################
        // getsimples dos meu profissoes
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Profissao> profissoes = _dataRepository.Read();
            return Ok(profissoes);
        }
        // ############################################################
        // ############################################################
        // CADASTRANDO PROFISSAO
        // METODO POST
        [HttpPost]
        public IActionResult Post([FromBody] Profissao profissoes)
        {
            if (profissoes == null)
            {
                return BadRequest("Requisição está vazia");
            }
 
            _dataRepository.Create(profissoes);
            return CreatedAtRoute("Get", 
                new { Id = profissoes.IdProfissao }, profissoes);
        }
        // ############################################################
        // ############################################################
        // ATUALIZAR MEU PROFISSAO
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Profissao profissao)
        {
            if (profissao == null)
            {
                return BadRequest("Profissão Vazia");
            }
            
            Profissao atualizaProfissao = _dataRepository.ReadId(id);
            if (atualizaProfissao == null)
            {
                return NotFound("Id Inexistente");
            }
            _dataRepository.Update(atualizaProfissao, profissao);

            return NoContent();
        }
        // ############################################################
        // ############################################################
        // DELETAR UM PROFISSAO POR ID
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Profissao clienteDel = _dataRepository.ReadId(id);
            
            if (clienteDel == null)
            {
                return NotFound("Id inexistente para remover");
            }
 
            _dataRepository.Delete(clienteDel);
            return NoContent();
        }
        // ############################################################
        // ############################################################
        // getybyclientes get por id do cliente
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Profissao profissoes = _dataRepository.ReadId(id);
 
            if (profissoes == null)
            {
                return NotFound("Nenhuma profissão foi encontrado.");
            }

            return Ok(profissoes);
        }
    }
}