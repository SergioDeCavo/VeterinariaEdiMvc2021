namespace VeterinariaEdiMvc2021.Windows
{
    partial class frmMascotas2AE
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
            this.cboTipoDeMascota = new System.Windows.Forms.ComboBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboRaza = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFechaDeNacimiento = new System.Windows.Forms.DateTimePicker();
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
            this.btnCancel.Location = new System.Drawing.Point(385, 486);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(134, 38);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnOK.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(15, 486);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(134, 38);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cboTipoDeMascota
            // 
            this.cboTipoDeMascota.FormattingEnabled = true;
            this.cboTipoDeMascota.Location = new System.Drawing.Point(153, 20);
            this.cboTipoDeMascota.Name = "cboTipoDeMascota";
            this.cboTipoDeMascota.Size = new System.Drawing.Size(366, 21);
            this.cboTipoDeMascota.TabIndex = 0;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(153, 146);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(366, 20);
            this.txtNombre.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Tipo de Mascota";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 149);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Nombre";
            // 
            // cboRaza
            // 
            this.cboRaza.FormattingEnabled = true;
            this.cboRaza.Location = new System.Drawing.Point(153, 58);
            this.cboRaza.Name = "cboRaza";
            this.cboRaza.Size = new System.Drawing.Size(366, 21);
            this.cboRaza.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Raza";
            // 
            // cboCliente
            // 
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(153, 98);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(366, 21);
            this.cboCliente.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Cliente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Fecha de Nacimiento";
            // 
            // dtpFechaDeNacimiento
            // 
            this.dtpFechaDeNacimiento.Location = new System.Drawing.Point(153, 186);
            this.dtpFechaDeNacimiento.Name = "dtpFechaDeNacimiento";
            this.dtpFechaDeNacimiento.Size = new System.Drawing.Size(366, 20);
            this.dtpFechaDeNacimiento.TabIndex = 4;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VeterinariaEdiMvc2021.Windows.Properties.Resources.Mascotas1;
            this.pictureBox1.Location = new System.Drawing.Point(545, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(246, 504);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // frmMascotas2AE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(814, 554);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dtpFechaDeNacimiento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboRaza);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboTipoDeMascota);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "frmMascotas2AE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cboTipoDeMascota;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboRaza;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFechaDeNacimiento;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}