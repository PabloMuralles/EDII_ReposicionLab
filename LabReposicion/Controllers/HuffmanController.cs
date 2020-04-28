using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace LabReposicion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HuffmanController : ControllerBase
    {
        [HttpPost]
        [Route("compresshuff/{nombre}")]
        public async Task<IActionResult> Post(IFormFile file, string nombre)
        {
            var filePath = Path.GetTempFileName();
            if (file.Length > 0)
                using (var stream = new FileStream(filePath, FileMode.Create))
                    await file.CopyToAsync(stream);

            Huffman.Lectura NuevoArchivo = new Huffman.Lectura(nombre, filePath);
            return Ok();
        }

        [HttpPost]
        [Route("decompresshuff/{nombre}")]
        public async Task<IActionResult> PostDescompresion(IFormFile file, string nombre)
        {
            var filePath = Path.GetTempFileName();
            if (file.Length > 0)
                using (var stream = new FileStream(filePath, FileMode.Create))
                    await file.CopyToAsync(stream);
            Huffman.Descompresion descompresion = new Huffman.Descompresion(nombre, filePath);
            return Ok();

        }









    }
}