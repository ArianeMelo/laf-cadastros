using LAF.Cadastros.API.ViewModel;
using LAF.Cadastros.Application;
using LAF.Cadastros.Domain;
using LAF.Cadastros.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;

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
        
    }
}
