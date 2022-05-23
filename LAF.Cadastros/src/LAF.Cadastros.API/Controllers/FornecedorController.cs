using LAF.Cadastros.API.ViewModel;
using LAF.Cadastros.Application;
using LAF.Cadastros.Domain;
using LAF.Cadastros.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System;

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

        [HttpPost]
        public IActionResult Adicionar(FornecedorPostViewModel fornecedorPostViewModel)
        {
            Fornecedor fornecedor = new Fornecedor()
            {
                Nome = fornecedorPostViewModel.Nome,
                Documento = fornecedorPostViewModel.Documento,
                TipoFornecedor = fornecedorPostViewModel.TipoFornecedor,
                FornecedorAtivo = fornecedorPostViewModel.FornecedorAtivo,

            };
            _fornecedorApplication.Adicionar(fornecedor);

            return Ok(fornecedor);
        }

        [HttpPut("{id}")]
        public IActionResult Alterar(Guid id, [FromBody] FornecedorPutViewModel fornecedorPutViewModel)
        {   
            Fornecedor fornecedor = new Fornecedor()
            {
                Id = id,
                Nome = fornecedorPutViewModel.Nome,
                Documento = fornecedorPutViewModel.Documento,
                TipoFornecedor = fornecedorPutViewModel.TipoFornecedor,
                FornecedorAtivo = fornecedorPutViewModel.FornecedorAtivo,

            };
            _fornecedorApplication.Alterar(fornecedor);

            return Ok(fornecedor);
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir (Guid id)
        {
            Fornecedor fornecedor = new Fornecedor
            {
                Id = id,               
            };

            _fornecedorApplication.Excluir(fornecedor);

            return Ok(fornecedor);

            
        }


    }
}
