using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LabReposicion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RSAController : ControllerBase
    {

        [HttpGet]
        [Route("cipher/getPublicKey")]
        public ActionResult<string> Insertar([FromBody] RSA.Informacion Info)
        {
            if (ModelState.IsValid)
            {
                RSA.RSA Llaves = new RSA.RSA();

                var json = JsonConvert.SerializeObject(Llaves.Llaves);
                return json;


            }
            return BadRequest(ModelState);
        }


        [HttpPost]
        [Route("cipher/caesar2")]
        public ActionResult Cipher([FromBody] RSA.Informacion Info)
        {
            if (ModelState.IsValid)
            {

                RSA.Descifrar.Instance.CifrarDocumento(Info.RutaArchivo, Info.NombreArchivo, Info.RutaLlave);
                return Ok();

            }
            return BadRequest(ModelState);





        }

        [HttpPost]
        [Route("Decipher/caesar2")]
        public ActionResult Decipher([FromBody] RSA.Informacion Info)
        {
            if (ModelState.IsValid)
            {

                RSA.Descifrar.Instance.DescifrarDocumentos(Info.RutaArchivo, Info.NombreArchivo, Info.RutaLlave);


                return Ok();

            }
            return BadRequest(ModelState);


        }






    }
}