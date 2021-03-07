using System;
using System.Collections.Generic;
using System.Text;

namespace _OLC2_Proyecto1_201801229.Interfaces
{
    class Parametro
    {
        Simbolo.TipoDato tipo;
        Object valor;

        public Parametro(Simbolo.TipoDato tipo, Object valor)
        {
            this.Tipo = tipo;
            this.Valor = valor;
        }

        public object Valor { get => valor; set => valor = value; }
        internal Simbolo.TipoDato Tipo { get => tipo; set => tipo = value; }
    }
}
