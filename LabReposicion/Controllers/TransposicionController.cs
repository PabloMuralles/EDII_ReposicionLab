using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabReposicion.Controllers
{
 
    public class TransposicionController : ControllerBase
    {
        [HttpPost]
        [Route("cipher/{nombre}")]
        public ActionResult cipher([FromBody] Transposicion.Datos_C Info, string nombre)
        {
            if (ModelState.IsValid)
            {
                switch ($"{nombre}")
                {

                    case "cesar":
                        Transposicion.Cesar.Instance.CifrarMensaje(Info.fileName, Info.path);
                        break;
                    case "zigzag":
                        Transposicion.ZigZag.Instance.Ingresar(Info.path, Info.carriles, Info.fileName);
                        break;
                    case "Vertical":
                        Transposicion.Ruta_Vertical.Instance.Ingresar(Info.path, Info.filas, Info.fileName);
                        break;
                    case "espiral":
                        Transposicion.Ruta_Espiral.Instance.Ingresar(Info.path, Info.filas, Info.fileName);
                        break;
                    default:
                        //Error                     
                        break;
                }
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("decipher/{nombre}")]
        public ActionResult decipher([FromBody] Transposicion.Datos_C Info, string nombre)
        {
            if (ModelState.IsValid)
            {
                switch ($"{nombre}")
                {

                    case "cesar": 
                        Transposicion.Cesar.Instance.DecifrarMensaje(Info.fileName,Info.path);
                        break;
                    case "zigzag":
                        Transposicion.ZigZag.Instance.IngresarDecifrado(Info.path, Info.carriles, Info.fileName);
                        break;
                    case "Vertical": 
                        Transposicion.Ruta_Vertical.Instance.IngresoDecidrado(Info.path, Info.filas, Info.fileName);
                        break;
                    case "espiral":
                        Transposicion.Ruta_Espiral.Instance.IngresoDecidrado(Info.path, Info.filas, Info.fileName);
                        break;

                    default:
                        //Error                     
                        break;
                }
                return Ok();
            }
            return BadRequest(ModelState);
        }


    }
}