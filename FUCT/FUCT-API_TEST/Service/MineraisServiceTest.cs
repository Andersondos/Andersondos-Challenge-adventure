using FUCT_API.Services;
using FUCT_API.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FUCT_API_TEST.Service
{
    public class MineraisServiceTest
    {
        private IMineraisService _service;

        public MineraisServiceTest()
        {
            var config = InitConfiguration();
            _service = new MineraisService(config);
        }

        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            return config;
        }

        [Fact]
        public void GetChallengeData()
        {
            int semana = 3;
            int mes = 10;
            int ano = 2021;

            var resul = _service.APIMinerais(mes, ano, semana);

            Assert.NotNull(resul);

        }
    }
}
