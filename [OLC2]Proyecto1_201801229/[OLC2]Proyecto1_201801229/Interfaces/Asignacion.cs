using System;
using System.Collections.Generic;
using System.Text;

namespace _OLC2_Proyecto1_201801229.Interfaces
{
    class Asignacion:Instruccion
    {
        String id;
        Object valor;
        String id_campo;

        public Asignacion(String id, Object valor)
        {
            this.id = id;
            this.valor = valor;
        }
        public Asignacion(String id, Object valor, String id_campo)
        {
            this.id = id;
            this.valor = valor;
            this.id_campo = id_campo;
        }

        public Object ejecutar(TablaSimbolos ts)
        {
            return null;
        }
    }
}
