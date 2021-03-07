using System;
using System.Collections.Generic;
using System.Text;

namespace _OLC2_Proyecto1_201801229.Interfaces
{
    class ParametroFP
    {
        public enum TipoValor
        {
            REFERENCIA,
            VALOR
        }
        Simbolo.TipoDato tipo;
        String type;
        TipoValor rv;
        Object valor;
        String refe;

        internal Simbolo.TipoDato Tipo { get => tipo; set => tipo = value; }
        public string Type { get => type; set => type = value; }
        internal TipoValor Rv { get => rv; set => rv = value; }
        internal Object Valor { get => valor; set => valor = value; }
        public string Refe { get => refe; set => refe = value; }

        public ParametroFP(Simbolo.TipoDato tipo, String type, TipoValor rv)
        {
            this.tipo = tipo;
            this.type = type;
            this.rv = rv;
        }
    }
}
