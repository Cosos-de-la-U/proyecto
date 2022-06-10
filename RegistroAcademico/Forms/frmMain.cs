using PlayerUI.Forms;
using PlayerUI.Middlewares;
using PlayerUI.Model;
using PlayerUI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class frmMain : Form
    {
        ApiService api;
        Usuario oUsuario;
        public frmMain()
        {
            InitializeComponent();
            hideSubMenu();
        }

        private void hideSubMenu()
        {
            panelMediaSubMenu.Visible = false;
            panelPlaylistSubMenu.Visible = false;
            panelToolsSubMenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnMedia_Click(object sender, EventArgs e)
        {
            showSubMenu(panelMediaSubMenu);
        }

        #region MediaSubMenu
        private void button2_Click(object sender, EventArgs e)
        {

            openChildForm(new IngresoDeNotasAlumno());
            hideSubMenu();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }
        #endregion

        private void btnPlaylist_Click(object sender, EventArgs e)
        {
            showSubMenu(panelPlaylistSubMenu);
        }

        #region PlayListManagemetSubMenu
        private void button8_Click(object sender, EventArgs e)
        {
            //NOTAS ALUMNO
            hideSubMenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //NOTAS MATERIA
            hideSubMenu();
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            api = new ApiService();
            var Alumnos = await api.GetAll<Usuario>(Controllers.UsuarioController + "/Alumnos");
            if (Alumnos.IsSuccess)
            {
                List<Usuario> LAlumnos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Usuario>>(Alumnos.Result.ToString()); 
                ReporteNominaAlumnos reporte = new ReporteNominaAlumnos();
                reporte.PrintReport(LAlumnos);
                MessageBox.Show("Reporte guardado correctamente en: " + reporte.path, "Informe completado!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(reporte.path);
            }
            hideSubMenu();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            api = new ApiService();
            var Docentes = await api.GetAll<Usuario>(Controllers.UsuarioController + "/Docentes");
            if (Docentes.IsSuccess)
            {
                List<Usuario> LDocentes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Usuario>>(Docentes.Result.ToString()); 
                ResporteNominaDocentes reporte = new ResporteNominaDocentes();
                reporte.PrintReport(LDocentes);
                MessageBox.Show("Reporte guardado correctamente en: " + reporte.path, "Informe completado!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(reporte.path);
            }
            hideSubMenu();
        }
        #endregion

        private void btnTools_Click(object sender, EventArgs e)
        {
            showSubMenu(panelToolsSubMenu);
        }
        #region ToolsSubMenu
        private void button13_Click(object sender, EventArgs e)
        {

            openChildForm(new FrmAgregarAlumno());

           //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //MATERIAS
            openChildForm(new FrmMaterias());
            hideSubMenu();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //AULA
            openChildForm(new FrmAula());
            hideSubMenu();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }
        #endregion

        private void btnEqualizer_Click(object sender, EventArgs e)
        {

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void panelLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            openChildForm(new FrmAgregarDocente());
            hideSubMenu();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
