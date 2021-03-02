using System;
using System.Collections.Generic;
using System.Text;

namespace _OLC2_Proyecto1_201801229.Interfaces
{
    class InstruccionSwitch:Instruccion
    {
        Operacion condicion;
        LinkedList<InstruccionCase> listaCase;
        InstruccionElse instElse;

        public InstruccionSwitch(Operacion condicion, LinkedList<InstruccionCase> listaCase, InstruccionElse instElse)
        {
            this.condicion = condicion;
            this.listaCase = listaCase;
            this.instElse = instElse;
        }
        public Object ejecutar(TablaSimbolos ts)
        {
            return null;
        }
    }
}
