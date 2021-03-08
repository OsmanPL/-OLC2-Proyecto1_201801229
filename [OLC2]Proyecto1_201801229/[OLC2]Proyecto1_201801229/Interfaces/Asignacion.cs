using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace _OLC2_Proyecto1_201801229.Interfaces
{
    class Asignacion:Instruccion
    {
        String id;
        Operacion valor;
        String id_campo;
        Operacion posicion;

        public Asignacion(String id, Operacion valor)
        {
            this.id = id;
            this.valor = valor;
            this.posicion = null;
            this.id_campo = "";
        }
        public Asignacion(String id, Operacion valor, String id_campo)
        {
            this.id = id;
            this.valor = valor;
            this.id_campo = id_campo;
            this.posicion = null;
        }
        public Asignacion(String id, Operacion valor, Operacion posicion)
        {
            this.id = id;
            this.valor = valor;
            this.posicion = posicion;
            this.id_campo = "";
        }
        public Object ejecutar(TablaSimbolos ts)
        {
            if (posicion != null)
            {
                
            }
            else if(!id_campo.Equals(""))
            {
                
            }
            else
            {
                Object val = valor.ejecutar(ts);
                Simbolo sim = ts.getSimbolo(id);
                if (sim!=null)
                {
                    try
                    {
                        switch (sim.Tipo)
                        {
                            case Simbolo.TipoDato.BOOLEAN:
                                ts.setValor(id,Boolean.Parse(val.ToString()));
                                break;
                            case Simbolo.TipoDato.OBJECT:
                                ts.setValor(id,val);
                                break;
                            case Simbolo.TipoDato.INTEGER:
                                ts.setValor(id, Int64.Parse(val.ToString()));
                                break;
                            case Simbolo.TipoDato.REAL:
                                ts.setValor(id, Double.Parse(val.ToString()));
                                break;
                            case Simbolo.TipoDato.STRING:
                                ts.setValor(id, val.ToString());
                                break;
                            case Simbolo.TipoDato.IDENTIFICADOR:
                                //ts.AddLast(new Simbolo(id.ToString(), tipo, ((Int64)val)));
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Tipo incorrecto", "Error Semantico");
                    }
                }
                else
                {
                    MessageBox.Show("Simbolo no encontrado", "Error Semantico");
                }
            }
            return null;
        }
    }
}
