using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _OLC2_Proyecto1_201801229.Interfaces
{
    class Funcion:Instruccion
    {
        String id;
        Simbolo.TipoDato retorno;
        Hashtable parametros = new Hashtable();

        public Funcion(String id, Simbolo.TipoDato retorno,Hashtable parametros)
        {
            this.parametros = parametros;
            this.id = id;
            this.retorno = retorno;
        }

        public Object ejecutar(TablaSimbolos ts)
        {
            return null;
        }
    }
}
