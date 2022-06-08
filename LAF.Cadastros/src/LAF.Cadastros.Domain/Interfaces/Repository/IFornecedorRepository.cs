using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LAF.Cadastros.Domain.Interfaces.Repository
{
    public interface IFornecedorRepository
    {
        Task<Fornecedor> ObterPorId(Guid id);
        Task<IEnumerable<Fornecedor>> ObterTodos();
        Task<IEnumerable<Fornecedor>> Buscar(Expression<Func<Fornecedor, bool>>where);
        Task Adicionar(Fornecedor fornecedor);
        Task Alterar(Fornecedor fornecedor);
        Task Excluir(Fornecedor fornecedor); 
       
    }
}
