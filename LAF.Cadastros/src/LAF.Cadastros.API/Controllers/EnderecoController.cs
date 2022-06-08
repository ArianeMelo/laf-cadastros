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
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            Endereco endereco = await _enderecoApplication.ObterPorId(id);

            if (endereco == null)
                return NotFound();

            return Ok(endereco);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            return Ok(await _enderecoApplication.ObterTodos());
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(EnderecoPostViewModel enderecoPostViewModel)
        {
             Fornecedor fornecedor = await _fornecedorApplication.ObterPorId(enderecoPostViewModel.FornecedorId); 

            if (fornecedor == null)
                return BadRequest("Fornecedor não cadastrado");

            if (string.IsNullOrEmpty(enderecoPostViewModel.Logradouro))
                return BadRequest("Endereço deve estar preenchido");

            if (String.IsNullOrEmpty(enderecoPostViewModel.Numero))
                return BadRequest("Campo número deve estar preenchido");

            if (String.IsNullOrEmpty(enderecoPostViewModel.Cep))
                return BadRequest("Campo cep deve estar preenchido");

            if (String.IsNullOrEmpty(enderecoPostViewModel.Bairro))
                return BadRequest("Campo bairro deve estar preenchido");

            if (String.IsNullOrEmpty(enderecoPostViewModel.Cidade))
                return BadRequest("Campo Cidade deve estar preenchido");

            if (String.IsNullOrEmpty(enderecoPostViewModel.Estado))
                return BadRequest("Campo Estado deve estar preenchido");

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

            await _enderecoApplication.Adicionar(endereco);

            return Ok(endereco);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Alterar(Guid id, [FromBody] EnderecoPutViewModel enderecoPutViewModel)
        {
            Endereco endereco = await _enderecoApplication.ObterPorId(id);

            if (endereco == null)
                return BadRequest("Endereço não encontrado");          

           

            Fornecedor fornecedor = await _fornecedorApplication.ObterPorId(enderecoPutViewModel.FornecedorId);
            if (fornecedor == null)
                return BadRequest("Fornecedor não cadastrado");
            

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

            await _enderecoApplication.Alterar(endereco);

            return Ok(endereco);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            Endereco endereco = await _enderecoApplication.ObterPorId(id);

            if (endereco == null)
                return NotFound("Endereço não encontrado");

            endereco.Id = id;

            await _enderecoApplication.Excluir(endereco);

            return NoContent();
        }
    }
}
