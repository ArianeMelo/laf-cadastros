using LAF.Cadastros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LAF.Cadastros.Domain.Interfaces.Repository
{
   public interface IEnderecoRepository
    {
        Endereco ObterPorId(Guid id);
        IEnumerable<Endereco> ObterTodos();
        void Adicionar(Endereco endereco);
        void Alterar(Endereco endereco);
        void Excluir(Endereco endereco);
        
    }
}
