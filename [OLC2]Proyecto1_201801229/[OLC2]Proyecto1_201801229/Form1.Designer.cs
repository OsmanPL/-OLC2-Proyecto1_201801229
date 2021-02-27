
namespace _OLC2_Proyecto1_201801229
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Codigo = new System.Windows.Forms.RichTextBox();
            this.Traduccion = new System.Windows.Forms.RichTextBox();
            this.Consola = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Ejecutar = new System.Windows.Forms.Button();
            this.Traducir = new System.Windows.Forms.Button();
            this.Reportes = new System.Windows.Forms.Button();
            this.Cargar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Codigo
            // 
            this.Codigo.Location = new System.Drawing.Point(12, 31);
            this.Codigo.Name = "Codigo";
            this.Codigo.Size = new System.Drawing.Size(437, 302);
            this.Codigo.TabIndex = 0;
            this.Codigo.Text = "";
            // 
            // Traduccion
            // 
            this.Traduccion.Enabled = false;
            this.Traduccion.Location = new System.Drawing.Point(482, 31);
            this.Traduccion.Name = "Traduccion";
            this.Traduccion.Size = new System.Drawing.Size(437, 302);
            this.Traduccion.TabIndex = 1;
            this.Traduccion.Text = "";
            // 
            // Consola
            // 
            this.Consola.Enabled = false;
            this.Consola.Location = new System.Drawing.Point(482, 375);
            this.Consola.Name = "Consola";
            this.Consola.Size = new System.Drawing.Size(437, 302);
            this.Consola.TabIndex = 2;
            this.Consola.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Codigo";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(482, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Traduccion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(482, 357);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Consola";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Ejecutar);
            this.groupBox1.Controls.Add(this.Traducir);
            this.groupBox1.Controls.Add(this.Reportes);
            this.groupBox1.Controls.Add(this.Cargar);
            this.groupBox1.Location = new System.Drawing.Point(12, 357);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(437, 320);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Funciones";
            // 
            // Ejecutar
            // 
            this.Ejecutar.Location = new System.Drawing.Point(249, 199);
            this.Ejecutar.Name = "Ejecutar";
            this.Ejecutar.Size = new System.Drawing.Size(134, 52);
            this.Ejecutar.TabIndex = 14;
            this.Ejecutar.Text = "Ejecutar";
            this.Ejecutar.UseVisualStyleBackColor = true;
            this.Ejecutar.Click += new System.EventHandler(this.Ejecutar_Click);
            // 
            // Traducir
            // 
            this.Traducir.Location = new System.Drawing.Point(46, 199);
            this.Traducir.Name = "Traducir";
            this.Traducir.Size = new System.Drawing.Size(134, 52);
            this.Traducir.TabIndex = 13;
            this.Traducir.Text = "Traducir";
            this.Traducir.UseVisualStyleBackColor = true;
            // 
            // Reportes
            // 
            this.Reportes.Location = new System.Drawing.Point(249, 57);
            this.Reportes.Name = "Reportes";
            this.Reportes.Size = new System.Drawing.Size(134, 52);
            this.Reportes.TabIndex = 12;
            this.Reportes.Text = "Reportes";
            this.Reportes.UseVisualStyleBackColor = true;
            // 
            // Cargar
            // 
            this.Cargar.Location = new System.Drawing.Point(46, 57);
            this.Cargar.Name = "Cargar";
            this.Cargar.Size = new System.Drawing.Size(134, 52);
            this.Cargar.TabIndex = 11;
            this.Cargar.Text = "Cargar Archivo";
            this.Cargar.UseVisualStyleBackColor = true;
            this.Cargar.Click += new System.EventHandler(this.Cargar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 689);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Consola);
            this.Controls.Add(this.Traduccion);
            this.Controls.Add(this.Codigo);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compi Pascal";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox Codigo;
        private System.Windows.Forms.RichTextBox Traduccion;
        private System.Windows.Forms.RichTextBox Consola;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Ejecutar;
        private System.Windows.Forms.Button Traducir;
        private System.Windows.Forms.Button Reportes;
        private System.Windows.Forms.Button Cargar;
    }
}

