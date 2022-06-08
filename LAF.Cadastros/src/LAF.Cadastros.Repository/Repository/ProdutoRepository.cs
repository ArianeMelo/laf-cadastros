using Dommel;
using LAF.Cadastros.Domain.Entities;
using LAF.Cadastros.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LAF.Cadastros.Repository.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private string _connection = @"Data Source=felipe-pc\SQLEXPRESS;Initial Catalog=LAF.Cadastros;User ID=sa;Password=119696";
        public async Task Adicionar(Produto produto)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                await db.InsertAsync(produto);
            }
        }

        public async Task Alterar (Produto produto)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                await db.UpdateAsync(produto);
            }
        }

        public async Task Excluir(Produto produto)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                await db.DeleteAsync(produto);
            }
        }

        public async Task<Produto> ObterPorId(Guid id)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                return await db.GetAsync<Produto>(id);
            }
        }

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                return await db.GetAllAsync<Produto>();
            }
        }

    }
}
