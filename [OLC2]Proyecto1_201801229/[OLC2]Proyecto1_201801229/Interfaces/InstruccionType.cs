using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _OLC2_Proyecto1_201801229.Interfaces
{
    class InstruccionType:Instruccion
    {
        String id;
        Hashtable campos = new Hashtable();

        public InstruccionType(String id, Hashtable campos)
        {
            this.id = id;
            this.campos = campos;
        }
        public Object ejecutar(TablaSimbolos ts)
        {
            return null;
        }
    }
}
