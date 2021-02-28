using System;
using System.Collections.Generic;
using System.Text;

namespace _OLC2_Proyecto1_201801229.Interfaces
{
    class ArrayPascal:Instruccion
    {
        Operacion limInferior,limSuperior;
        Object[] arreglo;
        Simbolo.TipoDato tipo;
        String type;
        String id;

        public ArrayPascal(String id, Operacion limInferior, Operacion limSuperior, Simbolo.TipoDato tipo, String type)
        {
            this.id = id;
            this.limInferior = limInferior;
            this.limSuperior = limSuperior;
            this.tipo = tipo;
            this.type = type;
        }
        public Object ejecutar(TablaSimbolos ts)
        {
            return null;
        }
    }
}
