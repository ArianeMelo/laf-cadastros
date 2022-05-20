using Dommel;
using LAF.Cadastros.Domain.Entities;
using LAF.Cadastros.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace LAF.Cadastros.Repository.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly string  _connection = @"Data Source=felipe-pc\SQLEXPRESS;Initial Catalog=LAF.Cadastros;User ID=sa;Password=119696";

       public void Adicionar(Endereco endereco)
       {
          using (SqlConnection db = new SqlConnection(_connection))
          {
             db.Insert(endereco);
          }
       }
       public void Alterar (Endereco endereco)
       {
          using (SqlConnection db = new SqlConnection(_connection))
          {
              db.Update(endereco);
          }
       }



        
    }
}
