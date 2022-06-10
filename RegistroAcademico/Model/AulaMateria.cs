using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerUI.Model
{
    class AulaMateria
    {
        private int idAulaMateria, idAula, idMateria;
        public int IdAulaMateria { get => idAulaMateria; set => idAulaMateria = value; }
        public int IdAula { get => idAula; set => idAula = value; }
        public int IdMateria { get => idMateria; set => idMateria = value; }
    }
}
