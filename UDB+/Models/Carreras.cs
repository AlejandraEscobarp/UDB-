using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UDB_.Models
{
    public class Carreras
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Carrera { get; set; }
        public string Facultad { get; set; }
  
    }
}
