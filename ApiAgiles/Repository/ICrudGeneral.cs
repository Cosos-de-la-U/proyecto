using ApiAgiles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAgiles.Repository
{
    interface ICrudGeneral<T>
    {
        Response Get();
        Response GetById(int id);
        Response Post(T item);
        Response Put(T item);
        Response Delete(int id);
    }
}
