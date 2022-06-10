using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerUI.Model
{
    class Aula
    {
        private int idAula, idUsuario;
        private String nombre, seccion, anio;

        public int IdAula { get => idAula; set => idAula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Seccion { get => seccion; set => seccion = value; }
        public string Anio { get => anio; set => anio = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
    }
}
