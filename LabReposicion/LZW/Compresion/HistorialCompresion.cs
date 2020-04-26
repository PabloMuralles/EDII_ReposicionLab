using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabReposicion.LZW.Compresion
{
    public class HistorialCompresion
    {
        private static HistorialCompresion _instance = null;
        public static HistorialCompresion Instance
        {
            get
            {
                if (_instance == null) _instance = new HistorialCompresion();
                return _instance;
            }
        }

        public List<DatosCompresion> ArchivosComprimidosPila = new List<DatosCompresion>();

        public List<DatosDescompresion> ArchivosDescomprimidosPils = new List<DatosDescompresion>();


    }
}
