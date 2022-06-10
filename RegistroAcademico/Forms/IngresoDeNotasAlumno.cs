using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlayerUI.Model;

namespace PlayerUI.Forms
{
    public partial class IngresoDeNotasAlumno : Form
    {
        public IngresoDeNotasAlumno()
        {
            //comboBox3 = new 
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void button4_Click(object sender, EventArgs e)
        {
            String NOMBRE = comboBox1.SelectedItem.ToString();
            String SECCION = comboBox2.SelectedItem.ToString();
            String text = String.Format("Usuario/Notas?nombre={0}&seccion={1}",NOMBRE, SECCION);
            var response =await new Services.ApiService().GetAll<Usuario>(text);
            if(response.IsSuccess)
            {
                List<Usuario> users = (List<Usuario>)response.Result;
                this.dataGridView1.Rows.Clear();

                foreach (var item in users)
                {
                    this.dataGridView1.Rows.Add(
                        new object[] {
                            item.Nombre + " " +item.Apellido,
                            null
                        });
                }
            }
        }
    }
}
