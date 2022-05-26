using Dommel;
using LAF.Cadastros.Domain.Entities;
using LAF.Cadastros.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Text;

namespace LAF.Cadastros.Repository.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private string _connection = @"Data Source=felipe-pc\SQLEXPRESS;Initial Catalog=LAF.Cadastros;User ID=sa;Password=119696";
        public void Adicionar(Produto produto)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                db.Insert(produto);
            }
        }

        public void Alterar (Produto produto)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                db.Update(produto);
            }
        }

        public void Excluir(Produto produto)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                db.Delete(produto);
            }
        }

        public Produto ObterPorId(Guid id)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                return db.Get<Produto>(id);
            }
        }

        public IEnumerable<Produto> ObterTodos()
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                return db.GetAll<Produto>();
            }
        }

    }
}
