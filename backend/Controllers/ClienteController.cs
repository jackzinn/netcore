using System.Collections.Generic;
using backend.Model;
using backend.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{

    [Route("cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IDataRepository<Cliente> _dataRepository;
        public ClienteController(IDataRepository<Cliente> dataRepository) =>  _dataRepository = dataRepository;

        // ############################################################
        // ############################################################
        // getsimples dos meu clientes
        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            var clientes = _dataRepository.Read();
            return clientes;
        }

        // ############################################################
        // ############################################################
        // getybyclientes get por id do cliente
        [HttpGet("{id}", Name="getCliente")]
        public IActionResult Get(int id)
        {
            var clientes = _dataRepository.ReadId(id);
 
            if (clientes == null)
            {
                return NotFound("Nenhum cliente foi encontrado.");
            }

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
            
            return CreatedAtRoute("getCliente", 
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
            
            var atualizaCliente = _dataRepository.ReadId(id);

            if (atualizaCliente == null)
            {
                return NotFound("Id Inexistente");
            }

            atualizaCliente.Nome = cliente.Nome;
            atualizaCliente.Sobrenome = cliente.Sobrenome;
            atualizaCliente.Nascimento = cliente.Nascimento;
            atualizaCliente.Cpf = cliente.Cpf;
            atualizaCliente.Idade = cliente.Idade;
            atualizaCliente.Profissao = cliente.Profissao;

            _dataRepository.Update(atualizaCliente);


            return NoContent();
        }
        // ############################################################
        // ############################################################
        // DELETAR UM CLIENTE POR ID
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var clienteDel = _dataRepository.ReadId(id);
            
            if (clienteDel == null)
            {
                return NotFound("Id inexistente para remover");
            }
 
            _dataRepository.Delete(clienteDel);
            return NoContent();
        }

    }
}