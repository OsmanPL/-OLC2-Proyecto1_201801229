﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _OLC2_Proyecto1_201801229.Interfaces
{
    class Declaracion : Instruccion
    {
        private Object id;
        private Simbolo.TipoDato tipo;
        private Simbolo.TipoVarariable vc;
        private Object valor;
        private String type;
        private bool lista;

        public Declaracion(Object id, Simbolo.TipoDato tipo, Object valor,Simbolo.TipoVarariable vc, String type, bool lista)
        {
            this.id = id;
            this.tipo = tipo;
            this.valor = valor;
            this.vc = vc;
            this.type = type;
            this.lista = lista;
        }

        public Object ejecutar(TablaSimbolos ts)
        {
            return null;
        }
    }
}