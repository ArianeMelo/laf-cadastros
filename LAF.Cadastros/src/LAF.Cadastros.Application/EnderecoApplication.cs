﻿using LAF.Cadastros.Domain;
using LAF.Cadastros.Domain.Entities;
using LAF.Cadastros.Domain.Interfaces.Application;
using LAF.Cadastros.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace LAF.Cadastros.Application
{
    public class EnderecoApplication : IEnderecoApplication
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoApplication(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public Endereco ObterPorId(Guid id)
        {
            return _enderecoRepository.ObterPorId(id);
        }

        public IEnumerable<Endereco> ObterTodos()
        {
            return _enderecoRepository.ObterTodos();
        }

        public void Adicionar (Endereco endereco)
        {
            _enderecoRepository.Adicionar(endereco);
        }

        public void Alterar (Endereco endereco)
        {
            _enderecoRepository.Alterar(endereco);
        }

        public void Excluir(Endereco endereco)
        {
            _enderecoRepository.Excluir(endereco); 
        }

      
    }
}
