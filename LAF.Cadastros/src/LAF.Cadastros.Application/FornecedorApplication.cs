using LAF.Cadastros.Domain;
using LAF.Cadastros.Domain.Interfaces.Application;
using LAF.Cadastros.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LAF.Cadastros.Application
{
    public class FornecedorApplication : IFornecedorApplication
    {
        private readonly IFornecedorRepository _fornecedorRepository;             

        public FornecedorApplication(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public async Task<Fornecedor> ObterPorId(Guid id)
        {
            return await _fornecedorRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<Fornecedor>> ObterTodos()
        {
            return await _fornecedorRepository.ObterTodos();
        }

        public async Task<IEnumerable<Fornecedor>> Buscar(Expression<Func<Fornecedor, bool>> where)
        {
            return await _fornecedorRepository.Buscar(where);
        }
        public async Task Adicionar(Fornecedor fornecedor)
        {
            await _fornecedorRepository.Adicionar(fornecedor);
        }

        public async Task Alterar(Fornecedor fornecedor)
        {
            await _fornecedorRepository.Alterar(fornecedor);
        }

        public async Task Excluir(Fornecedor fornecedor)
        {
            await _fornecedorRepository.Excluir(fornecedor);
        }
    }
}
