using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabReposicion.LZW.Historial
{
    public class Historial
    {
        List<LZW.Compresion.DatosCompresion> ListaCompresion = new List<LZW.Compresion.DatosCompresion>();
        List<LZW.Compresion.DatosDescompresion> ListaDescompresion = new List<LZW.Compresion.DatosDescompresion>();
        List<Resultado> ResultadoList = new List<Resultado>();

        public Historial(List<LZW.Compresion.DatosCompresion> pilacompresion, List<LZW.Compresion.DatosDescompresion> piladescompresion)
        {
            ListaCompresion = pilacompresion;
            ListaDescompresion = piladescompresion;

        }

        public List<Resultado> Anallizar()
        {
            int contador = 1;
            foreach (var item in ListaCompresion)
            {
                var Nombre = item.NombreNuevo;
                int indexDescomprimido = ListaDescompresion.FindIndex(x => x.NombreOrignalComprido.Equals(Nombre));
                if (indexDescomprimido >= 0)
                {
                    Resultado Nuevo = new Resultado();
                    Nuevo.RutaArchivoComprimido = item.Ruta;
                    Nuevo.NombreOriginal = item.NombreOriginal;
                    Nuevo.NombreComprido = item.NombreNuevo;
                    Nuevo.NumeroArchivo = contador;
                    Nuevo.FactorCompresion = Convert.ToDouble(ListaDescompresion[indexDescomprimido].TamañoComprimido) / Convert.ToDouble(item.BytesOriginal);
                    Nuevo.Razoncompresion = Convert.ToDouble(item.BytesOriginal) / Convert.ToDouble(ListaDescompresion[indexDescomprimido].TamañoComprimido);
                    Nuevo.PorcentajeReduccion = 100 - ((Convert.ToDouble(ListaDescompresion[indexDescomprimido].TamañoComprimido) / Convert.ToDouble(item.BytesOriginal)) * 100);
                    ResultadoList.Add(Nuevo);
                    contador++;
                }


            }
            return ResultadoList;


        }








    }
}
