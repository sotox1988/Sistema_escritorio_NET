﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrionEscritorio
{
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void BuscarMotivo_Click(object sender, EventArgs e)
        {

        }

        private void btnCUsuario_Click(object sender, EventArgs e)
        {

            String Usuario = txtUsuario.Text.ToString();
            String Password = txtPassword.Text.ToString();
            String IdFunc = txtFuncionario.Text.ToString();
            int perfil = Convert.ToInt32(cbxPerfil.ToString());
            TUsuario tusuario = new TUsuario();
            Usuario usuario = new Usuario();
            usuario.nombre = Usuario;
            usuario.clave = Password;
            usuario.rut_funcionario = IdFunc;
            usuario.perfil_id = perfil;
            tusuario.ingresarUsuario(usuario);

        }
    }
}