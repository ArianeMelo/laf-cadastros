using LAF.Cadastros.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace LAF.Cadastros.Domain.Interfaces.Application
{
    public interface IFornecedorApplication
    {
        void Adicionar(Fornecedor fornecedor);
        void Alterar(Fornecedor fornecedor);
        void Excluir(Fornecedor fornecedor);
        
        
    }
}
