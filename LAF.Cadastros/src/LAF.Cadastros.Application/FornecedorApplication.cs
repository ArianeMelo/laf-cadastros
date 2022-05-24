using LAF.Cadastros.Domain;
using LAF.Cadastros.Domain.Interfaces.Application;
using LAF.Cadastros.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LAF.Cadastros.Application
{
    public class FornecedorApplication : IFornecedorApplication
    {
        private readonly IFornecedorRepository _fornecedorRepository;             

        public FornecedorApplication(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public Fornecedor ObterPorId(Guid id)
        {
            return _fornecedorRepository.ObterPorId(id);
        }

        public IEnumerable<Fornecedor> ObterTodos()
        {
            return _fornecedorRepository.ObterTodos();
        }

        public IEnumerable<Fornecedor> Buscar(Expression<Func<Fornecedor, bool>> where)
        {
            return _fornecedorRepository.Buscar(where);
        }
        public void Adicionar(Fornecedor fornecedor)
        {
            _fornecedorRepository.Adicionar(fornecedor);
        }

        public void Alterar(Fornecedor fornecedor)
        {
            _fornecedorRepository.Alterar(fornecedor);
        }

        public void Excluir(Fornecedor fornecedor)
        {
            _fornecedorRepository.Excluir(fornecedor);
        }
    }
}
