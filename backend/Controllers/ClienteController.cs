using System.Collections.Generic;
using backend.Model;
using backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{

    [Route("cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IDataRepository<Cliente> _dataRepository;
        
        public ClienteController(IDataRepository<Cliente> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // ############################################################
        // ############################################################
        // getsimples dos meu clientes
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Cliente> clientes = _dataRepository.Read();
            return Ok(clientes);
        }
        // ############################################################
        // ############################################################
        // CADASTRANDO CLIENTE
        // METODO POST
        [HttpPost]
        public IActionResult Post([FromBody] Cliente clientes)
        {
            if (clientes == null)
            {
                return BadRequest("Requisição está vazia");
            }
 
            _dataRepository.Create(clientes);
            return CreatedAtRoute("Get", 
                new { Id = clientes.IdCliente }, clientes);
        }
        // ############################################################
        // ############################################################
        // ATUALIZAR MEU CLIENTE
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest("Cliente Vazio");
            }
            
            Cliente atualizaCliente = _dataRepository.ReadId(id);

            if (atualizaCliente == null)
            {
                return NotFound("Id Inexistente");
            }
 
            _dataRepository.Update(atualizaCliente, cliente);


            return NoContent();
        }
        // ############################################################
        // ############################################################
        // DELETAR UM CLIENTE POR ID
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Cliente clienteDel = _dataRepository.ReadId(id);
            
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
            Cliente clientes = _dataRepository.ReadId(id);
 
            if (clientes == null)
            {
                return NotFound("Nenhum cliente foi encontrado.");
            }

            return Ok(clientes);
        }

    }
}