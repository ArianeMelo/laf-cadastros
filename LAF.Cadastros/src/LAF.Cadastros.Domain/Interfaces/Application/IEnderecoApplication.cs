using LAF.Cadastros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LAF.Cadastros.Domain.Interfaces.Application
{
    public interface IEnderecoApplication
    {
        void Adicionar(Endereco endereco);
        void Alterar(Endereco endereco);
        
    }
}
