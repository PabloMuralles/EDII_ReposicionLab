using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabReposicion.ArbolB_Bebidas
{
    public class Nodo
    {
        public Nodo padre;
        static int grado = 7;
        public Bebidas[] datos = new Bebidas[grado - 1];
        public Nodo[] hijos = new Nodo[grado];

        private static Bebidas BebidaBuscada = new Bebidas();

        public Bebidas Busqueda(string nombre)
        {

            for (int i = 0; i < grado - 1; i++)
            {
                if (datos[i] != null)
                {
                    if (String.Compare(nombre, datos[i].Name) == -1)
                    {
                        if (hijos[0] != null)
                        {
                            hijos[i].Busqueda(nombre);
                        }

                    }

                    if (String.Compare(nombre, datos[i].Name) == 1)
                    {
                        if (hijos[0] != null)
                        {
                            if (datos[i + 1] == null)
                            {
                                hijos[i + 1].Busqueda(nombre);
                            }
                            else
                            {
                                if (String.Compare(nombre, datos[i + 1].Name) == -1)
                                {
                                    hijos[i].Busqueda(nombre);
                                }
                            }
                        }

                    }


                    if (String.Compare(nombre, datos[i].Name) == 0)
                    {
                        BebidaBuscada.Name = datos[i].Name;
                        BebidaBuscada.flavor = datos[i].flavor;
                        BebidaBuscada.inventory = datos[i].inventory;
                        BebidaBuscada.price = datos[i].price;
                        BebidaBuscada.Made = datos[i].Made;

                        break;
                    }
                }
            }
            return BebidaBuscada;
        }
    }
}
