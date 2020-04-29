using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LabReposicion.Controllers
{
    
    public class BebidasArbolBController : ControllerBase
    {

        [HttpPost]
        [Route("api/insert")]

        public ActionResult Create([FromBody] ArbolB_Bebidas.Bebidas Soda)
        {
            if (ModelState.IsValid)
            {
               ArbolB_Bebidas.ArbolB.Instance.Add(Soda.Name, Soda.flavor, Soda.inventory, Soda.price, Soda.Made);

                return Ok();
            }
            return BadRequest(ModelState);
        }


        [HttpGet]
        [Route("api/buscar/{nombre}")]
        public ActionResult Buscar(string nombre)
        {
            if (ModelState.IsValid)
            {
               ArbolB_Bebidas.Bebidas bebida = ArbolB_Bebidas.ArbolB.Instance.Buscar(nombre);
                if (bebida != null)
                    return Ok(bebida);
                return NotFound();
            }
            return BadRequest(ModelState);
        }




        [HttpGet]
        [Route("api/registro")]
        public ActionResult<string> Registro()
        {



            var json = JsonConvert.SerializeObject(ArbolB_Bebidas.ArbolB.Instance.IngresarRetorno());
            return json;


        }




    }
}