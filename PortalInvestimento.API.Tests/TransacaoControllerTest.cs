using Microsoft.AspNetCore.Mvc;
using PortalInvestimento.API.Controllers;
using PortalInvestimento.Application.DTOs;
using PortalInvestimento.Application.Interfaces;
using Xunit.Abstractions;

namespace PortalInvestimento.API.Tests
{
    public class TransacaoControllerTest
    {
        TransacaoController _controller;
        ITransacaoService _service;

        public TransacaoControllerTest()
        {
            _service = new TransacaoServiceFake();
            _controller = new TransacaoController(_service);
        }

        [Fact]
        public void ObterTodasTransacoes_ReturnOkResult() 
        {
            var result = _controller.Get().Result.Result as OkObjectResult;

            var itens = Assert.IsType<List<TransacaoDTO>>(result.Value);
            Assert.Equal(6, itens.Count);
        }

        [Fact]
        public void GetTransacoesPorId_ReturnOkResult()
        {
            var id = 6;
            var result = _controller.Get(id).Result.Result as OkObjectResult;

            Assert.IsType<TransacaoDTO>(result.Value);
            Assert.Equal(id, (result.Value as TransacaoDTO).Id);
            
        }

        [Fact]
        public void GetTransacoesPorId_NotFoundObjectResult()
        {
            var result = _controller.Get(70).Result;

            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        [Fact]
        public void Delete_ReturnOkResult()
        {
            var id = 6;
            var result = _controller.Delete(id).Result as OkObjectResult;

            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public void Delete_NotFoundObjectResult()
        {
            var result = _controller.Delete(70);

            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        [Fact]
        public void Add_ReturnOkResult()
        {
            TransacaoDTO transacaoDTO = new TransacaoDTO()
            {
                Preco = 200.00M,
                Quantidade = 3,
                AtivoId = 1,
                PortfolioId = 2,
                Operacao = "A"
            };
            var result = _controller.Post(transacaoDTO);


            Assert.IsType<OkObjectResult>(result.Result);  

        }
    }
}
