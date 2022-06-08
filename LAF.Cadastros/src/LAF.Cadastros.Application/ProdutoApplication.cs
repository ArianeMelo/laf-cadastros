using LAF.Cadastros.Domain.Entities;
using LAF.Cadastros.Domain.Interfaces.Application;
using LAF.Cadastros.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LAF.Cadastros.Application
{
    public class ProdutoApplication : IProdutoApplication
    {
        private readonly  IProdutoRepository _produtoRepository;

        public ProdutoApplication(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
       
       public async Task Adicionar(Produto produto)
        {
            await _produtoRepository.Adicionar(produto);
        }

        public async Task Alterar (Produto produto)
        {
            await _produtoRepository.Alterar(produto);
        }

        public async Task Excluir(Produto produto)
        {
            await _produtoRepository.Excluir(produto);
        }

        public async Task<Produto> ObterPorId(Guid id)
        {
           return await _produtoRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            return await _produtoRepository.ObterTodos();
        }
    }
}
