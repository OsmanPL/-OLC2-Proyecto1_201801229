using System;
using System.Collections.Generic;
using System.Text;

namespace _OLC2_Proyecto1_201801229.Interfaces
{
    class ArrayPascal:Instruccion
    {

        public enum TipoArray
        {
            Op_Op,
            T_Op,
            Op_T,
            T_T
        }
        Object limInferior,limSuperior, topeinf, topesup;
        Object arreglo;
        Simbolo.TipoDato tipo;
        Simbolo.TipoDato tipoarr;
        TipoArray tipoOperacion;
        String type1;
        String type2;
        String id;

        public ArrayPascal(String id, Operacion limInferior, Operacion limSuperior, Simbolo.TipoDato tipo, String type1, TipoArray tipoOperacion)
        {
            this.id = id;
            this.limInferior = limInferior;
            this.limSuperior = limSuperior;
            this.tipo = tipo;
            this.type1 = type1;
            this.tipoOperacion = tipoOperacion;
        }
        public ArrayPascal(String id, Operacion limInferior, Operacion limSuperior, Operacion topeinf, Operacion topesup, TipoArray tipoOperacion)
        {
            this.id = id;
            this.limInferior = limInferior;
            this.limSuperior = limSuperior;
            this.topeinf = topeinf;
            this.topesup = topesup;
            this.tipoOperacion = tipoOperacion;
        }

        public ArrayPascal(String id,Simbolo.TipoDato tipoarr, Simbolo.TipoDato tipo, String type1, TipoArray tipoOperacion, String type2)
        {
            this.id = id;
            this.tipoarr = tipoarr;
            this.tipo = tipo;
            this.type1 = type1;
            this.type2 = type2;
            this.tipoOperacion = tipoOperacion;
        }

        public Object ejecutar(TablaSimbolos ts)
        {
            return null;
        }
    }
}
