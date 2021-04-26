namespace VeterinariaEdiMvc2021.Windows
{
    partial class frmMedicamentosAE
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
            this.components = new System.ComponentModel.Container();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtCantidadesPorUnidad = new System.Windows.Forms.TextBox();
            this.cboLaboratorio = new System.Windows.Forms.ComboBox();
            this.cboTipoDeMedicamento = new System.Windows.Forms.ComboBox();
            this.txtPrecioDeVenta = new System.Windows.Forms.TextBox();
            this.txtUnidadesEnStock = new System.Windows.Forms.TextBox();
            this.txtNombreComercial = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboFormaFarmaceutica = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNivelDeReposicion = new System.Windows.Forms.TextBox();
            this.chbSuspendido = new System.Windows.Forms.CheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(401, 492);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(134, 38);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(31, 492);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(134, 38);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtCantidadesPorUnidad
            // 
            this.txtCantidadesPorUnidad.Location = new System.Drawing.Point(169, 307);
            this.txtCantidadesPorUnidad.Name = "txtCantidadesPorUnidad";
            this.txtCantidadesPorUnidad.Size = new System.Drawing.Size(366, 20);
            this.txtCantidadesPorUnidad.TabIndex = 8;
            // 
            // cboLaboratorio
            // 
            this.cboLaboratorio.FormattingEnabled = true;
            this.cboLaboratorio.Location = new System.Drawing.Point(169, 144);
            this.cboLaboratorio.Name = "cboLaboratorio";
            this.cboLaboratorio.Size = new System.Drawing.Size(366, 21);
            this.cboLaboratorio.TabIndex = 4;
            // 
            // cboTipoDeMedicamento
            // 
            this.cboTipoDeMedicamento.FormattingEnabled = true;
            this.cboTipoDeMedicamento.Location = new System.Drawing.Point(169, 67);
            this.cboTipoDeMedicamento.Name = "cboTipoDeMedicamento";
            this.cboTipoDeMedicamento.Size = new System.Drawing.Size(366, 21);
            this.cboTipoDeMedicamento.TabIndex = 2;
            // 
            // txtPrecioDeVenta
            // 
            this.txtPrecioDeVenta.Location = new System.Drawing.Point(169, 185);
            this.txtPrecioDeVenta.Name = "txtPrecioDeVenta";
            this.txtPrecioDeVenta.Size = new System.Drawing.Size(366, 20);
            this.txtPrecioDeVenta.TabIndex = 5;
            // 
            // txtUnidadesEnStock
            // 
            this.txtUnidadesEnStock.Location = new System.Drawing.Point(169, 228);
            this.txtUnidadesEnStock.Name = "txtUnidadesEnStock";
            this.txtUnidadesEnStock.Size = new System.Drawing.Size(366, 20);
            this.txtUnidadesEnStock.TabIndex = 6;
            // 
            // txtNombreComercial
            // 
            this.txtNombreComercial.Location = new System.Drawing.Point(169, 26);
            this.txtNombreComercial.Name = "txtNombreComercial";
            this.txtNombreComercial.Size = new System.Drawing.Size(366, 20);
            this.txtNombreComercial.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 355);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Suspendido";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 310);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Cantidades por Unidad";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Unidades en Stock";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 268);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Nivel de Reposiciòn";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Precio de Venta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Laboratorio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Forma Farmacèutica";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Tipo de Medicamento";
            // 
            // cboFormaFarmaceutica
            // 
            this.cboFormaFarmaceutica.FormattingEnabled = true;
            this.cboFormaFarmaceutica.Location = new System.Drawing.Point(169, 106);
            this.cboFormaFarmaceutica.Name = "cboFormaFarmaceutica";
            this.cboFormaFarmaceutica.Size = new System.Drawing.Size(366, 21);
            this.cboFormaFarmaceutica.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Nombre Comercial";
            // 
            // txtNivelDeReposicion
            // 
            this.txtNivelDeReposicion.Location = new System.Drawing.Point(169, 265);
            this.txtNivelDeReposicion.Name = "txtNivelDeReposicion";
            this.txtNivelDeReposicion.Size = new System.Drawing.Size(366, 20);
            this.txtNivelDeReposicion.TabIndex = 7;
            // 
            // chbSuspendido
            // 
            this.chbSuspendido.AutoSize = true;
            this.chbSuspendido.Location = new System.Drawing.Point(169, 354);
            this.chbSuspendido.Name = "chbSuspendido";
            this.chbSuspendido.Size = new System.Drawing.Size(15, 14);
            this.chbSuspendido.TabIndex = 9;
            this.chbSuspendido.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VeterinariaEdiMvc2021.Windows.Properties.Resources.Medicamento;
            this.pictureBox1.Location = new System.Drawing.Point(556, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(246, 504);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // frmMedicamentosAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(814, 554);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.chbSuspendido);
            this.Controls.Add(this.txtCantidadesPorUnidad);
            this.Controls.Add(this.cboLaboratorio);
            this.Controls.Add(this.cboTipoDeMedicamento);
            this.Controls.Add(this.txtPrecioDeVenta);
            this.Controls.Add(this.txtUnidadesEnStock);
            this.Controls.Add(this.txtNombreComercial);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboFormaFarmaceutica);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNivelDeReposicion);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "frmMedicamentosAE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtCantidadesPorUnidad;
        private System.Windows.Forms.ComboBox cboLaboratorio;
        private System.Windows.Forms.ComboBox cboTipoDeMedicamento;
        private System.Windows.Forms.TextBox txtPrecioDeVenta;
        private System.Windows.Forms.TextBox txtUnidadesEnStock;
        private System.Windows.Forms.TextBox txtNombreComercial;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboFormaFarmaceutica;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNivelDeReposicion;
        private System.Windows.Forms.CheckBox chbSuspendido;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}