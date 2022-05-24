using LAF.Cadastros.API.ViewModel;
using LAF.Cadastros.Application;
using LAF.Cadastros.Domain;
using LAF.Cadastros.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

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

        [HttpGet("{id:Guid}")]
        public IActionResult ObterPorId(Guid id)
        {
            Fornecedor fornecedor = _fornecedorApplication.ObterPorId(id);
            
            if (fornecedor == null)
                return NotFound();           
            
                return Ok(fornecedor);
        }
        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok (_fornecedorApplication.ObterTodos());
        }

        [HttpGet("filtros/{documento}")]
        public IActionResult Buscar(string documento)
        {
            return Ok(_fornecedorApplication.Buscar(fornecedor => fornecedor.Documento == documento));
        }

        [HttpPost]
        public IActionResult Adicionar(FornecedorPostViewModel fornecedorPostViewModel)
        {

            Fornecedor fornecedor = _fornecedorApplication.Buscar(fornecedor => fornecedor.Documento == fornecedorPostViewModel.Documento).FirstOrDefault();

            if (fornecedor != null)
            {
                return BadRequest("Fornecedor já cadastrado");
            }
            
            fornecedor = new Fornecedor()
            {
                Nome = fornecedorPostViewModel.Nome,
                Documento = fornecedorPostViewModel.Documento,
                TipoFornecedor = fornecedorPostViewModel.TipoFornecedor,
                Ativo = fornecedorPostViewModel.Ativo,

            };
            
            _fornecedorApplication.Adicionar(fornecedor);

            return Ok(fornecedor);
        }

       
        [HttpPut("{id}")]
        public IActionResult Alterar(Guid id, [FromBody] FornecedorPutViewModel fornecedorPutViewModel)
        {
            Fornecedor fornecedor = _fornecedorApplication.ObterPorId(id);

            if (fornecedor == null)
                return NotFound("Fornecedor não existe");

                         
               fornecedor.Nome = fornecedorPutViewModel.Nome;
               fornecedor.TipoFornecedor = fornecedorPutViewModel.TipoFornecedor;
               fornecedor.Ativo = fornecedorPutViewModel.Ativo;
                       
            _fornecedorApplication.Alterar(fornecedor);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir (Guid id)
        {
            Fornecedor fornecedor = _fornecedorApplication.ObterPorId(id);

            if (fornecedor == null)
                return NotFound("Fornecedor não existe");
           
                fornecedor.Id = id;

            _fornecedorApplication.Excluir(fornecedor);

            return NoContent();
        }      
      
    }
}
