using System;
using System.Collections.Generic;
using System.Text;

namespace _OLC2_Proyecto1_201801229.Interfaces
{
    class Simbolo
    {
        private TipoDato tipo;
        private TipoVarariable tipoVar;
        private String id;
        private Object valor;
        private String type;

        public Simbolo(String id, TipoDato tipo, Object valor)
        {
            this.Tipo = tipo;
            this.Id = id;
            this.Valor = valor;
            this.TipoVar = TipoVarariable.VAR;
        }

        public Simbolo(String id, Object valor)
        {
            this.Id = id;
            this.Valor = valor;
            this.TipoVar = TipoVarariable.CONST;
        }

        public Simbolo(String id, TipoDato tipo, Object valor, String type)
        {
            this.Tipo = tipo;
            this.Id = id;
            this.Valor = valor;
            this.TipoVar = TipoVarariable.VAR;
            this.type = type;
        }



        public string Id { get => id; set => id = value; }
        public Object Valor { get => valor; set => valor = value; }
        internal TipoDato Tipo { get => tipo; set => tipo = value; }
        internal TipoVarariable TipoVar { get => tipoVar; set => tipoVar = value; }

        public enum TipoDato
        {
            INTEGER,
            STRING,
            REAL,
            BOOLEAN,
            OBJECT,
            IDENTIFICADOR
        }

        public enum TipoVarariable
        {
            VAR,
            CONST
        }
    }
}
