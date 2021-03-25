namespace VeterinariaEdiMvc2021.Windows
{
    partial class frmMascotas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMascotas));
            this.btnSalir = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMascotas2 = new System.Windows.Forms.Button();
            this.btnRazas = new System.Windows.Forms.Button();
            this.btnTiposDeMascotas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Red;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.Location = new System.Drawing.Point(630, 459);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(172, 60);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(207, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(595, 397);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // btnMascotas2
            // 
            this.btnMascotas2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnMascotas2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMascotas2.ForeColor = System.Drawing.Color.White;
            this.btnMascotas2.Image = ((System.Drawing.Image)(resources.GetObject("btnMascotas2.Image")));
            this.btnMascotas2.Location = new System.Drawing.Point(36, 38);
            this.btnMascotas2.Name = "btnMascotas2";
            this.btnMascotas2.Size = new System.Drawing.Size(133, 91);
            this.btnMascotas2.TabIndex = 11;
            this.btnMascotas2.Text = "Mascotas";
            this.btnMascotas2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMascotas2.UseVisualStyleBackColor = false;
            this.btnMascotas2.Click += new System.EventHandler(this.btnMascotas2_Click);
            // 
            // btnRazas
            // 
            this.btnRazas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRazas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRazas.ForeColor = System.Drawing.Color.White;
            this.btnRazas.Image = ((System.Drawing.Image)(resources.GetObject("btnRazas.Image")));
            this.btnRazas.Location = new System.Drawing.Point(36, 344);
            this.btnRazas.Name = "btnRazas";
            this.btnRazas.Size = new System.Drawing.Size(133, 91);
            this.btnRazas.TabIndex = 12;
            this.btnRazas.Text = "Razas";
            this.btnRazas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRazas.UseVisualStyleBackColor = false;
            this.btnRazas.Click += new System.EventHandler(this.btnRazas_Click);
            // 
            // btnTiposDeMascotas
            // 
            this.btnTiposDeMascotas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnTiposDeMascotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTiposDeMascotas.ForeColor = System.Drawing.Color.White;
            this.btnTiposDeMascotas.Image = ((System.Drawing.Image)(resources.GetObject("btnTiposDeMascotas.Image")));
            this.btnTiposDeMascotas.Location = new System.Drawing.Point(36, 183);
            this.btnTiposDeMascotas.Name = "btnTiposDeMascotas";
            this.btnTiposDeMascotas.Size = new System.Drawing.Size(133, 91);
            this.btnTiposDeMascotas.TabIndex = 13;
            this.btnTiposDeMascotas.Text = "Tipos de Mascotas";
            this.btnTiposDeMascotas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTiposDeMascotas.UseVisualStyleBackColor = false;
            this.btnTiposDeMascotas.Click += new System.EventHandler(this.btnTiposDeMascotas_Click);
            // 
            // frmMascotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 531);
            this.ControlBox = false;
            this.Controls.Add(this.btnTiposDeMascotas);
            this.Controls.Add(this.btnRazas);
            this.Controls.Add(this.btnMascotas2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmMascotas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mascotas";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnMascotas2;
        private System.Windows.Forms.Button btnRazas;
        private System.Windows.Forms.Button btnTiposDeMascotas;
    }
}