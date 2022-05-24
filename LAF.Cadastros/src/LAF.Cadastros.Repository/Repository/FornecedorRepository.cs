using Dapper;
using Dommel;
using LAF.Cadastros.Domain;
using LAF.Cadastros.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Text;

namespace LAF.Cadastros.Repository.Repository
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private string _connection = @"Data Source=felipe-pc\SQLEXPRESS;Initial Catalog=LAF.Cadastros;User ID=sa;Password=119696";

       
        public void Adicionar(Fornecedor fornecedor)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                db.Insert(fornecedor);
            }
        }

        public void Alterar(Fornecedor fornecedor)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                db.Update(fornecedor);
            }
        }

        public void Excluir (Fornecedor fornecedor)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                db.Delete(fornecedor);
            }
        }

        public Fornecedor ObterPorId(Guid id)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                return db.Get<Fornecedor>(id);
            }        
        }

        public IEnumerable<Fornecedor> ObterTodos()
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                return db.GetAll<Fornecedor>();
            }
        }

        public IEnumerable<Fornecedor> Buscar(Expression<Func<Fornecedor, bool>> where) //Campo WHERE também pode ser predicate 
        {
            using(SqlConnection db = new SqlConnection(_connection))
            {
                return db.Select<Fornecedor>(where); //Select é o método do Dapper que possui capacidade de converter expressão lambda em query SQL =  WHERE 
            }
        }
    }
}
