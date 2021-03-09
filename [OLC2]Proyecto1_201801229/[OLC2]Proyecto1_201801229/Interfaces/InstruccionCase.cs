using System;
using System.Collections.Generic;
using System.Text;

namespace _OLC2_Proyecto1_201801229.Interfaces
{
    class InstruccionCase:Instruccion
    {
        LinkedList<Operacion> condicion;
        LinkedList<Instruccion> sentencias;

        public InstruccionCase(LinkedList<Operacion> condicion, LinkedList<Instruccion> sentencias)
        {
            this.condicion = condicion;
            this.sentencias = sentencias;
        }
        public bool Iguales(Object val, TablaSimbolos ts)
        {
            if (condicion != null)
            {
                foreach (Operacion op in condicion)
                {
                    Object va = op.ejecutar(ts);
                    if (val.Equals(va))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public Object ejecutar(TablaSimbolos ts)
        {
            if (sentencias!=null)
            {
                foreach (Instruccion inst in sentencias)
                {
                    inst.ejecutar(ts);
                }
            }
            return null;
        }
    }
}
