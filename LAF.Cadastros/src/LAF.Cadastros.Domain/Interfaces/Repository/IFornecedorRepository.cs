using System;
using System.Collections.Generic;
using System.Text;

namespace LAF.Cadastros.Domain.Interfaces.Repository
{
    public interface IFornecedorRepository
    {
        void Adicionar(Fornecedor fornecedor);
        void Alterar(Fornecedor fornecedor);
        void Excluir(Fornecedor fornecedor); 
       
    }
}
