using FUCT_API.Entities;
using FUCT_API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUCT_API_TEST.ServiceMocks
{
    class MineraisServiceMock : IMineraisService
    {
        private List<Minerais> _minerais;

        public MineraisServiceMock()
        {
            _minerais = new List<Minerais>()
            {
                new Minerais()
                {
                      a = 6.3,
                      b = 0.42,
                      c = 1.26,
                      d = 15.75
                },
            };
        }


        public Minerais APIMinerais(int mes, int ano, int semana)
        {
            return _minerais.FirstOrDefault();
        }
    }
}
