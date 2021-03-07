using System;
using System.Collections.Generic;
using System.Text;

namespace _OLC2_Proyecto1_201801229.Interfaces
{
    class Asignacion:Instruccion
    {
        String id;
        Operacion valor;
        String id_campo;
        Operacion posicion;

        public Asignacion(String id, Operacion valor)
        {
            this.id = id;
            this.valor = valor;
        }
        public Asignacion(String id, Operacion valor, String id_campo)
        {
            this.id = id;
            this.valor = valor;
            this.id_campo = id_campo;
        }
        public Asignacion(String id, Operacion valor, Operacion posicion)
        {
            this.id = id;
            this.valor = valor;
            this.posicion = posicion;
        }
        public Object ejecutar(TablaSimbolos ts)
        {
            return null;
        }
    }
}
