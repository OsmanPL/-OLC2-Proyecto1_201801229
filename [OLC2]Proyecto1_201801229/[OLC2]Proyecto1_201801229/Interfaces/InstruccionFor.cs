using System;
using System.Collections.Generic;
using System.Text;

namespace _OLC2_Proyecto1_201801229.Interfaces
{
    class InstruccionFor:Instruccion
    {
        public enum TipoFor
        {
            INCREMENTO,
            DECREMENTO
        }
        Asignacion asignarValorFor;
        Operacion limite;
        LinkedList<Instruccion> sentencias;
        TipoFor tipo;

        public InstruccionFor(Asignacion asignarValor, Operacion limite, LinkedList<Instruccion> sentencias, TipoFor tipo)
        {
            this.asignarValorFor = asignarValor;
            this.limite = limite;
            this.sentencias = sentencias;
            this.tipo = tipo;
        }
        public Object ejecutar(TablaSimbolos ts)
        {
            return null;
        }
    }
}
