using LAF.Cadastros.API.ViewModel;
using LAF.Cadastros.Domain;
using LAF.Cadastros.Domain.Entities;
using LAF.Cadastros.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace LAF.Cadastros.API.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoApplication _produtoApplication;
        private readonly IFornecedorApplication _fornecedorApplication;

        public ProdutoController(
            IProdutoApplication produtoApplication,
            IFornecedorApplication fornecedorApplication)
        {
            _produtoApplication = produtoApplication;
            _fornecedorApplication = fornecedorApplication;
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(Guid id)
        {
            Produto produto = _produtoApplication.ObterPorId(id);

            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(_produtoApplication.ObterTodos());
        }

        [HttpPost]
        public IActionResult Adicionar(ProdutoPostViewModel produtoPostViewModel)
        {
            Fornecedor fornecedor = _fornecedorApplication.Buscar(forn => forn.Id == produtoPostViewModel.FornecedorId).FirstOrDefault();

            if (fornecedor == null)
                return BadRequest("Fornecedor não cadastrado");

            if (String.IsNullOrEmpty(produtoPostViewModel.Nome))
                return BadRequest("Campo nome deve estar preenchido");

            if (produtoPostViewModel.Valor <= 0)
                return BadRequest("Informar valor do produto");

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
            Fornecedor fornecedor = _fornecedorApplication.Buscar(forn => forn.Id == produtoPutViewModel.FornecedorId).FirstOrDefault();

            if (fornecedor == null)
                return BadRequest("Fornecedor não encontrado");

            Produto produto = _produtoApplication.ObterPorId(id);

            if (produto == null)
                return BadRequest("Produto não encontrado");

            if (String.IsNullOrEmpty(produtoPutViewModel.Nome))
                return BadRequest("Informar nome do produto");

            if (produtoPutViewModel.Valor <= 0)
                return BadRequest("Informar valor do produto");

                produto = new Produto
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
            Produto produto = _produtoApplication.ObterPorId(id);

            if (produto == null)
                return BadRequest("Produto não encontrado");

            produto.Id = id;
            
            _produtoApplication.Excluir(produto);

            return Ok();
        }
    }
}
