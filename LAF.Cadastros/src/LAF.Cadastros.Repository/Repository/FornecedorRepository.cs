﻿using Dapper;
using Dommel;
using LAF.Cadastros.Domain;
using LAF.Cadastros.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    }

}
