using LAF.Cadastros.API.ViewModel;
using LAF.Cadastros.Domain.Entities;
using LAF.Cadastros.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LAF.Cadastros.API.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoApplication _produtoApplication;

        public ProdutoController(IProdutoApplication produtoApplication)
        {
            _produtoApplication = produtoApplication;
        }

        [HttpPost]
        public IActionResult Adicionar(ProdutoPostViewModel produtoPostViewModel)
        {
            Produto produto = new Produto
            {
                FornecedorId = produtoPostViewModel.FornecedorId,
                Nome = produtoPostViewModel.Nome,
                Descricao = produtoPostViewModel.Descricao,
                Valor = produtoPostViewModel.Valor,
                ProdutoAtivo = produtoPostViewModel.ProdutoAtivo
            };

            _produtoApplication.Adicionar(produto);

            return Ok(produto);
        }

        [HttpPut("{id}")]
        public IActionResult Alterar(Guid id, [FromBody] ProdutoPutViewModel produtoPutViewModel)
        {
            Produto produto = new Produto
            {
                Id = id,
                FornecedorId = produtoPutViewModel.FornecedorId,
                Nome = produtoPutViewModel.Nome,
                Descricao = produtoPutViewModel.Descricao,
                Valor = produtoPutViewModel.Valor,
                ProdutoAtivo = produtoPutViewModel.ProdutoAtivo
            };

            _produtoApplication.Alterar(produto);

            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(Guid id)
        {
            Produto produto = new Produto
            {
                Id = id
            };
            _produtoApplication.Excluir(produto);

            return Ok();            
        }
    }
}
