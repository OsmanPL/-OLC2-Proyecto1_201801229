using System;
using System.Collections.Generic;
using System.Text;

namespace _OLC2_Proyecto1_201801229.Interfaces
{
    class InstruccionFor:Instruccion
    {
        Asignacion asignarValorFor;
        Operacion limite;
        LinkedList<Instruccion> sentencias;

        public InstruccionFor(Asignacion asignarValor, Operacion limite, LinkedList<Instruccion> sentencias)
        {
            this.asignarValorFor = asignarValor;
            this.limite = limite;
            this.sentencias = sentencias;
        }
        public Object ejecutar(TablaSimbolos ts)
        {
            return null;
        }
    }
}
