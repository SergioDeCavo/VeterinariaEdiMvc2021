﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeDocumento;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmTiposDeDocumentosAE : Form
    {
        public frmTiposDeDocumentosAE()
        {
            InitializeComponent();
        }

        private TipoDeDocumentoEditDto tipoDocDto;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public TipoDeDocumentoEditDto GetTipoDeDocumento()
        {
            return tipoDocDto;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (tipoDocDto != null)
            {
                txtTipoDeDocumento.Text = tipoDocDto.Descripcion;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (tipoDocDto == null)
                {
                    tipoDocDto = new TipoDeDocumentoEditDto();
                }
                tipoDocDto.Descripcion = txtTipoDeDocumento.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtTipoDeDocumento.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtTipoDeDocumento, "El nombre del Tipo de Documento es requerido");

            }
            return valido;
        }

        public void SetTipo(TipoDeDocumentoEditDto tipoDocEditDto)
        {
            tipoDocDto = tipoDocEditDto;
        }
    }
}
