using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LabReposicion.Controller
{
    public class BebidasController : ControllerBase
    {
        [HttpPost]
        [Route("Bebida/insertar")]
        public ActionResult Insertar([FromBody] ArbolB_estrella_.Bebida Soda)
        {
            if (ModelState.IsValid)
            {
                ArbolB_estrella_.Estructura.ArbolB_estrella_.Instance.Insertar(Soda.Nombre, Soda.Sabor, Soda.Volumen, Soda.Precio, Soda.Casa_Productora);
                return Ok();
            }
            return BadRequest(ModelState);
        }
        [HttpGet]
        [Route("Bebida/registro")]
        public ActionResult<string> Registro()
        {
            var json = JsonConvert.SerializeObject(ArbolB_estrella_.Estructura.ArbolB_estrella_.Instance.IngresarRetorno());
           return json;

        }
        [HttpPost]
        [Route("Bebida/Buscar")]
        public ActionResult Buscar(string nombre)
        {
            if (ModelState.IsValid)
            {
                ArbolB_estrella_.Bebida bebida = ArbolB_estrella_.Estructura.ArbolB_estrella_.Instance.Busqueda(nombre);
                if (bebida != null)
                    return Ok(bebida);
                return NotFound();
            }
            return BadRequest(ModelState);
        }
    }
}