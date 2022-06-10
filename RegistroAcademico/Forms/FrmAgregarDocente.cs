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
using PlayerUI.Services;

namespace PlayerUI
{
    public partial class FrmAgregarDocente : Form
    {
        Usuario oUsuario;
        private ApiService api = new ApiService();
        public FrmAgregarDocente()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            oUsuario = new Usuario();
            oUsuario.Documento = Interaction.InputBox("Ingresa el Documento del docente", "Búsqueda de Docente", "");
            //acciones para buscar uno si no se logra, remover
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Aquí va el put al api xDXDXD
            FillDocente();

            if (true)
            {
                MessageBox.Show("Docente agregado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ocurrió un problema al agregar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FillDocente()
        {
            oUsuario = new Usuario();
            oUsuario.Nombre = txtNombre.Text.Trim();
            oUsuario.Apellido = txtApellido.Text.Trim();
            oUsuario.Username = txtUsuario.Text.Trim();
            oUsuario.Clave = txtClave.Text.Trim();
            oUsuario.Telefono = txtTelefono.Text.Trim();
            oUsuario.Direccion = txtDireccion.Text.Trim();
            oUsuario.Documento = txtDocumento.Text.Trim();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            FillDocente();
            if (true)
            {
                MessageBox.Show("Docente modificado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ocurrió un problema al modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (txtClave.PasswordChar == '*')
            {
                button3.BringToFront();
                txtClave.PasswordChar = '\0';
            }
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            if (txtClave.PasswordChar == '\0')
            {
                button2.BringToFront();
                txtClave.PasswordChar = '*';
            }
        }

        private async void btnAgregar_Click_1(object sender, EventArgs e)
        {
            oUsuario = new Usuario
            {
                Apellido = this.txtApellido.Text,
                Clave = this.txtClave.Text,
                Direccion = this.txtDireccion.Text,
                Documento = this.txtDocumento.Text,
                Username = this.txtUsuario.Text,
                Telefono = this.txtTelefono.Text,
                Nombre = this.txtNombre.Text,
                Tipo=1
            };
            var resp = await api.Post(Controllers.UsuarioController, oUsuario);
            if (resp.IsSuccess)
            {
                //Dejar algo para cuando sea satisfactorio
            }
            else
            {
                MessageBox.Show("Error", resp.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
