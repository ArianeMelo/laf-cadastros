using Dommel;
using LAF.Cadastros.Domain;
using LAF.Cadastros.Domain.Entities;
using LAF.Cadastros.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace LAF.Cadastros.Repository.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly string  _connection = @"Data Source=felipe-pc\SQLEXPRESS;Initial Catalog=LAF.Cadastros;User ID=sa;Password=119696";

       public async Task Adicionar(Endereco endereco)
       {
          using (SqlConnection db = new SqlConnection(_connection))
          {
             await db.InsertAsync(endereco);
          }
       }
       public async Task Alterar (Endereco endereco)
       {
          using (SqlConnection db = new SqlConnection(_connection))
          {
                await db.UpdateAsync(endereco);
          }
       }
        public async Task Excluir (Endereco endereco)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                await db.DeleteAsync(endereco);
            }
        }
        public async Task<Endereco> ObterPorId(Guid id)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                return await db.GetAsync<Endereco>(id);
            }
        }

        public async Task<IEnumerable<Endereco>> ObterTodos()
        {
            using(SqlConnection db = new SqlConnection(_connection))
            {
                return await  db.GetAllAsync<Endereco>(); 
            }
        }
    }
}
