using LAF.Cadastros.API.ViewModel;
using LAF.Cadastros.Application;
using LAF.Cadastros.Domain;
using LAF.Cadastros.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAF.Cadastros.API.Controllers
{

    [Route("api/fornecedores")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorApplication _fornecedorApplication;

        public FornecedorController(IFornecedorApplication fornecedorApplication)
        {
            _fornecedorApplication = fornecedorApplication;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            Fornecedor fornecedor = await _fornecedorApplication.ObterPorId(id);
            
            if (fornecedor == null)
                return NotFound("Fornecedor não cadastrado");           
            
                return Ok(fornecedor);
        }
        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            return Ok (await _fornecedorApplication.ObterTodos());
        }

        [HttpGet("filtros/{documento}")]
        public async Task<IActionResult> Buscar(string documento)
        {
             IEnumerable<Fornecedor> fornecedores =  await _fornecedorApplication.Buscar
                (forn => forn.Documento == documento);

            Fornecedor fornecedor = fornecedores.FirstOrDefault();

            if (fornecedor == null)
                return NotFound("Fornecedor não cadastrado");

            return Ok(fornecedor);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(FornecedorPostViewModel fornecedorPostViewModel)
       {

            IEnumerable<Fornecedor> fornecedores =  _fornecedorApplication.Buscar
                (forn => forn.Documento == fornecedorPostViewModel.Documento).Result;

            Fornecedor fornecedor = fornecedores.FirstOrDefault();           

            if (fornecedor != null)          
                return BadRequest("Fornecedor já cadastrado");
            
            if (String.IsNullOrEmpty(fornecedorPostViewModel.Nome))            
                return BadRequest("Nome deve estar preenchido");

            if (String.IsNullOrEmpty(fornecedorPostViewModel.Documento))
                return BadRequest("Documento deve estar preenchido");

            fornecedor = new Fornecedor()
            {
                Nome = fornecedorPostViewModel.Nome,
                Documento = fornecedorPostViewModel.Documento,
                TipoFornecedor = fornecedorPostViewModel.TipoFornecedor,
                Ativo = fornecedorPostViewModel.Ativo,
            };
            
             await _fornecedorApplication.Adicionar(fornecedor);

            return Ok(fornecedor);
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> Alterar(Guid id, [FromBody] FornecedorPutViewModel fornecedorPutViewModel)
        {
            Fornecedor fornecedor = await _fornecedorApplication.ObterPorId(id);

            if (fornecedor == null)
                return NotFound("Fornecedor não existe");       

            fornecedor.Nome = fornecedorPutViewModel.Nome;
            fornecedor.TipoFornecedor = fornecedorPutViewModel.TipoFornecedor; 
            fornecedor.Ativo = fornecedorPutViewModel.Ativo;
           

            await _fornecedorApplication.Alterar(fornecedor);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir (Guid id)
        {
            Fornecedor fornecedor = await _fornecedorApplication.ObterPorId(id);

            if (fornecedor == null)
                return NotFound("Fornecedor não existe");
           
                fornecedor.Id = id;

            await _fornecedorApplication.Excluir(fornecedor);

            return NoContent();
        }      
      
    }
}
