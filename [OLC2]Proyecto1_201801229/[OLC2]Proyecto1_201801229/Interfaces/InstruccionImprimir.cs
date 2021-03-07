using System;
using System.Collections.Generic;
using System.Text;

namespace _OLC2_Proyecto1_201801229.Interfaces
{
    class InstruccionImprimir:Instruccion
    {
        public enum TipoImprimir
        {
            WRITE,
            WRITELN
        }

        TipoImprimir tipo;
        LinkedList<Operacion> datos;

        public InstruccionImprimir(TipoImprimir tipo, LinkedList<Operacion> datos)
        {
            this.tipo = tipo;
            this.datos = datos;
        }
        public Object ejecutar(TablaSimbolos ts)
        {
            return null;
        }
    }
}
