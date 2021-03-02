using System;
using System.Collections.Generic;
using System.Text;

namespace _OLC2_Proyecto1_201801229.Interfaces
{
    class InstruccionIf:Instruccion
    {
        Operacion condicion;
        LinkedList<Instruccion> sentencias;
        LinkedList<InstruccionElseIf> listaElseIf;
        InstruccionElse instElse;

        public InstruccionIf(Operacion condicion, LinkedList<Instruccion> sentencias, LinkedList<InstruccionElseIf> listaElseIf, InstruccionElse insElse)
        {
            this.condicion = condicion;
            this.sentencias = sentencias;
            this.listaElseIf = listaElseIf;
            this.instElse = insElse;
        }
        public Object ejecutar(TablaSimbolos ts)
        {
            return null;
        }
    }
}
