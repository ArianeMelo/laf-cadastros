using LAF.Cadastros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LAF.Cadastros.Domain.Interfaces.Application
{
    public interface IEnderecoApplication
    {
        Endereco ObterPorId(Guid id);
        IEnumerable<Endereco> ObterTodos();
        void Adicionar(Endereco endereco);
        void Alterar(Endereco endereco);
        void Excluir(Endereco endereco);        
    }
}
