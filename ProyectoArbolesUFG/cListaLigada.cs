﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoArbolesUFG
{
    class cListaLigada
    {
        private cNodo ancla;

        private cNodo trabajo;

        public cListaLigada()
        {
            ancla = new cNodo();
            ancla.Siguiente = null;
        }

        public int Cantidad()
        {
            int cantidad = 0;

            trabajo = ancla;

            while (trabajo.Siguiente != null)
            {
                trabajo = trabajo.Siguiente;

                cantidad++;
            }

            return cantidad;
        }

        public void Transversa(bool incluirPrecios)
        {
            Console.Clear();

            // Verificar su hay elementos en la lista
            if (Cantidad() > 0)
            {
                float precioTotalPorOrden = 0;
                float precioFinal = 0;


                trabajo = ancla;

                while (trabajo.Siguiente != null)
                {
                    trabajo = trabajo.Siguiente;

                    // Imprimir cada orden con su respectica cantidad
                    Console.Write($"[{trabajo.Cantidad}x] {trabajo.Dato}");

                    // En el caso que se quiere incluir los precios
                    if (incluirPrecios)
                    {
                        precioTotalPorOrden = trabajo.Cantidad * trabajo.Precio;

                        Console.Write($" (Precio unitario ${trabajo.Precio} | Precio total ${precioTotalPorOrden}) ");

                        precioFinal += precioTotalPorOrden;
                    }

                    // Agregar un salto de línea para cada orden impresa. Esto sin importar si se quiere incluir los precios o no
                    Console.Write("\n");
                }

                if (incluirPrecios) Console.WriteLine("\nPrecio final: $" + precioFinal);
            }
            else
            {
                Console.WriteLine("No hay órdenes guardadas.\nPida sus órdenes en la opción 1 en el menú principal!");
            }
        }

        public void Adicionar(cNodo pNodo, int cantidad)
        {
            trabajo = ancla;
            while (trabajo.Siguiente != null)
            {
                trabajo = trabajo.Siguiente;
            }

            pNodo.Cantidad = cantidad;
            pNodo.Siguiente = null;
            trabajo.Siguiente = pNodo;
        }
    }
}