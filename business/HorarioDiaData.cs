using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace business
{
    public class HorarioDiaData
    {
        public static List<ListaHorarioDia> HorarioDia(string token)
        {
            string dia;

            var day = DateTime.Now.DayOfWeek.ToString();

            if (day == "Monday")
            {
                dia = "Lunes";
            }
            else if (day == "Tuesday")
            {
                dia = "Martes";
            }
            else if (day == "Wednesday")
            {
                dia = "Miercoles";
            }
            else if (day == "Thursday")
            {
                dia = "Jueves";
            }
            else if (day == "Friday")
            {
                dia = "Viernes";
            }
            else
            {
                dia = "Sabado";
            }

            using (var Contexto = new aplicationEntities1())
            {
                    var Resultado = (from car in Contexto.Carreras join al in Contexto.Alumnos on car.id_Carreras equals al.id_Carreras
                                     join ho in Contexto.Horarios on al.id_Alumnos equals ho.id_Alumnos
                                     join ma_mat in Contexto.Maestro_Materia on ho.maestroMateria equals ma_mat.maestroMateria
                                     join maes in Contexto.Maestros on ma_mat.id_Maestro equals maes.id_Maestro
                                     join mat in Contexto.Materias on ma_mat.claveMateria equals mat.claveMateria
                                     join tok in Contexto.tokenes on al.id_Alumnos equals tok.id_alumnosbd
                                     where tok.tokeen.Equals(token) && mat.dia.Equals(dia)
                                     select new ListaHorarioDia
                                     {
                                         salon = ho.Salones,
                                         mat = mat.materias,
                                         horain = mat.horainicio,
                                         horafin = mat.horafin,
                                         estud = maes.Estudios,
                                         nom = maes.nombre,
                                         ap = maes.apeP,
                                         am = maes.apeM
                                     }).ToList();


                    return Resultado;
            }
           
        }
    }
}
