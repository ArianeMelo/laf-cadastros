﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAF.Cadastros.API.ViewModel
{
    public class EnderecoPostViewModel
    {
        [JsonProperty("fornecedor_id")]
        public Guid FornecedorId { get; set; }

        [JsonProperty("endereco")]
        public string Logradouro { get; set; }

        [JsonProperty("numero")]
        public string Numero { get; set; }

        [JsonProperty("complemento")]
        public string Complemento { get; set; }

        [JsonProperty("cep")]
        public string Cep { get; set; }

        [JsonProperty("bairro")]
        public string Bairro { get; set; }

        [JsonProperty("cidade")]
        public string Cidade { get; set; }

        [JsonProperty("estado")]
        public string Estado { get; set; }
    }
}
