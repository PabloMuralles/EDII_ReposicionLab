using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Newtonsoft.Json;

namespace LabReposicion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompressLZWController : ControllerBase
    {
        
        [HttpPost]
        [Route("compress/LZW/{nombre}")]
        public async Task<IActionResult> Compresion (IFormFile file, string nombre)
        {
            var filePath = Path.GetTempFileName();
            if (file.Length > 0)
                using (var stream = new FileStream(filePath, FileMode.Create))
                    await file.CopyToAsync(stream);
           
            LZW.Lectura.AlgoritomoCompresion Compress = new LZW.Lectura.AlgoritomoCompresion(nombre,file);
            return Ok();

        }

        [HttpPost]
        [Route("decompress/LZW/{nombre}")]
        public async Task<IActionResult> Descompresion(IFormFile file, string nombre)
        {
            var filePath = Path.GetTempFileName();
            if (file.Length > 0)
                using (var stream = new FileStream(filePath, FileMode.Create))
                    await file.CopyToAsync(stream);
            LZW.Lectura.AlgoritmoDescompresion Desscompress = new LZW.Lectura.AlgoritmoDescompresion(file, nombre);
            return Ok();

        }


        [HttpGet]
        [Route("api/compression/LZW")]
        public ActionResult<string> Historial()
        {
            var ListCompresion = LZW.Lectura.HistorialCompresion.Instance.ArchivosComprimidosPila;
            var ListDescomresion = LZW.Lectura.HistorialCompresion.Instance.ArchivosDescomprimidosPils;
            if (ListCompresion == null && ListDescomresion == null)
            {
                return NotFound("No hay datos."); 
            }
            else
            {
                LZW.Historial.Historial Nuevo = new LZW.Historial.Historial(ListCompresion, ListDescomresion);

                var Historial = Nuevo.Anallizar();
                var json = JsonConvert.SerializeObject(Historial);
                return json;


            }
        }


    }
}