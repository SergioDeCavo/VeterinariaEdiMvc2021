namespace VeterinariaEdiMvc2021.Windows
{
    partial class frmEmpleadosAE
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
            this.txtCorreoElectronico = new System.Windows.Forms.TextBox();
            this.txtTelefonoMovil = new System.Windows.Forms.TextBox();
            this.txtTelefonoFijo = new System.Windows.Forms.TextBox();
            this.cboLocalidad = new System.Windows.Forms.ComboBox();
            this.cboProvincia = new System.Windows.Forms.ComboBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtNumeroDocumento = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTipoDeDocumento = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboTipoDeTarea = new System.Windows.Forms.ComboBox();
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
            this.btnCancel.Location = new System.Drawing.Point(398, 488);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(134, 38);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(28, 488);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(134, 38);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtCorreoElectronico
            // 
            this.txtCorreoElectronico.Location = new System.Drawing.Point(166, 394);
            this.txtCorreoElectronico.Name = "txtCorreoElectronico";
            this.txtCorreoElectronico.Size = new System.Drawing.Size(366, 20);
            this.txtCorreoElectronico.TabIndex = 10;
            // 
            // txtTelefonoMovil
            // 
            this.txtTelefonoMovil.Location = new System.Drawing.Point(166, 348);
            this.txtTelefonoMovil.Name = "txtTelefonoMovil";
            this.txtTelefonoMovil.Size = new System.Drawing.Size(366, 20);
            this.txtTelefonoMovil.TabIndex = 9;
            // 
            // txtTelefonoFijo
            // 
            this.txtTelefonoFijo.Location = new System.Drawing.Point(166, 303);
            this.txtTelefonoFijo.Name = "txtTelefonoFijo";
            this.txtTelefonoFijo.Size = new System.Drawing.Size(366, 20);
            this.txtTelefonoFijo.TabIndex = 8;
            // 
            // cboLocalidad
            // 
            this.cboLocalidad.FormattingEnabled = true;
            this.cboLocalidad.Location = new System.Drawing.Point(166, 261);
            this.cboLocalidad.Name = "cboLocalidad";
            this.cboLocalidad.Size = new System.Drawing.Size(366, 21);
            this.cboLocalidad.TabIndex = 7;
            // 
            // cboProvincia
            // 
            this.cboProvincia.FormattingEnabled = true;
            this.cboProvincia.Location = new System.Drawing.Point(166, 219);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Size = new System.Drawing.Size(366, 21);
            this.cboProvincia.TabIndex = 6;
            this.cboProvincia.SelectedIndexChanged += new System.EventHandler(this.cboProvincia_SelectedIndexChanged);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(166, 181);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(366, 20);
            this.txtDireccion.TabIndex = 5;
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Location = new System.Drawing.Point(166, 140);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Size = new System.Drawing.Size(366, 20);
            this.txtNumeroDocumento.TabIndex = 4;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(166, 60);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(366, 20);
            this.txtApellido.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 397);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Correo Electrònico";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 351);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Telèfono Mòvil";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 306);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Telèfono Fijo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Provincia";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 264);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Localidad";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Direcciòn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Nùmero de Documento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Tipo de Documento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Apellido";
            // 
            // cboTipoDeDocumento
            // 
            this.cboTipoDeDocumento.FormattingEnabled = true;
            this.cboTipoDeDocumento.Location = new System.Drawing.Point(166, 102);
            this.cboTipoDeDocumento.Name = "cboTipoDeDocumento";
            this.cboTipoDeDocumento.Size = new System.Drawing.Size(121, 21);
            this.cboTipoDeDocumento.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(166, 22);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(366, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 441);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Tipo de Tarea";
            // 
            // cboTipoDeTarea
            // 
            this.cboTipoDeTarea.FormattingEnabled = true;
            this.cboTipoDeTarea.Location = new System.Drawing.Point(166, 438);
            this.cboTipoDeTarea.Name = "cboTipoDeTarea";
            this.cboTipoDeTarea.Size = new System.Drawing.Size(366, 21);
            this.cboTipoDeTarea.TabIndex = 11;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VeterinariaEdiMvc2021.Windows.Properties.Resources.empleados;
            this.pictureBox1.Location = new System.Drawing.Point(556, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(246, 504);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // frmEmpleadosAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(814, 554);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cboTipoDeTarea);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCorreoElectronico);
            this.Controls.Add(this.txtTelefonoMovil);
            this.Controls.Add(this.txtTelefonoFijo);
            this.Controls.Add(this.cboLocalidad);
            this.Controls.Add(this.cboProvincia);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtNumeroDocumento);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboTipoDeDocumento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "frmEmpleadosAE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtCorreoElectronico;
        private System.Windows.Forms.TextBox txtTelefonoMovil;
        private System.Windows.Forms.TextBox txtTelefonoFijo;
        private System.Windows.Forms.ComboBox cboLocalidad;
        private System.Windows.Forms.ComboBox cboProvincia;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtNumeroDocumento;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTipoDeDocumento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboTipoDeTarea;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}