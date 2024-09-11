﻿using AutoMapper;
using PortalInvestimento.Application.DTOs;
using PortalInvestimento.Application.Interfaces;
using PortalInvestimento.Domain.Entities;
using PortalInvestimento.Domain.Interfaces;

namespace PortalInvestimento.Application.Services
{
    public class TransacaoService : ITransacaoService
    {
        private readonly ITransacaoRepository _transacaoRepository;
        private readonly IMapper _mapper;

        public TransacaoService(ITransacaoRepository transacaoRepository, IMapper mapper)
        {
            _transacaoRepository = transacaoRepository;
            _mapper = mapper;
        }

        public async Task AlterarAsync(TransacaoDTO entidade)
        {
            var transacao = _mapper.Map<Transacao>(entidade);
            await _transacaoRepository.AlterarAsync(transacao);
        }

        public async Task CadastrarAsync(TransacaoDTO entidade)
        {
            var transacao = _mapper.Map<Transacao>(entidade);

            //if (transacao.Operacao == "R")
            //{
            //    ValidaResgate(transacao.Total, transacao.PortfolioId);
            //}

            await _transacaoRepository.CadastrarAsync(transacao);
   
        }

        //private void ValidaResgate(decimal totalResgate, int portfolioId)
        //{
        //    var saldo = _transacaoRepository.ObterSaldoPorPortfolio(portfolioId);

        //    if (saldo < totalResgate)
        //        throw new Exception("Saldo menor que o valor do resgate!");
            
        //}

        public async Task DeletarAsync(int? id)
        {
            var transacao = _transacaoRepository.ObterPorIdAsync(id).Result;
            await _transacaoRepository.DeletarAsync(transacao);
        }

        public async Task<TransacaoDTO> ObterPorIdAsync(int? id)
        {
            var transacao = await _transacaoRepository.ObterPorIdAsync(id);
            return _mapper.Map<TransacaoDTO>(transacao);
        }

        public async Task<IList<TransacaoDTO>> ObterTodosAsync()
        {
            var transacoes = await _transacaoRepository.ObterTodosAsync();
            return _mapper.Map<IList<TransacaoDTO>>(transacoes);
        }

        public async Task<IList<TransacaoDTO>> ObterTransacaoPorPortfolioId(int portfolioId)
        {
            var transacoes = await _transacaoRepository.ObterTransacaoPorPortfolioId(portfolioId);
            return _mapper.Map<IList<TransacaoDTO>>(transacoes);
        }


    }
}
