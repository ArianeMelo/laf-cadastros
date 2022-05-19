using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAF.Cadastros.API.ViewModel
{
    public class ProdutoPostViewModel
    {
        [JsonProperty("fornecedor_id")]       
        public Guid FornecedorId { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("descricao")]
        public string Descricao { get; set; }

        [JsonProperty("valor")]
        public decimal Valor { get; set; }

        [JsonProperty("produto_ativo")]
        public bool ProdutoAtivo { get; set; }
    }
}
