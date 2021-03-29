using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FUCT_API.Entities;
using FUCT_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FUCT_API_TEST.ServiceMocks
{
    class CargueiroServiceMock : ICargueiroService
    {
        private List<Formulario> _formularios;

        public CargueiroServiceMock()
        {
            _formularios = new List<Formulario>()
            {
                new Formulario()
                {
                    Id = 1,
                    Tipo_minerais = 'B',
                    Quantidade = 12,
                    Data_Saida = DateTime.Parse("2021-04-29T18:56:48.0953925-03:00"),
                    Data_Retorno = null,
                    Status = 0,
                    preco = null
                },
                new Formulario()
                {
                    Id = 2,
                    Tipo_minerais = 'A',
                    Quantidade = 2,
                    Data_Saida = DateTime.Parse("2021-03-28T18:56:48.0953925-03:00"),
                    Data_Retorno = null,
                    Status = 0,
                    preco = null
                },
                new Formulario()
                {
                    Id = 3,
                    Tipo_minerais = 'C',
                    Quantidade = 20,
                    Data_Saida = DateTime.Parse("2021-03-26T18:56:48.0953925-03:00"),
                    Data_Retorno =  DateTime.Parse("2021-04-02T18:56:48.0953925-03:00"),
                    Status = 1,
                    preco = null
                }
            };
        }
        public IEnumerable<Formulario> GetAll()
        {
            return _formularios.ToList();
        }

        public Formulario GetCharge(int id)
        {
            Formulario carga = _formularios
                        .Where(fm => fm.Id == id).FirstOrDefault();
            return carga;
        }

        public IEnumerable<Formulario> PagedLoad(int index, int size, string? search, string orderBy, string orderType)
        {
            
            return _formularios;
        }

        public void PostCharge(int QuantidadeCargas, char tipo_mineral, DateTime dataInicio)
        {
            Formulario formulario = new Formulario()
            {
                Quantidade = QuantidadeCargas,
                Data_Saida = dataInicio,
                Tipo_minerais = tipo_mineral,
                Status = 0,
                Data_Retorno = null
            };

            _formularios.Add(formulario);
        }

        public void RetornoCarga(Formulario carga, double precoFinal)
        {
            DateTime dataRetorno = DateTime.Now;

            carga.Data_Retorno = dataRetorno;
            carga.preco = precoFinal;
            carga.Status = 1;

            _formularios.Add(carga);
        }
    }
}
