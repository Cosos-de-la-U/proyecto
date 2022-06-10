using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerUI.Model
{
    class Usuario
    {
        private int idAula;
        
        public int IdAula { get => idAula; set => idAula = value; }

        public string Nombre { get; set; }

        [StringLength(75)]
        public string Apellido { get; set; }

        [StringLength(25)]
        public string Username { get; set; }

        [StringLength(25)]
        public string Clave { get; set; }

        [StringLength(15)]
        public string Telefono { get; set; }

        [StringLength(150)]
        public string Direccion { get; set; }

        public DateTime? Fecha_Nacimiento { get; set; }

        public int? Tipo { get; set; }

        [StringLength(150)]
        public string Representante { get; set; }

        [StringLength(15)]
        public string Telefono_Representante { get; set; }

        [StringLength(15)]
        public string Documento { get; set; }

        [StringLength(15)]
        public string Documento_Representante { get; set; }


    }
}
