using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FUCT_API.Entities
{
    public class Formulario
    {
        [Key]
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public char Tipo_minerais { get; set; }
        public DateTime Data_Saida { get; set; }
        public DateTime? Data_Retorno { get; set; }
        public double? preco { get; set; }
        public int Status { get; set; }

    }
}
