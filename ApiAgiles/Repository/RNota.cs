using ApiAgiles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiAgiles.Repository
{
    public class RNota: ICrudGeneral<Nota>
    {
        private readonly Model1 db = new Model1();
        public Response Delete(int id)
        {
            try
            {
                var user = db.Nota.Find(id);
                if (user == null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "No se encontro ningun Nota con el id " + id
                    };
                }
                var resp = db.Nota.Remove(user);
                db.SaveChanges();
                if (resp == null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "El Nota no existe"
                    };
                }
                return new Response
                {
                    IsSuccess = true,
                    Result = user,
                    Message = "El Nota ha sido eliminado exitosamente"
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
                return new Response
                {
                    IsSuccess = true,
                    Result = db.Nota.ToList(),
                    Message = db.Nota.ToList().Count == 0 ? "No hay Notas registrados" : ""
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
            finally
            {
                db.Configuration.ProxyCreationEnabled = true;
            }
        }

        public Response GetById(int id)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                var user = db.Nota.Find(id);
                if (user == null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "No se encontro ningun Nota con el id " + id
                    };
                }
                return new Response
                {
                    IsSuccess = true,
                    Result = user
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

        public Response Post(Nota item)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Nota.Add(item);
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

        public Response Put(Nota item)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                var user = db.Nota.Find(item.Id_Nota);
                if (user == null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "No se encontro ningun Nota para actualizar"
                    };
                }
                user.Anio = item.Anio;
                user.Valor_Nota = item.Valor_Nota;
                user.Trimestre = item.Trimestre;
                user.Porcentaje = item.Porcentaje;
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return new Response
                {
                    IsSuccess = true,
                    Result = user
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
    }
}