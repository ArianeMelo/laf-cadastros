using Dapper.FluentMap.Dommel.Mapping;
using LAF.Cadastros.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LAF.Cadastros.Repository.Mappings
{
    public class FornecedorMap : DommelEntityMap<Fornecedor>
    {
        public FornecedorMap()
        {
            
            ToTable("Fornecedores"); //Escrever o nome da tabela , de como está no banco,  que se refere a classe que esta sendo mapeada.
            Map(fornecedor => fornecedor.Id).ToColumn("Id");
            Map(fornecedor => fornecedor.Nome).ToColumn("Nome");
            Map(fornecedor => fornecedor.Documento).ToColumn("Documento");
            Map(fornecedor => fornecedor.TipoFornecedor).ToColumn("TipoFornecedor");
            Map(fornecedor => fornecedor.FornecedorAtivo).ToColumn("Ativo");

        }
    }
}
