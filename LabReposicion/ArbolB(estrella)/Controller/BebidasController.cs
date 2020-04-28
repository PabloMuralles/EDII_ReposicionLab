using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LabReposicion.ArbolB_estrella_.Controller
{
    public class BebidasController : ControllerBase
    {
        [HttpPost]
        [Route("api/insertar")]
        public ActionResult Insertar([FromBody] Bebida Soda)
        {
            if (ModelState.IsValid)
            {
                Estructura.ArbolB_Estrella_.Instance.Add(Soda.Nombre, Soda.Sabor, Soda.Volumen, Soda.Precio, Soda.Casa_Productora);
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}