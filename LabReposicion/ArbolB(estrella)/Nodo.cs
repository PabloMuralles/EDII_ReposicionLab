using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabReposicion.ArbolB_estrella_
{
    public class Nodo
    {
        public int ID { get; set; }

        public int padre { get; set; }

        public Nodo[] hijos { get; set; }
        public Bebida[] values { get; set; }
        public Nodo(int grado, bool posicion)
        {
            if (posicion)
            {
                int valor = ((4 * (grado - 1)) / 3);
                values = new Bebida[valor];
                hijos = new Nodo[grado];
            }
            else
            {
                values = new Bebida[grado - 1];
                hijos = new Nodo[grado];
            }
        }
        private static Bebida BebidaBuscada = new Bebida();

        public Bebida Busqueda(string nombre, int grado)
        {

            for (int i = 0; i < grado - 1; i++)
            {
                if (values[i] != null)
                {
                    if (String.Compare(nombre, values[i].Nombre) == -1)
                    {
                        if (hijos[0] != null)
                        {
                            hijos[i].Busqueda(nombre, grado);
                        }

                    }

                    if (String.Compare(nombre, values[i].Nombre) == 1)
                    {
                        if (hijos[0] != null)
                        {
                            if (values[i + 1] == null)
                            {
                                hijos[i + 1].Busqueda(nombre, grado);
                            }
                            else
                            {
                                if (String.Compare(nombre, values[i + 1].Nombre) == -1)
                                {
                                    hijos[i].Busqueda(nombre, grado);
                                }
                            }
                        }

                    }


                    if (String.Compare(nombre, values[i].Nombre) == 0)
                    {
                        BebidaBuscada.Nombre = values[i].Nombre;
                        BebidaBuscada.Sabor = values[i].Sabor;
                        BebidaBuscada.Volumen = values[i].Volumen;
                        BebidaBuscada.Precio = values[i].Precio;
                        BebidaBuscada.Casa_Productora = values[i].Casa_Productora;

                        break;
                    }
                }
            }
            return BebidaBuscada;
        }

    }
}
