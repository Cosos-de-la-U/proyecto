using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerUI.Model
{
    class Nota
    {
        private int idNota, idMateria, idUsuario;
        private double valorNota, porcentaje;
        private String anio, trimestre;

        public int IdNota { get => idNota; set => idNota = value; }
        public int IdMateria { get => idMateria; set => idMateria = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public double ValorNota { get => valorNota; set => valorNota = value; }
        public double Porcentaje { get => porcentaje; set => porcentaje = value; }
        public string Anio { get => anio; set => anio = value; }
        public string Trimestre { get => trimestre; set => trimestre = value; }
    }
}
