using System;
using System.Collections.Generic;
using System.Text;

namespace _OLC2_Proyecto1_201801229.Interfaces
{
    class Operacion : Instruccion
    {
        public enum Tipo_operacion
        {
            SUMA,
            CONCAT,
            RESTA,
            MULTIPLICACION,
            DIVISION,
            MODULAR,
            NEGATIVO,
            NUMERO,
            IDENTIFICADOR,
            CADENA,
            DECIMAL,
            MAYOR_QUE,
            MENOR_QUE,
            AND,
            OR,
            NOT,
            MAYOR_IGUAL_QUE,
            MENOR_IGUAL_QUE,
            IGUAL,
            DIFERENTE,
            LLAMADAPROCEDIMIENTO,
            LLAMADAFUNCION,
            BOOLEAN,
            OBJECT
        }

        private Tipo_operacion tipo;
        private String id;
        private Operacion operadorIzq;
        private Operacion operadorDer;
        private Object valor;

        internal Tipo_operacion Tipo { get => tipo; set => tipo = value; }

        public Operacion()
        {

        }
        public Operacion(Operacion operadorIzq, Operacion operadorDer, Tipo_operacion tipo)
        {
            this.Tipo = tipo;
            this.operadorIzq = operadorIzq;
            this.operadorDer = operadorDer;
        }         
        public Operacion(Operacion operadorIzq, Tipo_operacion tipo)
        {
            this.Tipo = tipo;
            this.operadorIzq = operadorIzq;
        }
        public Operacion(String id, Tipo_operacion tipo)
        {
            this.id = id;
            this.Tipo = tipo;
        }
        public Operacion(String id, Object valor,Tipo_operacion tipo)
        {
            this.id = id;
            this.valor = valor;
            this.Tipo = tipo;
        }
        public Operacion(Object valor, Tipo_operacion tipo)
        {
            this.valor = valor;
            this.Tipo = tipo;
        }


        public Object ejecutar(TablaSimbolos ts) {
            return null;
        }
    }
}
