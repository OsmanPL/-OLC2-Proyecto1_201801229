using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Irony;
using Irony.Parsing;
using System.Text;
using _OLC2_Proyecto1_201801229.Interfaces;
using Irony.Ast;
using System.Windows.Forms;
namespace _OLC2_Proyecto1_201801229.Analizador
{
    class Reporte
    {
        int i = 0;
        public void graficarArbol(ParseTreeNode raiz)
        {
            String arbolAST = "digraph ArbolAST{\n";
            arbolAST += ast(i,raiz);
            arbolAST += "}";
            Graficador graficar = new Graficador();
            graficar.graficar(arbolAST);
        }

        private String ast(int j, ParseTreeNode actual)
        {
            String grafica="id"+j +"[label=\""+actual.ToString()+"\"];\n";
            i++;
            for (int n=0;n<actual.ChildNodes.Count;n++)
            {
                grafica += "id" + j + " -> id" + i+";\n";
                grafica += ast(i,actual.ChildNodes.ElementAt(n));
            }
            return grafica;
        }
    }
}
