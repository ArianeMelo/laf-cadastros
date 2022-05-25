﻿using LAF.Cadastros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LAF.Cadastros.Domain.Interfaces.Repository
{
    public interface IProdutoRepository
    {
        void Adicionar(Produto produto);
        void Alterar(Produto produto);
        void Excluir(Produto produto);
    }
}
