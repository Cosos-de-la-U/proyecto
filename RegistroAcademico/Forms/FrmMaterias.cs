using PlayerUI.Model;
using PlayerUI.Services;
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
    public partial class FrmMaterias : Form
    {
        public ApiService api = new ApiService();
        public FrmMaterias()
        {
            InitializeComponent();
        }



        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            await api.GetAll<Materia>("Materia");
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            Materia materia = new Materia()
            {
                Nombre = this.txtNombre.Text
            };

            await api.Post<Materia>("Materia", materia);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        private void FillMateria()
        {
            Materia oMateria = new Materia();
            oMateria.Nombre = txtNombre.Text;
        }
    }
}
