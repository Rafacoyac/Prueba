using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace business
{
    public class PerfilData
    { 
        public static List<ListaPerfil> perfil(string token)
        {
            
            using (var Contexto = new aplicationEntities1())
            {
               
                var Resultado = (from al in Contexto.Alumnos
                                  join ca in Contexto.Carreras
                                  on al.id_Carreras equals ca.id_Carreras
                                  join tok in Contexto.tokenes on al.id_Alumnos equals tok.id_alumnosbd
                                  where tok.tokeen.Equals(token)
                                  select new ListaPerfil {id=al.id_Alumnos, nom=al.nombre, ap=al.apeP,
                                  am =al.apeM,sem=al.semestre, gru=al.Grupos, car=ca.Carreras }).ToList();
                return Resultado;
            } 
            
        }
        
    }
}
