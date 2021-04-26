namespace VeterinariaEdiMvc2021.Windows
{
    partial class frmProveedoresAE
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
            this.txtTelefonoMovil = new System.Windows.Forms.TextBox();
            this.cboProvincia = new System.Windows.Forms.ComboBox();
            this.txtCUIT = new System.Windows.Forms.TextBox();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.txtPersonaDeContacto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboLocalidad = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTelefonoFijo = new System.Windows.Forms.TextBox();
            this.txtCorreoElectronico = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
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
            this.btnCancel.Location = new System.Drawing.Point(406, 498);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(134, 38);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(36, 498);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(134, 38);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtTelefonoMovil
            // 
            this.txtTelefonoMovil.Location = new System.Drawing.Point(174, 320);
            this.txtTelefonoMovil.Name = "txtTelefonoMovil";
            this.txtTelefonoMovil.Size = new System.Drawing.Size(366, 20);
            this.txtTelefonoMovil.TabIndex = 7;
            // 
            // cboProvincia
            // 
            this.cboProvincia.FormattingEnabled = true;
            this.cboProvincia.Location = new System.Drawing.Point(174, 191);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Size = new System.Drawing.Size(366, 21);
            this.cboProvincia.TabIndex = 4;
            this.cboProvincia.SelectedIndexChanged += new System.EventHandler(this.cboProvincia_SelectedIndexChanged);
            // 
            // txtCUIT
            // 
            this.txtCUIT.Location = new System.Drawing.Point(174, 32);
            this.txtCUIT.Name = "txtCUIT";
            this.txtCUIT.Size = new System.Drawing.Size(366, 20);
            this.txtCUIT.TabIndex = 0;
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Location = new System.Drawing.Point(174, 70);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(366, 20);
            this.txtRazonSocial.TabIndex = 1;
            // 
            // txtPersonaDeContacto
            // 
            this.txtPersonaDeContacto.Location = new System.Drawing.Point(174, 112);
            this.txtPersonaDeContacto.Name = "txtPersonaDeContacto";
            this.txtPersonaDeContacto.Size = new System.Drawing.Size(366, 20);
            this.txtPersonaDeContacto.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 323);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Telèfono Mòvil";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Localidad";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 281);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Telèfono fijo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 194);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Provincia";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Direcciòn";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Persona de Contacto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Razòn Social";
            // 
            // cboLocalidad
            // 
            this.cboLocalidad.FormattingEnabled = true;
            this.cboLocalidad.Location = new System.Drawing.Point(174, 234);
            this.cboLocalidad.Name = "cboLocalidad";
            this.cboLocalidad.Size = new System.Drawing.Size(366, 21);
            this.cboLocalidad.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "CUIT";
            // 
            // txtTelefonoFijo
            // 
            this.txtTelefonoFijo.Location = new System.Drawing.Point(174, 278);
            this.txtTelefonoFijo.Name = "txtTelefonoFijo";
            this.txtTelefonoFijo.Size = new System.Drawing.Size(366, 20);
            this.txtTelefonoFijo.TabIndex = 6;
            // 
            // txtCorreoElectronico
            // 
            this.txtCorreoElectronico.Location = new System.Drawing.Point(174, 363);
            this.txtCorreoElectronico.Name = "txtCorreoElectronico";
            this.txtCorreoElectronico.Size = new System.Drawing.Size(366, 20);
            this.txtCorreoElectronico.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 366);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Correo electrònico";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(174, 150);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(366, 20);
            this.txtDireccion.TabIndex = 3;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VeterinariaEdiMvc2021.Windows.Properties.Resources.Proveedor;
            this.pictureBox1.Location = new System.Drawing.Point(556, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(246, 504);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // frmProveedoresAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(814, 554);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtCorreoElectronico);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTelefonoMovil);
            this.Controls.Add(this.cboProvincia);
            this.Controls.Add(this.txtCUIT);
            this.Controls.Add(this.txtRazonSocial);
            this.Controls.Add(this.txtPersonaDeContacto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboLocalidad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTelefonoFijo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "frmProveedoresAE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtTelefonoMovil;
        private System.Windows.Forms.ComboBox cboProvincia;
        private System.Windows.Forms.TextBox txtCUIT;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.TextBox txtPersonaDeContacto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboLocalidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTelefonoFijo;
        private System.Windows.Forms.TextBox txtCorreoElectronico;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}