using ApiAgiles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAgiles.Repository
{
    public interface IUsuario
    {
        Response Login(string Username, string Passcode);
        Response GetDocentes();
        Response GetAlumnos();
    }
}
