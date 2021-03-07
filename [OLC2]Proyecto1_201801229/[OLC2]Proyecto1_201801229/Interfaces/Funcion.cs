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
        String type;
        Hashtable parametros;
        LinkedList<Instruccion> instrucciones;
        LinkedList<Instruccion> sentencias;

        public Funcion(String id, Simbolo.TipoDato retorno,Hashtable parametros, LinkedList<Instruccion> instrucciones,LinkedList<Instruccion> sentencias, String type)
        {
            this.parametros = parametros;
            this.id = id;
            this.retorno = retorno;
            this.instrucciones = instrucciones;
            this.sentencias = sentencias;
            this.type = type;
        }

        public Object ejecutar(TablaSimbolos ts)
        {
            return null;
        }
    }
}
