using System;
using System.Collections.Generic;
using System.Text;

namespace _OLC2_Proyecto1_201801229.Interfaces
{
    class TablaSimbolos : LinkedList<Simbolo>
    {
        public TablaSimbolos() : base()
        { 
        }

        public Object getValor(String buscarSimbolo)
        {
            foreach (Simbolo simbolo in this)
            {
                if (simbolo.Valor.Equals(buscarSimbolo))
                {
                    return simbolo.Valor;
                }
            }
            Console.WriteLine("La variable " + buscarSimbolo + " no se encuentra en este ambito.");
            return "Desconocido";
        }

        public void setValor(String buscarSimbolo, Object valor)
        {
            foreach (Simbolo simbolo in this)
            {
                if (simbolo.Valor.Equals(buscarSimbolo))
                {
                    simbolo.Valor=valor;
                    return;
                }
            }
            Console.WriteLine("La variable " + buscarSimbolo + " no se encuentra en este ambito.");
        }
    }
}
