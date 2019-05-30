using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiSegura.Models
{
    public class ListaAlumnoModel
    {
        public int id_ALumnos { get; set; }
        public string nombre { get; set; }
        public int apeP { get; set; }
        public int apeM { get; set; }
        public int grupos { get; set; }
        public int semestre { get; set; }
        public string carrera { get; set; }
     
    }
}