using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _OLC2_Proyecto1_201801229.Analizador;

namespace _OLC2_Proyecto1_201801229
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Cargar_Click(object sender, EventArgs e)
        {

        }

        private void Ejecutar_Click(object sender, EventArgs e)
        {
            GeneradorAST ejecutar = new GeneradorAST();
            if (Traduccion.Text == "")
            {
                ejecutar.analizar(Codigo.Text);
      
            }
            else
            {
                ejecutar.analizar(Traduccion.Text);
            }
        }
    }
}
