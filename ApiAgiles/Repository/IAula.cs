using ApiAgiles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAgiles.Repository
{
    interface IAula<T> :ICrudGeneral<Aula>
    {
        Response GetAulaByDocente(int id);
        Response GetStudents(int id);
    }
}
