﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _OLC2_Proyecto1_201801229.Interfaces
{
    class InstruccionIf:Instruccion
    {
        Operacion condicion;
        LinkedList<Instruccion> sentencias;
        LinkedList<InstruccionElseIf> listaElseIf;
        InstruccionElse instElse;

        public InstruccionIf(Operacion condicion, LinkedList<Instruccion> sentencias, LinkedList<InstruccionElseIf> listaElseIf, InstruccionElse insElse)
        {
            this.condicion = condicion;
            this.sentencias = sentencias;
            this.listaElseIf = listaElseIf;
            this.instElse = insElse;
        }
        public Object ejecutar(TablaSimbolos ts)
        {
            
            if (condicion.ejecutar(ts) != null)
            {
                if ((Boolean)condicion.ejecutar(ts))
                {
                    if (sentencias!=null)
                    {
                        foreach (Instruccion inst in sentencias)
                        {
                            inst.ejecutar(ts);
                        }
                    }
                }
                else
                {
                    bool es = true;
                    if (listaElseIf!=null)
                    {
                        foreach (InstruccionElseIf ei in listaElseIf)
                        {
                            Boolean validar = ei.cond(ts);
                            if (validar)
                            {
                                es = false;
                                ei.ejecutar(ts);
                                break;
                            }
                        }
                    }
                    if (instElse != null)
                    {
                        if (es)
                        {
                            instElse.ejecutar(ts);
                        }
                    }
                }
            }
            return null;
        }
    }
}
