namespace VeterinariaEdiMvc2021.Windows
{
    partial class frmMenuPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuPrincipal));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnArchivos = new System.Windows.Forms.Button();
            this.btnMascotas = new System.Windows.Forms.Button();
            this.btnMedicinas = new System.Windows.Forms.Button();
            this.btnServicios = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(229, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(573, 383);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnArchivos
            // 
            this.btnArchivos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnArchivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArchivos.ForeColor = System.Drawing.Color.White;
            this.btnArchivos.Image = ((System.Drawing.Image)(resources.GetObject("btnArchivos.Image")));
            this.btnArchivos.Location = new System.Drawing.Point(24, 56);
            this.btnArchivos.Name = "btnArchivos";
            this.btnArchivos.Size = new System.Drawing.Size(172, 79);
            this.btnArchivos.TabIndex = 4;
            this.btnArchivos.Text = "Archivos";
            this.btnArchivos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnArchivos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnArchivos.UseVisualStyleBackColor = false;
            this.btnArchivos.Click += new System.EventHandler(this.btnArchivos_Click);
            // 
            // btnMascotas
            // 
            this.btnMascotas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnMascotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMascotas.ForeColor = System.Drawing.Color.White;
            this.btnMascotas.Image = ((System.Drawing.Image)(resources.GetObject("btnMascotas.Image")));
            this.btnMascotas.Location = new System.Drawing.Point(24, 156);
            this.btnMascotas.Name = "btnMascotas";
            this.btnMascotas.Size = new System.Drawing.Size(172, 79);
            this.btnMascotas.TabIndex = 5;
            this.btnMascotas.Text = "Mascotas";
            this.btnMascotas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMascotas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMascotas.UseVisualStyleBackColor = false;
            this.btnMascotas.Click += new System.EventHandler(this.btnMascotas_Click);
            // 
            // btnMedicinas
            // 
            this.btnMedicinas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnMedicinas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMedicinas.ForeColor = System.Drawing.Color.White;
            this.btnMedicinas.Image = ((System.Drawing.Image)(resources.GetObject("btnMedicinas.Image")));
            this.btnMedicinas.Location = new System.Drawing.Point(24, 260);
            this.btnMedicinas.Name = "btnMedicinas";
            this.btnMedicinas.Size = new System.Drawing.Size(172, 79);
            this.btnMedicinas.TabIndex = 6;
            this.btnMedicinas.Text = "Medicinas";
            this.btnMedicinas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMedicinas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMedicinas.UseVisualStyleBackColor = false;
            this.btnMedicinas.Click += new System.EventHandler(this.btnMedicinas_Click);
            // 
            // btnServicios
            // 
            this.btnServicios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnServicios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServicios.ForeColor = System.Drawing.Color.White;
            this.btnServicios.Image = ((System.Drawing.Image)(resources.GetObject("btnServicios.Image")));
            this.btnServicios.Location = new System.Drawing.Point(24, 360);
            this.btnServicios.Name = "btnServicios";
            this.btnServicios.Size = new System.Drawing.Size(172, 79);
            this.btnServicios.TabIndex = 7;
            this.btnServicios.Text = "Servicios";
            this.btnServicios.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnServicios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnServicios.UseVisualStyleBackColor = false;
            this.btnServicios.Click += new System.EventHandler(this.btnServicios_Click);
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
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 531);
            this.ControlBox = false;
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnServicios);
            this.Controls.Add(this.btnMedicinas);
            this.Controls.Add(this.btnMascotas);
            this.Controls.Add(this.btnArchivos);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menù Principal";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnArchivos;
        private System.Windows.Forms.Button btnMascotas;
        private System.Windows.Forms.Button btnMedicinas;
        private System.Windows.Forms.Button btnServicios;
        private System.Windows.Forms.Button btnSalir;
    }
}

