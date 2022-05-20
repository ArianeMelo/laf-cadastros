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
        private readonly IFornecedorApplication _fornecedorAppication;

        public FornecedorController(IFornecedorApplication fornecedorApplication)
        {
            _fornecedorAppication = fornecedorApplication;
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
            _fornecedorAppication.Adicionar(fornecedor);

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
            _fornecedorAppication.Alterar(fornecedor);

            return Ok(fornecedor);
        }


    }
}
