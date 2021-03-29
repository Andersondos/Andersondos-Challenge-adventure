using FUCT_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FUCT_API.Services.Interfaces
{
    public interface IMineraisService
    {
        Minerais APIMinerais(int mes, int ano, int semana);
    }
}
