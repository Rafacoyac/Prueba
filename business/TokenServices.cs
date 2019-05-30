using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Data;
using Microsoft.IdentityModel.Tokens;

namespace business
{
    public static class TokenServices
    {
        /// <summary>
        /// Generación del token si el usuario se encuentra registrado en la bd
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string GenerateTokenJwt(int user)
        {
           

            var matricula = user.ToString();
            // appsetting for Token JWT
            var secretKey = ConfigurationManager.AppSettings["JWT_SECRET_KEY"];
            var audienceToken = ConfigurationManager.AppSettings["JWT_AUDIENCE_TOKEN"];
            var issuerToken = ConfigurationManager.AppSettings["JWT_ISSUER_TOKEN"];
            var expireTime = DateTime.Now.AddDays(1);

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // create a claimsIdentity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, matricula) });

            // create token to the user
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: audienceToken,
                issuer: issuerToken,
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: expireTime,
                signingCredentials: signingCredentials);

            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);

            aplicationEntities1 contexto = new aplicationEntities1();
         
           
            var tokenDomain = new tokene
            {
                tokeen = jwtTokenString,
                id_alumnosbd = user,
                tokenissued = DateTime.UtcNow,
                tokendeleted = expireTime,
                status = true
            };
            contexto.tokenes.Add(tokenDomain);
            contexto.SaveChanges();

            return jwtTokenString;   
        }




        /// <summary>
        /// validación del token 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static bool ValidarToken(string token)
        {
            using (var contexto = new aplicationEntities1())
            {
                var actual = DateTime.Now;
                
                var tok = contexto.tokenes.Where(x => x.tokeen.Equals(token) && x.tokendeleted > DateTime.Now && x.status.Equals(1)).FirstOrDefault();
                if (tok != null && !(DateTime.Now > tok.tokendeleted))
                {
                    tok.tokendeleted = DateTime.Now.AddDays(1);
                    contexto.Entry(tok).State = System.Data.Entity.EntityState.Modified;
                    contexto.SaveChanges();
                    return true;
                }else
                {
                   var estado= InvalidarToken(token);
                   return estado;

                }
            }
            return false;
        }




        public static bool InvalidarToken(string token)
        {
            using (var Contexto = new aplicationEntities1())
            {
                
                 var id = (from tok in Contexto.tokenes where tok.tokeen.Equals(token) select tok.id_token).FirstOrDefault();
                 var to = (from tok in Contexto.tokenes where tok.tokeen.Equals(token) select tok.tokeen).FirstOrDefault();
                 var id_al = (from tok in Contexto.tokenes where tok.tokeen.Equals(token) select tok.id_alumnosbd).FirstOrDefault();
                 var tokeniss = (from tok in Contexto.tokenes where tok.tokeen.Equals(token) select tok.tokenissued).FirstOrDefault();
                 var tokendel = (from tok in Contexto.tokenes where tok.tokeen.Equals(token) select tok.tokendeleted).FirstOrDefault();
              
                var query = (from t in Contexto.tokenes
                             where t.tokeen == token
                             select t).FirstOrDefault();

                query.id_token = id;
                query.tokeen = to;
                query.id_alumnosbd = id_al;
                query.tokenissued = tokeniss;
                query.tokendeleted = tokendel;
                query.status = false;
               
                Contexto.SaveChanges();
            }
            return false;
        }

    }
}
