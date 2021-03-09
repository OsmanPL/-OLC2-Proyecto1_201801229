using System;
using System.Collections.Generic;
using System.Text;

namespace _OLC2_Proyecto1_201801229.Interfaces
{
    class InstruccionRepeat:Instruccion
    {
        Operacion condicion;
        LinkedList<Instruccion> sentencias;

        public InstruccionRepeat(Operacion condicion, LinkedList<Instruccion> sentencias)
        {
            this.condicion = condicion;
            this.sentencias = sentencias;
        }
        public Object ejecutar(TablaSimbolos ts)
        {
            Boolean cond = true;
            do
            {
                foreach (Instruccion inst in sentencias)
                {
                    if (inst.GetType() == typeof(InstruccionBreak))
                    {
                        return null;
                    }
                    else if (inst.GetType() == typeof(InstruccionContinue))
                    {
                        continue;
                    }
                    inst.ejecutar(ts);
                }
                cond = (Boolean)condicion.ejecutar(ts);
            } while (!cond);
            return null;
        }
    }
}
