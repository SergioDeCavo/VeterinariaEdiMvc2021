
namespace VeterinariaEdiMvc2021.Windows
{
    partial class frmNuevaVenta
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtProvincia = new System.Windows.Forms.TextBox();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.txtPrecioTotal = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.cboMedicamento = new System.Windows.Forms.ComboBox();
            this.cboTipoDeMedicamento = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.cmnMedicamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnBorrar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtProvincia);
            this.groupBox1.Controls.Add(this.txtLocalidad);
            this.groupBox1.Controls.Add(this.txtDireccion);
            this.groupBox1.Controls.Add(this.cboCliente);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 149);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente";
            // 
            // txtProvincia
            // 
            this.txtProvincia.Location = new System.Drawing.Point(127, 118);
            this.txtProvincia.Name = "txtProvincia";
            this.txtProvincia.ReadOnly = true;
            this.txtProvincia.Size = new System.Drawing.Size(391, 20);
            this.txtProvincia.TabIndex = 7;
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Location = new System.Drawing.Point(127, 85);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.ReadOnly = true;
            this.txtLocalidad.Size = new System.Drawing.Size(391, 20);
            this.txtLocalidad.TabIndex = 6;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(127, 55);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ReadOnly = true;
            this.txtDireccion.Size = new System.Drawing.Size(391, 20);
            this.txtDireccion.TabIndex = 5;
            // 
            // cboCliente
            // 
            this.cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(127, 22);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(391, 21);
            this.cboCliente.TabIndex = 4;
            this.cboCliente.SelectedIndexChanged += new System.EventHandler(this.cboCliente_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Provincia";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Localidad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Direcciòn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Location = new System.Drawing.Point(573, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(229, 101);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fecha";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Venta";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(62, 19);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(161, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCancelar);
            this.groupBox3.Controls.Add(this.btnAceptar);
            this.groupBox3.Controls.Add(this.numericUpDown1);
            this.groupBox3.Controls.Add(this.txtPrecioTotal);
            this.groupBox3.Controls.Add(this.txtStock);
            this.groupBox3.Controls.Add(this.txtPrecio);
            this.groupBox3.Controls.Add(this.cboMedicamento);
            this.groupBox3.Controls.Add(this.cboTipoDeMedicamento);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(12, 168);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(784, 141);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Medicamento";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(658, 88);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(110, 43);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(658, 23);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(110, 43);
            this.btnAceptar.TabIndex = 17;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(478, 32);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 16;
            // 
            // txtPrecioTotal
            // 
            this.txtPrecioTotal.Location = new System.Drawing.Point(478, 64);
            this.txtPrecioTotal.Name = "txtPrecioTotal";
            this.txtPrecioTotal.ReadOnly = true;
            this.txtPrecioTotal.Size = new System.Drawing.Size(120, 20);
            this.txtPrecioTotal.TabIndex = 15;
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(295, 100);
            this.txtStock.Name = "txtStock";
            this.txtStock.ReadOnly = true;
            this.txtStock.Size = new System.Drawing.Size(95, 20);
            this.txtStock.TabIndex = 14;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(137, 100);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.ReadOnly = true;
            this.txtPrecio.Size = new System.Drawing.Size(93, 20);
            this.txtPrecio.TabIndex = 13;
            // 
            // cboMedicamento
            // 
            this.cboMedicamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMedicamento.FormattingEnabled = true;
            this.cboMedicamento.Location = new System.Drawing.Point(137, 67);
            this.cboMedicamento.Name = "cboMedicamento";
            this.cboMedicamento.Size = new System.Drawing.Size(253, 21);
            this.cboMedicamento.TabIndex = 12;
            this.cboMedicamento.SelectedIndexChanged += new System.EventHandler(this.cboMedicamento_SelectedIndexChanged);
            // 
            // cboTipoDeMedicamento
            // 
            this.cboTipoDeMedicamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDeMedicamento.FormattingEnabled = true;
            this.cboTipoDeMedicamento.Location = new System.Drawing.Point(137, 31);
            this.cboTipoDeMedicamento.Name = "cboTipoDeMedicamento";
            this.cboTipoDeMedicamento.Size = new System.Drawing.Size(253, 21);
            this.cboTipoDeMedicamento.TabIndex = 11;
            this.cboTipoDeMedicamento.SelectedIndexChanged += new System.EventHandler(this.cboTipoDeMedicamento_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(396, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Precio Total";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(396, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Cantidad";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(240, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Stock";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Precio";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Medicamento";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tipo de Medicamento";
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmnMedicamento,
            this.cmnPrecio,
            this.cmnCantidad,
            this.cmnTotal,
            this.cmnBorrar});
            this.dgvDatos.Location = new System.Drawing.Point(13, 316);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(783, 150);
            this.dgvDatos.TabIndex = 3;
            // 
            // cmnMedicamento
            // 
            this.cmnMedicamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnMedicamento.HeaderText = "Medicamento";
            this.cmnMedicamento.Name = "cmnMedicamento";
            this.cmnMedicamento.ReadOnly = true;
            // 
            // cmnPrecio
            // 
            this.cmnPrecio.HeaderText = "Precio";
            this.cmnPrecio.Name = "cmnPrecio";
            this.cmnPrecio.ReadOnly = true;
            // 
            // cmnCantidad
            // 
            this.cmnCantidad.HeaderText = "Cantidad";
            this.cmnCantidad.Name = "cmnCantidad";
            this.cmnCantidad.ReadOnly = true;
            // 
            // cmnTotal
            // 
            this.cmnTotal.HeaderText = "Total";
            this.cmnTotal.Name = "cmnTotal";
            this.cmnTotal.ReadOnly = true;
            // 
            // cmnBorrar
            // 
            this.cmnBorrar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cmnBorrar.HeaderText = "Borrar";
            this.cmnBorrar.Name = "cmnBorrar";
            this.cmnBorrar.ReadOnly = true;
            this.cmnBorrar.Width = 60;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12, 483);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(155, 36);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(237, 483);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(155, 36);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(620, 495);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Total";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(670, 492);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(126, 20);
            this.txtTotal.TabIndex = 15;
            // 
            // frmNuevaVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 531);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmNuevaVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NuevaVenta";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtProvincia;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox txtPrecioTotal;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.ComboBox cboMedicamento;
        private System.Windows.Forms.ComboBox cboTipoDeMedicamento;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnMedicamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnBorrar;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTotal;
    }
}