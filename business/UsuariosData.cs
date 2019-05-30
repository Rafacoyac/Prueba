using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace business
{
     public static class UsuariosData
    {
        /// <summary>
        /// Recibe una matricula y regresa un booleano true o false, si existe
        /// </summary>
        /// <param name="Usuario"></param>
        /// <returns>valor booleano</returns>
         
       public static Boolean ExisteUsuarios(int Matricula, string Contra)
        {

           Boolean existe = false;
            
            using (var Contexto = new aplicationEntities1())
            {
                var Resultado = Contexto.Alumnos.Where(x => x.id_Alumnos.Equals(Matricula) && x.contrasena.Equals(Contra)).FirstOrDefault();
                if(Resultado != null)
                    existe = true;
            }
                return existe;
        }
    }
}
