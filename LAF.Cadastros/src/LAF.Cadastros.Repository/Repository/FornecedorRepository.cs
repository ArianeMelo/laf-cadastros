using Dapper;
using Dommel;
using LAF.Cadastros.Domain;
using LAF.Cadastros.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LAF.Cadastros.Repository.Repository
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private string _connection = @"Data Source=felipe-pc\SQLEXPRESS;Initial Catalog=LAF.Cadastros;User ID=sa;Password=119696";

       
        public async Task Adicionar(Fornecedor fornecedor)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                await db.InsertAsync(fornecedor);
            }
        }

        public async Task Alterar(Fornecedor fornecedor)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                await db.UpdateAsync (fornecedor);
            }
        }

        public async Task Excluir (Fornecedor fornecedor)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                await db.DeleteAsync(fornecedor);
            }
        }

        public async Task<Fornecedor> ObterPorId(Guid id)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                return await db.GetAsync<Fornecedor>(id);
            }        
        }

        public async Task<IEnumerable<Fornecedor>> ObterTodos()
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                return await db.GetAllAsync<Fornecedor>();
            }
        }

        public async Task<IEnumerable<Fornecedor>> Buscar(Expression<Func<Fornecedor, bool>> where) //Campo WHERE também pode ser predicate 
        {
            using(SqlConnection db = new SqlConnection(_connection))
            {
                return await db.SelectAsync<Fornecedor>(where); //Select é o método do Dapper que possui capacidade de converter expressão lambda em query SQL =  WHERE 
            }
        }
    }
}
