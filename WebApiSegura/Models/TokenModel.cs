using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiSegura.Models
{
    public class TokenModel
    {
        public string tokeen { get; set; }
        public string id_Alumnosbd { get; set; }
        public string tokenissued { get; set; }
        public string tokendeleted { get; set; }

    }
}