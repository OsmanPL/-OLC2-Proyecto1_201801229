using System;
using System.Collections.Generic;
using System.Text;

namespace _OLC2_Proyecto1_201801229.Interfaces
{
    class Programa : Instruccion
    {
        LinkedList<Instruccion> sentencias;
        LinkedList<Instruccion> instrucciones;
        public Programa(LinkedList<Instruccion> sentencias , LinkedList<Instruccion> instrucciones)
        {
            this.sentencias = sentencias;
            this.instrucciones = instrucciones;
        }


        public Object ejecutar(TablaSimbolos ts)
        {
            foreach (Instruccion inst in sentencias)
            {
                inst.ejecutar(ts);
            }
            foreach (Instruccion inst in instrucciones)
            {
                inst.ejecutar(ts);
            }
            return null;
        }
    }
}
