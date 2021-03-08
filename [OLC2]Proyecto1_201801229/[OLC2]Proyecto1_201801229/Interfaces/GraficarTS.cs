using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace _OLC2_Proyecto1_201801229.Interfaces
{
    class GraficarTS:Instruccion
    {
        public GraficarTS()
        {

        }
        public Object ejecutar(TablaSimbolos ts)
        {
            foreach (Simbolo sim in ts)
            {
                switch (sim.TipoVar)
                {
                    case Simbolo.TipoVarariable.CONST:
                        MessageBox.Show("Id: "+sim.Id+", Valor: "+sim.Valor.ToString()+", Entorno: "+ts.Entorno,"Constante");
                        break;
                    case Simbolo.TipoVarariable.VAR:
                        MessageBox.Show("Id: " + sim.Id + ", Valor: " + sim.Valor.ToString()+", Tipo: "+sim.Tipo.ToString() + ", Entorno: " + ts.Entorno, "Variable");
                        break;
                }
            }
            return null;
        }
    }
}
