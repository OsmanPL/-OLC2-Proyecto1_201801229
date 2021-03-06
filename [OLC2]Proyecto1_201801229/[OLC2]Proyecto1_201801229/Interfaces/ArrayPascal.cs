using System;
using System.Collections.Generic;
using System.Text;

namespace _OLC2_Proyecto1_201801229.Interfaces
{
    class ArrayPascal:Instruccion
    {
        Object limInferior,limSuperior;
        Object[] arreglo;
        Simbolo.TipoDato tipo;
        String type1;
        String id;

        public ArrayPascal(String id, Operacion limInferior, Operacion limSuperior, Simbolo.TipoDato tipo, String type1)
        {
            this.id = id;
            this.limInferior = limInferior;
            this.limSuperior = limSuperior;
            this.tipo = tipo;
            this.type1 = type1;
        }

        public Object ejecutar(TablaSimbolos ts)
        {
            return null;
        }
    }
}
