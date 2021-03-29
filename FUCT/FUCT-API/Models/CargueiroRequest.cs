using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FUCT_API.Models
{
    public class CargueiroRequest
    {
        [Required(ErrorMessage = "O tipo é obrigatório")]
        public char Tipo { get; set; }

        [Required(ErrorMessage = "O campo semana é obrigatório")]
        [RegularExpression(@"^[1-4]$", ErrorMessage = "Semana - 1 a 4")]
        public int Semana { get; set; }

        [Required(ErrorMessage = "O campo mes é obrigatório")]
        [RegularExpression(@"^([1-9]|1[0-2])$", ErrorMessage = "Mês - 1 a 12")]
        public int Mes { get; set; }

        [Required(ErrorMessage = "O campo ano é obrigatório")]
        public int Ano { get; set; }
    }
}
