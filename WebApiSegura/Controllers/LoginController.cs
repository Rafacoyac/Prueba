using System;
using System.Net;
using System.Threading;
using System.Web.Http;
using WebApiSegura.Models;
using WebApiSegura.Security;
using business;
using Data;

namespace WebApiSegura.Controllers
{
    /// <summary>
    /// login controller class for authenticate users
    /// </summary>

    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(UsuarioModel usuario)
        {
            Boolean Existe = false;
            var token = "";

            Existe = UsuariosData.ExisteUsuarios(usuario.Matricula, usuario.Contrasena);
            if (Existe == true)
            {
                token = TokenServices.GenerateTokenJwt(usuario.Matricula);
                return Ok(token);
            }
            return NotFound();
        }

        
        [HttpPost]
        [Route("horariodia")]
        public IHttpActionResult PorDia([FromBody]TokenModel token)
        {
            bool valido = false;

            valido = TokenServices.ValidarToken(token.tokeen);

            if (valido == true)
            {
               
               var consulta = HorarioDiaData.HorarioDia(token.tokeen);
                return Ok(consulta);
            }
            return NotFound();
        }



        [HttpPost]
        [Route("horariosemanal")]
        public IHttpActionResult Semanal([FromBody]TokenModel token)
        {

            bool valido = false;
            
            valido = TokenServices.ValidarToken(token.tokeen);

            if (valido == true)
            {
                var consulta = HorarioSemanalData.HorarioSemanal(token.tokeen);

                return Ok(consulta);
            }
            // Unauthorized access 
            return NotFound();
        }


        [HttpPost]
        [Route("perfil")]
        public IHttpActionResult Perfil([FromBody]TokenModel token)
        {
            bool valido = false;

            valido = TokenServices.ValidarToken(token.tokeen);

            if (valido == true)
            {
                var value=PerfilData.perfil(token.tokeen);
                    return Ok(value);
             }
                
           return NotFound();
        }


        [HttpPost]
        [Route("cerrar")]
        public IHttpActionResult Cerrar(TokenModel token)
        {

            TokenServices.InvalidarToken(token.tokeen);

            return BadRequest();
        }



    }
}
