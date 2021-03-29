using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FUCT_API.Services.Interfaces;
using System.Net;
using System.IO;
using System.Text.Json;
using FUCT_API.Entities;
using FUCT_API.Models;

namespace FUCT_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CargueiroController : ControllerBase
    {
        private ICargueiroService _CagueiroService;
        private IMineraisService _mineraisService;

        public CargueiroController(ICargueiroService cargueiroService,
                                   IMineraisService mineraisService)
        {
            _CagueiroService = cargueiroService;
            _mineraisService = mineraisService;

        }

        [HttpGet]
        public IActionResult GetForms()
        {
            try
            {
                var formulario = _CagueiroService.GetAll();

                return Ok(formulario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("table")]
        public IActionResult GetTablePagination(int index, int size, string search, string orderBy, string orderType)
        {
            try
            {

                if(index > 0)
                    index *= size;

                var cargaPaginada = _CagueiroService.PagedLoad(index, size, search, orderBy, orderType);

                return Ok(cargaPaginada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       [HttpPost]
       public IActionResult StartCharge(CargueiroRequest cargueiroSaida)
        {
            try
            {
                DateTime dataInicio = DateTime.Now;
                if (dataInicio.Hour < 8)
                    throw new Exception("Segundo regras Codex Interestelar do Comércio, nenhum cargueiro poderá registrar saída antes das 08:00 AM (GMT)");

                var minerais = _mineraisService.APIMinerais(cargueiroSaida.Mes, cargueiroSaida.Ano, cargueiroSaida.Semana);

                switch (char.ToUpper(cargueiroSaida.Tipo))
                {
                    case 'A':
                        int total_Inflamavel = (int)Math.Ceiling(minerais.a / 3);
                        _CagueiroService.PostCharge(total_Inflamavel, 'A', dataInicio);
                        break;
                    case 'B':
                        int total_RiscoBiologico = (int)Math.Ceiling(minerais.b / 0.5);
                        _CagueiroService.PostCharge(total_RiscoBiologico, 'B', dataInicio);
                        break;
                    case 'C':
                        int total_Refrigerado = (int)Math.Ceiling(minerais.c / 2);
                        _CagueiroService.PostCharge(total_Refrigerado, 'C', dataInicio);
                        break;
                    case 'D':
                        int total_Outros = (int)Math.Ceiling(minerais.d / 5);
                        _CagueiroService.PostCharge(total_Outros, 'D', dataInicio);
                        break;
                    default:
                        throw new Exception("Tipo de Carga inválida");
                }

                return Ok(new { Message = "Saída registrada com sucesso" });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
          
       }

        [HttpPut]
        public IActionResult LoadReturn(int id)
        {
            try 
            {             
                var carga = _CagueiroService.GetCharge(id);
                double precoFinal = new double();

                switch (carga.Tipo_minerais)
                {
                    case 'A':
                        precoFinal = carga.Quantidade * 5000;
                        break;
                    case 'B':
                         precoFinal = carga.Quantidade * 10000;
                        break;
                    case 'C':
                        precoFinal = carga.Quantidade * 3000;
                        break;
                    case 'D':
                        precoFinal = carga.Quantidade * 1000;
                        break;
                }

                _CagueiroService.RetornoCarga(carga, precoFinal);

                return Ok(new { Message = "Retorno registrado com sucesso" });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
