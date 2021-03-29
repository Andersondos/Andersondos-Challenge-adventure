using FUCT_API.Data;
using FUCT_API.Entities;
using FUCT_API.Helpers;
using FUCT_API.Models;
using FUCT_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;



namespace FUCT_API.Services
{
    public class CargueiroService : ICargueiroService
    {
        private DataContext _context;
        private readonly AppSettings _appSettings;

        public CargueiroService( DataContext context,
                                 IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }
        public IEnumerable<Formulario> GetAll()
        {
            return _context.Formularios.ToList();
        }

        public void PostCharge(int quantidadeCargas, char tipo_mineral, DateTime dataInicio)
        {    
            Formulario formulario = new Formulario()
            {
                Quantidade = quantidadeCargas,
                Data_Saida = dataInicio,
                Tipo_minerais = tipo_mineral,
                Status = 0,
                Data_Retorno = null
            };

            _context.Formularios.Add(formulario);
            _context.SaveChanges();
        }

        public Formulario GetCharge(int id)
        {
            Formulario carga = _context.Formularios
                        .Where(fm => fm.Id == id).FirstOrDefault();
            return carga;
        }

        public void RetornoCarga(Formulario carga, double precoFinal)
        {
            DateTime dataRetorno = DateTime.Now;

            carga.Data_Retorno = dataRetorno;
            carga.preco = precoFinal;
            carga.Status = 1;

            _context.Formularios.Update(carga);
            _context.SaveChanges();
        }

        public IEnumerable<Formulario> PagedLoad(int index, int size, string search, string orderBy, string orderType)
        {
            var pagedLoad = new List<Formulario>();
            if (search == null)
            {
                if (orderType == "asc")
                {
                        pagedLoad = _context.Formularios
                            .OrderBy(c => EF.Property<object>(c, orderBy))
                            .Skip(index)
                            .Take(size)
                            .ToList();

                }
                else
                {
                    pagedLoad = _context.Formularios
                            .OrderByDescending(p => EF.Property<object>(p, orderBy))
                            .Skip(index)
                            .Take(size)
                            .ToList();
                }
            }
            else
            {
                if (orderType == "asc")
                {
                    int mes = Convert.ToInt32(search);
                    pagedLoad = _context.Formularios
                        .Where(pv => pv.Data_Saida.Month == mes)
                        .OrderBy(c => EF.Property<object>(c, orderBy))
                        .Skip(index)
                        .Take(size)
                        .ToList();

                }
                else
                {
                    int mes = Convert.ToInt32(search);
                    pagedLoad = _context.Formularios
                            .Where(pv => pv.Data_Saida.Month == mes)
                            .OrderByDescending(p => EF.Property<object>(p, orderBy))
                            .Skip(index)
                            .Take(size)
                            .ToList();
                }
            }
            return pagedLoad;
        }
    }
}
