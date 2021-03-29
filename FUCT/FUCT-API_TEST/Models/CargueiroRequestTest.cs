using FUCT_API.Models;
using System.Linq;

using Xunit;
using FUCT_API_TEST.Helpers;

namespace FUCT_API_TEST.Models
{
    public class CargueiroRequestTest
    {
        [Fact]
        public void ValidFreighterRequestModel()
        {
            var model = new CargueiroRequest()
            {
                Semana = 2,
                Mes = 3,
                Ano = 2021,
                Tipo = 'A'
            };

            var results = TestModelHelper.Validate(model);

            Assert.Equal(0, results.Count);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(5)]
        public void InvalidWeek(int week)
        {
            var model = new CargueiroRequest()
            {
                Semana = week,
                Mes = 4,
                Ano = 2021,
                Tipo = 'A'
            };

            var results = TestModelHelper.Validate(model);

            Assert.Equal(1, results.Count);
            Assert.Equal("Semana - 1 a 4", results[0].ErrorMessage);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(13)]
        public void InvalidMes(int mes)
        {
            var model = new CargueiroRequest()
            {
                Semana = 2,
                Mes = mes,
                Ano = 2021,
                Tipo = 'A'
            };

            var results = TestModelHelper.Validate(model);

            Assert.Equal(1, results.Count);
            Assert.Equal("Mês - 1 a 12", results[0].ErrorMessage);
        }


    }
}
