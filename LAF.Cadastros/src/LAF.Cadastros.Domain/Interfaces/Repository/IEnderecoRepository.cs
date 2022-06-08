using LAF.Cadastros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LAF.Cadastros.Domain.Interfaces.Repository
{
   public interface IEnderecoRepository
    {
        Task<Endereco> ObterPorId(Guid id);
        Task<IEnumerable<Endereco>> ObterTodos();
        Task Adicionar(Endereco endereco);
        Task Alterar(Endereco endereco);
        Task Excluir(Endereco endereco);
        
    }
}
