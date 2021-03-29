using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FUCT_API.Models
{
    public class pagination
    {
        public int index { get; set; }
        public int size { get; set; }
        public string? search { get; set; }
        public string orderBy { get; set; }
        public string  orderType { get; set; }
    }
}
