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
        public ProfissaoController(IDataRepository<Profissao> dataRepository) => _dataRepository = dataRepository;

        // ############################################################
        // ############################################################
        // getsimples dos meu profissoes
        [HttpGet]
        public IEnumerable<Profissao> GetAll()
        {
            var result = _dataRepository.Read();
            return result;
        }
        // ############################################################
        // ############################################################
        // getybyclientes get por id do cliente
        [HttpGet("{id}", Name="getProfissao")]
        public IActionResult GetById(int id)
        {
            var profissoes = _dataRepository.ReadId(id);
 
            if (profissoes == null)
            {
                return NotFound("Nenhuma profissão foi encontrado.");
            }

            return new ObjectResult(profissoes);
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
            return CreatedAtRoute("getProfissao", 
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
            
            var atualizaProfissao = _dataRepository.ReadId(id);

            if (atualizaProfissao == null)
            {
                return NotFound("Id Inexistente");
            }
            
            atualizaProfissao.Nome = profissao.Nome;
            atualizaProfissao.Descricao = profissao.Descricao;

            _dataRepository.Update(atualizaProfissao);

            return new ContentResult();
        }
        // ############################################################
        // ############################################################
        // DELETAR UM PROFISSAO POR ID
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var clienteDel = _dataRepository.ReadId(id);
            
            if (clienteDel == null)
            {
                return NotFound("Id inexistente para remover");
            }
 
            _dataRepository.Delete(clienteDel);
            return new NoContentResult();
        }
    }
}