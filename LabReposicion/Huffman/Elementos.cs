using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabReposicion.Huffman
{
    public class Elementos
    {
        private static Elementos _instance = null;
        public static Elementos Instance
        {
            get
            {
                if (_instance == null) _instance = new Elementos();
                return _instance;
            }
        }
        public char caracter { get; set; }
        public double probabilidad { get; set; }
        public int cantidad { get; set; }
    }
}
