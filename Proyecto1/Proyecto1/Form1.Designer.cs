namespace Proyecto1
{
    partial class frmCalculadora
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPorciento = new System.Windows.Forms.Button();
            this.txtResultados = new System.Windows.Forms.TextBox();
            this.btnRaiz = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btnDivision = new System.Windows.Forms.Button();
            this.btnCuadrado = new System.Windows.Forms.Button();
            this.btnCE = new System.Windows.Forms.Button();
            this.btnC = new System.Windows.Forms.Button();
            this.btnMultiplica = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btnSuma = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btnPunto = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.btnSignos = new System.Windows.Forms.Button();
            this.btnResta = new System.Windows.Forms.Button();
            this.btnResultados = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPorciento
            // 
            this.btnPorciento.Location = new System.Drawing.Point(105, 106);
            this.btnPorciento.Name = "btnPorciento";
            this.btnPorciento.Size = new System.Drawing.Size(40, 25);
            this.btnPorciento.TabIndex = 0;
            this.btnPorciento.Text = "%";
            this.btnPorciento.UseVisualStyleBackColor = true;
            // 
            // txtResultados
            // 
            this.txtResultados.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResultados.Location = new System.Drawing.Point(13, 40);
            this.txtResultados.Multiline = true;
            this.txtResultados.Name = "txtResultados";
            this.txtResultados.ReadOnly = true;
            this.txtResultados.Size = new System.Drawing.Size(178, 29);
            this.txtResultados.TabIndex = 1;
            this.txtResultados.Text = "0";
            this.txtResultados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnRaiz
            // 
            this.btnRaiz.Location = new System.Drawing.Point(12, 75);
            this.btnRaiz.Name = "btnRaiz";
            this.btnRaiz.Size = new System.Drawing.Size(40, 25);
            this.btnRaiz.TabIndex = 2;
            this.btnRaiz.Text = "√";
            this.btnRaiz.UseVisualStyleBackColor = true;
            // 
            // btn9
            // 
            this.btn9.Location = new System.Drawing.Point(105, 137);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(40, 25);
            this.btn9.TabIndex = 3;
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = true;
            this.btn9.Click += new System.EventHandler(this.AgregarNumero);
            // 
            // btn8
            // 
            this.btn8.Location = new System.Drawing.Point(59, 137);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(40, 25);
            this.btn8.TabIndex = 4;
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = true;
            this.btn8.Click += new System.EventHandler(this.AgregarNumero);
            // 
            // btn7
            // 
            this.btn7.Location = new System.Drawing.Point(13, 137);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(40, 25);
            this.btn7.TabIndex = 5;
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = true;
            this.btn7.Click += new System.EventHandler(this.AgregarNumero);
            // 
            // btnDivision
            // 
            this.btnDivision.Location = new System.Drawing.Point(151, 106);
            this.btnDivision.Name = "btnDivision";
            this.btnDivision.Size = new System.Drawing.Size(40, 25);
            this.btnDivision.TabIndex = 6;
            this.btnDivision.Text = "÷";
            this.btnDivision.UseVisualStyleBackColor = true;
            this.btnDivision.Click += new System.EventHandler(this.btnDivision_Click);
            // 
            // btnCuadrado
            // 
            this.btnCuadrado.Location = new System.Drawing.Point(58, 75);
            this.btnCuadrado.Name = "btnCuadrado";
            this.btnCuadrado.Size = new System.Drawing.Size(40, 25);
            this.btnCuadrado.TabIndex = 9;
            this.btnCuadrado.Text = "x²";
            this.btnCuadrado.UseVisualStyleBackColor = true;
            // 
            // btnCE
            // 
            this.btnCE.Location = new System.Drawing.Point(13, 106);
            this.btnCE.Name = "btnCE";
            this.btnCE.Size = new System.Drawing.Size(40, 25);
            this.btnCE.TabIndex = 10;
            this.btnCE.Text = "CE";
            this.btnCE.UseVisualStyleBackColor = true;
            this.btnCE.Click += new System.EventHandler(this.btnCE_Click);
            // 
            // btnC
            // 
            this.btnC.Location = new System.Drawing.Point(59, 106);
            this.btnC.Name = "btnC";
            this.btnC.Size = new System.Drawing.Size(40, 25);
            this.btnC.TabIndex = 11;
            this.btnC.Text = "C";
            this.btnC.UseVisualStyleBackColor = true;
            this.btnC.Click += new System.EventHandler(this.btnC_Click);
            // 
            // btnMultiplica
            // 
            this.btnMultiplica.Location = new System.Drawing.Point(151, 137);
            this.btnMultiplica.Name = "btnMultiplica";
            this.btnMultiplica.Size = new System.Drawing.Size(40, 25);
            this.btnMultiplica.TabIndex = 12;
            this.btnMultiplica.Text = "x";
            this.btnMultiplica.UseVisualStyleBackColor = true;
            this.btnMultiplica.Click += new System.EventHandler(this.btnMultiplica_Click);
            // 
            // btn3
            // 
            this.btn3.Location = new System.Drawing.Point(105, 199);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(40, 25);
            this.btn3.TabIndex = 13;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.AgregarNumero);
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(59, 199);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(40, 25);
            this.btn2.TabIndex = 14;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.AgregarNumero);
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(13, 199);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(40, 25);
            this.btn1.TabIndex = 15;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.AgregarNumero);
            // 
            // btnSuma
            // 
            this.btnSuma.Location = new System.Drawing.Point(151, 199);
            this.btnSuma.Name = "btnSuma";
            this.btnSuma.Size = new System.Drawing.Size(40, 25);
            this.btnSuma.TabIndex = 16;
            this.btnSuma.Text = "+";
            this.btnSuma.UseVisualStyleBackColor = true;
            this.btnSuma.Click += new System.EventHandler(this.btnSuma_Click);
            // 
            // btn6
            // 
            this.btn6.Location = new System.Drawing.Point(105, 168);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(40, 25);
            this.btn6.TabIndex = 17;
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = true;
            this.btn6.Click += new System.EventHandler(this.AgregarNumero);
            // 
            // btn5
            // 
            this.btn5.Location = new System.Drawing.Point(59, 168);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(40, 25);
            this.btn5.TabIndex = 18;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.AgregarNumero);
            // 
            // btn4
            // 
            this.btn4.Location = new System.Drawing.Point(13, 168);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(40, 25);
            this.btn4.TabIndex = 19;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.AgregarNumero);
            // 
            // btnPunto
            // 
            this.btnPunto.Location = new System.Drawing.Point(105, 230);
            this.btnPunto.Name = "btnPunto";
            this.btnPunto.Size = new System.Drawing.Size(40, 25);
            this.btnPunto.TabIndex = 20;
            this.btnPunto.Text = ".";
            this.btnPunto.UseVisualStyleBackColor = true;
            this.btnPunto.Click += new System.EventHandler(this.btnPunto_Click);
            // 
            // btn0
            // 
            this.btn0.Location = new System.Drawing.Point(59, 230);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(40, 25);
            this.btn0.TabIndex = 21;
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = true;
            this.btn0.Click += new System.EventHandler(this.AgregarNumero);
            // 
            // btnSignos
            // 
            this.btnSignos.Location = new System.Drawing.Point(12, 230);
            this.btnSignos.Name = "btnSignos";
            this.btnSignos.Size = new System.Drawing.Size(40, 25);
            this.btnSignos.TabIndex = 22;
            this.btnSignos.Text = "±";
            this.btnSignos.UseVisualStyleBackColor = true;
            this.btnSignos.Click += new System.EventHandler(this.btnSignos_Click);
            // 
            // btnResta
            // 
            this.btnResta.Location = new System.Drawing.Point(151, 168);
            this.btnResta.Name = "btnResta";
            this.btnResta.Size = new System.Drawing.Size(40, 25);
            this.btnResta.TabIndex = 23;
            this.btnResta.Text = "-";
            this.btnResta.UseVisualStyleBackColor = true;
            this.btnResta.Click += new System.EventHandler(this.btnResta_Click);
            // 
            // btnResultados
            // 
            this.btnResultados.Location = new System.Drawing.Point(151, 230);
            this.btnResultados.Name = "btnResultados";
            this.btnResultados.Size = new System.Drawing.Size(40, 25);
            this.btnResultados.TabIndex = 24;
            this.btnResultados.Text = "=";
            this.btnResultados.UseVisualStyleBackColor = true;
            this.btnResultados.Click += new System.EventHandler(this.btnResultados_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(197, 75);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(143, 180);
            this.progressBar1.TabIndex = 25;
            // 
            // btnMostrar
            // 
            this.btnMostrar.Location = new System.Drawing.Point(105, 75);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(86, 25);
            this.btnMostrar.TabIndex = 26;
            this.btnMostrar.Text = "Mostrar Resultados";
            this.btnMostrar.UseVisualStyleBackColor = true;
            // 
            // frmCalculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(369, 266);
            this.Controls.Add(this.btnMostrar);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnResultados);
            this.Controls.Add(this.btnResta);
            this.Controls.Add(this.btnSignos);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.btnPunto);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btnSuma);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btnMultiplica);
            this.Controls.Add(this.btnC);
            this.Controls.Add(this.btnCE);
            this.Controls.Add(this.btnCuadrado);
            this.Controls.Add(this.btnDivision);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btnRaiz);
            this.Controls.Add(this.txtResultados);
            this.Controls.Add(this.btnPorciento);
            this.Name = "frmCalculadora";
            this.Text = "Calculadora";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPorciento;
        private System.Windows.Forms.TextBox txtResultados;
        private System.Windows.Forms.Button btnRaiz;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btnDivision;
        private System.Windows.Forms.Button btnCuadrado;
        private System.Windows.Forms.Button btnCE;
        private System.Windows.Forms.Button btnC;
        private System.Windows.Forms.Button btnMultiplica;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btnSuma;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btnPunto;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btnSignos;
        private System.Windows.Forms.Button btnResta;
        private System.Windows.Forms.Button btnResultados;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnMostrar;
    }
}

