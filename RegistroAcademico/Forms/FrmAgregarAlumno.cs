using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using PlayerUI.Model;

namespace PlayerUI
{
    public partial class FrmAgregarAlumno : Form
    {
        Usuario oUsuario;
        public FrmAgregarAlumno()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            oUsuario = new Usuario();
            oUsuario.Documento = Interaction.InputBox("Ingresa el NIE del Alumno", "Búsqueda del Alumno", "");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtClave.PasswordChar == '\0')
            {
                button2.BringToFront();
                txtClave.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtClave.PasswordChar == '*')
            {
                button3.BringToFront();
                txtClave.PasswordChar = '\0';
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Aquí va el put al api xDXDXD
            FillAlumno();
        }

        private void FillAlumno()
        {
            oUsuario = new Usuario();
            oUsuario.Nombre = txtNombre.Text.Trim();
            oUsuario.Apellido = txtApellido.Text.Trim();
            oUsuario.Username = txtUsuario.Text.Trim();
            oUsuario.Clave = txtClave.Text.Trim();
            oUsuario.Documento = txtNie.Text.Trim();
            oUsuario.Telefono = txtTelefono.Text.Trim();
            oUsuario.Direccion = txtDireccion.Text.Trim();
            oUsuario.Fecha_Nacimiento = txtFechaNac.SelectionRange.End;
            oUsuario.Representante = txtRepresentante.Text.Trim();
            oUsuario.Telefono_Representante = txtTelefonoRepresentante.Text.Trim();
            oUsuario.Documento_Representante = txtDocumentoRepresentante.Text.Trim();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }
    }
}
