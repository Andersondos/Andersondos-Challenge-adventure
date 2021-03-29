using FUCT_API.Data;
using FUCT_API.Entities;
using FUCT_API.Services;
using FUCT_API.Services.Interfaces;
using FUCT_API_TEST.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace FUCT_API_TEST.Service
{
    public class CargueiroServiceTest
    {
        private ICargueiroService _service;
        private DataContext _context;

        public CargueiroServiceTest()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            var appSettings = new OptionsHelper();

            _context = new DataContext(options);
            _service = new CargueiroService(_context, appSettings);
        }

        [Fact]
        public void GetAllLoads()
        {
            Formulario carga = new Formulario()
            {
                Quantidade = 8,
                Tipo_minerais = 'A',
                Data_Saida = DateTime.Parse("2021-05-10T17:56:48.0953925-03:00"),
                Data_Retorno = null,
                Status = 0,
                preco = null
            };

            _service.PostCharge(carga.Quantidade, carga.Tipo_minerais, carga.Data_Saida);

            var chargeResult = _service.GetAll().ToList();

            Assert.NotNull(chargeResult);
            Assert.Equal(carga.Quantidade, chargeResult[0].Quantidade);
            Assert.Equal(carga.Tipo_minerais, chargeResult[0].Tipo_minerais);
            Assert.Equal(carga.Data_Saida, chargeResult[0].Data_Saida);
            Assert.Equal(carga.Data_Retorno, chargeResult[0].Data_Retorno);
            Assert.Equal(carga.Status, chargeResult[0].Status);
            Assert.Equal(carga.preco, chargeResult[0].preco);
        }

    }
}
