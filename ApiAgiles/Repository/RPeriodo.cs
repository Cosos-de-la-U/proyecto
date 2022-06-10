using ApiAgiles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiAgiles.Repository
{
    public class RPeriodo : ICrudGeneral<Periodo>
    {
        private readonly Model1 db = new Model1();
        public Response Delete(int id)
        {
            try
            {
                var user = db.Periodo.Find(id);
                if (user == null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "No se encontro ningun Aula con el id " + id
                    };
                }
                var resp = db.Periodo.Remove(user);
                db.SaveChanges();
                if (resp == null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "El Periodo no existe"
                    };
                }
                return new Response
                {
                    IsSuccess = true,
                    Result = user,
                    Message = "El Periodo ha sido eliminado exitosamente"
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.InnerException.Message
                };
            }
        }

        public Response Get()
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                var periodos = db.Periodo.ToList();
                if (periodos.Count()<=0)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "No data in the table"
                    };
                }
                return new Response
                {
                    IsSuccess = true,
                    Result = periodos
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess=false,
                    Message=ex.Message
                };
            }
        }

        public Response GetById(int id)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                var periodos = db.Periodo.Find(id);
                if (periodos==null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "The record does not exist"
                    };
                }
                return new Response
                {
                    IsSuccess = true,
                    Result = periodos
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public Response Post(Periodo item)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Periodo.Add(item);
                db.SaveChanges();
                return new Response
                {
                    IsSuccess = true,
                    Result = item
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.InnerException.Message
                };
            }
        }

        public Response Put(Periodo item)
        {
            throw new NotImplementedException();
        }
    }
}