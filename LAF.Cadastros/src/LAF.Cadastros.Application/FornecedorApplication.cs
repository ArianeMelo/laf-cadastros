using LAF.Cadastros.Domain;
using LAF.Cadastros.Domain.Interfaces.Application;
using LAF.Cadastros.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace LAF.Cadastros.Application
{
    public class FornecedorApplication : IFornecedorApplication
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorApplication(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }
        public void Adicionar(Fornecedor fornecedor)
        {
            _fornecedorRepository.Adicionar(fornecedor);
        }

        public void Alterar(Fornecedor fornecedor)
        {
            _fornecedorRepository.Alterar(fornecedor);
        }
    }
}
