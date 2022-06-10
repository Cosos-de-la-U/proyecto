using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerUI.Model
{
    class Materia
    {
        private int idMateria;
        private String nombre;

        public int IdMateria { get => idMateria; set => idMateria = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
