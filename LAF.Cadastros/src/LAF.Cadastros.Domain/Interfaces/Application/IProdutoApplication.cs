using LAF.Cadastros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LAF.Cadastros.Domain.Interfaces.Application
{
    public interface IProdutoApplication
    {
        void Adicionar(Produto produto);
        void Alterar(Produto produto);
        void Excluir(Produto produto);
    }
}
