using ApiAgiles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiAgiles.Repository
{
    public class RMateria: ICrudGeneral<Materia>
    {
        private readonly Model1 db = new Model1();
        public Response Delete(int id)
        {
            try
            {
                var user = db.Materia.Find(id);
                if (user == null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "No se encontro ningun Materia con el id " + id
                    };
                }
                var resp = db.Materia.Remove(user);
                db.SaveChanges();
                if (resp == null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "El Materia no existe"
                    };
                }
                return new Response
                {
                    IsSuccess = true,
                    Result = user,
                    Message = "El Materia ha sido eliminado exitosamente"
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
                    Result = db.Materia.ToList(),
                    Message = db.Materia.ToList().Count == 0 ? "No hay Materias registrados" : ""
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
                var user = db.Materia.Find(id);
                if (user == null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "No se encontro ningun Materia con el id " + id
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

        public Response Post(Materia item)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Materia.Add(item);
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

        public Response Put(Materia item)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                var user = db.Materia.Find(item.Id_Materia);
                if (user == null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "No se encontro ningun Materia para actualizar"
                    };
                }
                user.Nombre = item.Nombre;
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