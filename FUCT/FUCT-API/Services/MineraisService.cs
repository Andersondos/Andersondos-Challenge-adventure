using FUCT_API.Data;
using FUCT_API.Entities;
using FUCT_API.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace FUCT_API.Services
{
    public class MineraisService : IMineraisService
    {
        private static string _url;

        private readonly IConfiguration _configuration;

        public MineraisService(IConfiguration configuration)
        {
            _configuration = configuration;

            _url = _configuration.GetValue<string>("Challenge:Url");
        }

        public Minerais APIMinerais(int mes, int ano, int semana)
        {
            var requisicaoWeb = WebRequest.CreateHttp(_url+$"mes={mes}&ano={ano}&semana={semana}"); 
            requisicaoWeb.Method = "GET";
            requisicaoWeb.UserAgent = "RequisicaoWebDemo";
            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                var minerais = JsonSerializer.Deserialize<Minerais>(objResponse.ToString());

                return minerais;
            }
        }
    }
}
