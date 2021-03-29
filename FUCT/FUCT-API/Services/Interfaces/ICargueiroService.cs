using FUCT_API.Entities;
using FUCT_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FUCT_API.Services.Interfaces
{
    public interface ICargueiroService
    {
        IEnumerable<Formulario> GetAll();
        void PostCharge(int quatidadeCargas, char minerais, DateTime dataInicio);
        Formulario GetCharge(int id);
        void RetornoCarga(Formulario carga, double precoFinal);
        IEnumerable<Formulario> PagedLoad(int index, int size, string search, string orderBy, string orderType);
    }
}
