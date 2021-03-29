using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FUCT_API.Controllers;
using FUCT_API.Models;
using FUCT_API.Services.Interfaces;
using FUCT_API_TEST.ServiceMocks;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace FUCT_API_TEST.Controllers
{
    public class CargueiroControllerTest
    {
        CargueiroController _controller;
        ICargueiroService _cargueiroService;
        IMineraisService _mineraisService;

        public CargueiroControllerTest()
        {
            _cargueiroService = new CargueiroServiceMock();
            _mineraisService = new MineraisServiceMock();
            _controller = new CargueiroController(_cargueiroService, _mineraisService);
        }

        [Fact]
        public void StartChargeSuccessfully()
        {
            CargueiroRequest saida = new CargueiroRequest()
            {
                Ano = 2021,
                Mes = 2,
                Semana = 4,
                Tipo = 'A'
            };

            var result = _controller.StartCharge(saida) as OkObjectResult;
            var item = JsonSerializer.Serialize(result.Value);
            var itemExpected = JsonSerializer.Serialize(new { Message = "Saída registrada com sucesso" });

            Assert.Equal(itemExpected, item);
        }

        [Fact]
        public void InvalidLoadType()
        {
            CargueiroRequest saida = new CargueiroRequest()
            {
                Ano = 2021,
                Mes = 2,
                Semana = 4,
                Tipo = 'P'
            };

            var result = _controller.StartCharge(saida) as BadRequestObjectResult;
            var item = JsonSerializer.Serialize(result.Value);
            var itemExpected = JsonSerializer.Serialize("Tipo de Carga inválida");

            Assert.Equal(itemExpected, item);
        }

        [Fact]
        public void LoadReturnSuccessfully()
        {
            var result = _controller.LoadReturn(1) as OkObjectResult;
            var item = JsonSerializer.Serialize(result.Value);
            var itemExpected = JsonSerializer.Serialize(new { Message = "Retorno registrado com sucesso" });

            Assert.Equal(itemExpected, item);
        }

        [Fact]
        public void GetPaginationSuccess()
        {
            
            var result = _controller.GetTablePagination(0, 10, null, "Id", "asc") as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
        }


    }
}
