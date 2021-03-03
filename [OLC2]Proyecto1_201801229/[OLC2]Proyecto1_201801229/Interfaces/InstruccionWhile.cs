using System;
using System.Collections.Generic;
using System.Text;

namespace _OLC2_Proyecto1_201801229.Interfaces
{
    class InstruccionWhile:Instruccion
    {
        Operacion condicion;
        LinkedList<Instruccion> sentencias;

        public InstruccionWhile(Operacion condicion , LinkedList<Instruccion> sentencias)
        {
            this.condicion = condicion;
            this.sentencias = sentencias;
        }
        public Object ejecutar(TablaSimbolos ts)
        {
            return null;
        }
    }
}
