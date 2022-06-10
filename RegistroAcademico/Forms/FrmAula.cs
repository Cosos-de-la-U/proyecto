using Microsoft.VisualBasic;
using PlayerUI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI.Forms
{
    public partial class FrmAula : Form
    {
        Aula oAula;
        public FrmAula()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Aquí va el put al api xDXDXD
            FillMateria();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            oAula = new Aula();
            oAula.Nombre = Interaction.InputBox("Ingresa el nombre del Aula", "Búsqueda por Aula", "");
        }

        private void FillMateria()
        {
            oAula = new Aula();
            oAula.Nombre = txtNombre.Text.Trim();
            oAula.Seccion = txtSeccion.Text.Trim();
            oAula.Anio = txtAnio.Text.Trim();
            oAula.IdUsuario = cmbDocente.SelectedIndex;
        }


    }
}
