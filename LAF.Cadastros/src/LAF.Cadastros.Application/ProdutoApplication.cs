using LAF.Cadastros.Domain.Entities;
using LAF.Cadastros.Domain.Interfaces.Application;
using LAF.Cadastros.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace LAF.Cadastros.Application
{
    public class ProdutoApplication : IProdutoApplication
    {
        private readonly  IProdutoRepository _produtoRepository;

        public ProdutoApplication(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
       public void Adicionar(Produto produto)
        {
            _produtoRepository.Adicionar(produto);
        }

        public void Alterar (Produto produto)
        {
            _produtoRepository.Alterar(produto);
        }

        public void Excluir(Produto produto)
        {
            _produtoRepository.Excluir(produto);
        }
    }
}
