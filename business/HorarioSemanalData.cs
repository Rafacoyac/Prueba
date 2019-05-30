using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace business
{
    public class HorarioSemanalData
    {
        public static List<ListaHorarioSemanal> HorarioSemanal(string token)
        {
               using (var Contexto = new aplicationEntities1())
                {
                    var Resultado = (from car in Contexto.Carreras
                                     join al in Contexto.Alumnos on car.id_Carreras equals al.id_Carreras
                                     join ho in Contexto.Horarios on al.id_Alumnos equals ho.id_Alumnos
                                     join ma_mat in Contexto.Maestro_Materia on ho.maestroMateria equals ma_mat.maestroMateria
                                     join maes in Contexto.Maestros on ma_mat.id_Maestro equals maes.id_Maestro
                                     join mat in Contexto.Materias on ma_mat.claveMateria equals mat.claveMateria
                                     join tok in Contexto.tokenes on al.id_Alumnos equals tok.id_alumnosbd
                                     where tok.tokeen.Equals(token)
                                     select new ListaHorarioSemanal
                                     {
                                         estudios = maes.Estudios,
                                         nombre = maes.nombre,
                                         apep = maes.apeP,
                                         apem = maes.apeM,
                                         salon = ho.Salones,
                                         materia = mat.materias,
                                         dia = mat.dia,
                                         horain = mat.horainicio,
                                         horafin = mat.horafin,
                                         credito = mat.creditos,
                                         clavemat = mat.claveMateria,
                                         opcioncur = al.OpcionCurso
                                     }).ToList();


                    return Resultado;
                }
            }
        }
}
