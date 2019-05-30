using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business
{
    public class ListaToken
    {
        public int id_token { get; set; }
        public string tokeen { get; set; }
        public int id_alumnosbd { get; set; }
        public DateTime tokenissued { get; set; }
        public  DateTime tokendeleted { get; set; }
        public bool status { get; set; }
    }
}
