using LAF.Cadastros.API.ViewModel;
using LAF.Cadastros.Application;
using LAF.Cadastros.Domain;
using LAF.Cadastros.Domain.Entities;
using LAF.Cadastros.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAF.Cadastros.API.Controllers
{
    [Route("api/enderecos")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoApplication _enderecoApplication;
        private readonly IFornecedorApplication _fornecedorApplication;

        public EnderecoController(
            IEnderecoApplication enderecoApplication, 
            IFornecedorApplication fornecedorApplication)
        {
            _enderecoApplication = enderecoApplication;
            _fornecedorApplication = fornecedorApplication;
        }



        [HttpGet("{id}")]
        public IActionResult ObterPorId(Guid id)
        {
            Endereco endereco = _enderecoApplication.ObterPorId(id);

            if (endereco == null)
                return NotFound();

            return Ok(endereco);
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(_enderecoApplication.ObterTodos());
        }

        [HttpPost]
        public IActionResult Adicionar(EnderecoPostViewModel enderecoPostViewModel)
        {
            Fornecedor fornecedor = _fornecedorApplication.Buscar(forn => forn.Id == enderecoPostViewModel.FornecedorId).FirstOrDefault();

            if (fornecedor == null)
            {
                return BadRequest("Fornecedor não cadastrado");
            }

            Endereco endereco = new Endereco()
            {
                FornecedorId = enderecoPostViewModel.FornecedorId,
                Logradouro = enderecoPostViewModel.Logradouro,
                Numero = enderecoPostViewModel.Numero,
                Complemento = enderecoPostViewModel.Complemento,
                Cep = enderecoPostViewModel.Cep,
                Bairro = enderecoPostViewModel.Bairro,
                Cidade = enderecoPostViewModel.Cidade,
                Estado = enderecoPostViewModel.Estado
            };

            _enderecoApplication.Adicionar(endereco);

            return Ok(endereco);
        }

        [HttpPut("{id}")]
        public IActionResult Alterar(Guid id, [FromBody] EnderecoPutViewModel enderecoPutViewModel)
        {
            Endereco endereco = _enderecoApplication.ObterPorId(id);

            if (endereco == null)
            {
                return BadRequest("Endereço não encontrado");
            }

            Fornecedor fornecedor = _fornecedorApplication.Buscar(forn => forn.Id == enderecoPutViewModel.FornecedorId).FirstOrDefault();

            if (fornecedor == null)
            {
                return BadRequest("Fornecedor não cadastrado");
            }

            endereco = new Endereco
            {
                Id = id,
                FornecedorId = enderecoPutViewModel.FornecedorId,
                Logradouro = enderecoPutViewModel.Logradouro,
                Numero = enderecoPutViewModel.Numero,
                Complemento = enderecoPutViewModel.Complemento,
                Cep = enderecoPutViewModel.Cep,
                Bairro = enderecoPutViewModel.Bairro,
                Cidade = enderecoPutViewModel.Cidade,
                Estado = enderecoPutViewModel.Estado
            };

            _enderecoApplication.Alterar(endereco);

            return Ok(endereco);
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(Guid id)
        {
            Endereco endereco = _enderecoApplication.ObterPorId(id);

            if (endereco == null)
                return NotFound("Endereço não encontrado");

            endereco.Id = id;

            _enderecoApplication.Excluir(endereco);

            return NoContent();
        }
    }
}
