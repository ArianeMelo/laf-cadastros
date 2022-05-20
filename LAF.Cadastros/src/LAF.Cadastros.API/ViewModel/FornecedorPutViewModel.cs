﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAF.Cadastros.API.ViewModel
{
    public class FornecedorPutViewModel
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("documento")]
        public string Documento { get; set; }

        [JsonProperty("tipo_fornecedor")]
        public int TipoFornecedor { get; set; }

        [JsonProperty("fornecedor_ativo")]
        public bool FornecedorAtivo { get; set; }

    }
}
