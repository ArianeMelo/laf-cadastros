﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LAF.Cadastros.Domain
{
    public class Fornecedor 
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Documento  { get; set; }
        public int TipoFornecedor { get; set; }
        public bool FornecedorAtivo { get; set; }

        public Fornecedor()
        {
            Id = Guid.NewGuid();
        }
    }
}
