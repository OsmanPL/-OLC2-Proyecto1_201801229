using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _OLC2_Proyecto1_201801229.Interfaces
{
    class Procedimiento:Instruccion
    {
        String id;
        Hashtable parametros = new Hashtable();

        public Procedimiento(String id, Hashtable parametros)
        {
            this.parametros = parametros;
            this.id = id;
        }

        public Object ejecutar(TablaSimbolos ts)
        {
            return null;
        }
    }
}
