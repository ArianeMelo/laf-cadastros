using LAF.Cadastros.Domain;
using LAF.Cadastros.Domain.Entities;
using LAF.Cadastros.Domain.Interfaces.Application;
using LAF.Cadastros.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LAF.Cadastros.Application
{
    public class EnderecoApplication : IEnderecoApplication
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoApplication(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public async Task<Endereco> ObterPorId(Guid id)
        {
            return await _enderecoRepository.ObterPorId(id);
        }

        public async Task <IEnumerable<Endereco>> ObterTodos()
        {
            return await _enderecoRepository.ObterTodos();
        }

        public async Task Adicionar (Endereco endereco)
        {
            await _enderecoRepository.Adicionar(endereco);
        }

        public async Task Alterar (Endereco endereco)
        {
            await _enderecoRepository.Alterar(endereco);
        }

        public async Task Excluir(Endereco endereco)
        {
            await _enderecoRepository.Excluir(endereco); 
        }

      
    }
}
