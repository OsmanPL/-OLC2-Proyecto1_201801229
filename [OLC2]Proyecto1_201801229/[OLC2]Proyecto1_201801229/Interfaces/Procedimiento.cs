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
        LinkedList<Instruccion> instrucciones;
        LinkedList<Instruccion> sentencias;

        public Procedimiento(String id, Hashtable parametros, LinkedList<Instruccion> instrucciones, LinkedList<Instruccion> sentencias)
        {
            this.parametros = parametros;
            this.id = id;
            this.instrucciones = instrucciones;
            this.sentencias = sentencias;
        }

        public Object ejecutar(TablaSimbolos ts)
        {
            return null;
        }
    }
}
