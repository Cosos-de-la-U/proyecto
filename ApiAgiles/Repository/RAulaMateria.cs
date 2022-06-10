using ApiAgiles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiAgiles.Repository
{
    public class RAulaMateria: ICrudGeneral<Aula_Materia>
    {
        private readonly Model1 db = new Model1();
        public Response Delete(int id)
        {
            try
            {
                var user = db.Aula_Materia.Find(id);
                if (user == null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "No se encontro ningun Aula_Materia con el id " + id
                    };
                }
                var resp = db.Aula_Materia.Remove(user);
                db.SaveChanges();
                if (resp == null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "El Aula_Materia no existe"
                    };
                }
                return new Response
                {
                    IsSuccess = true,
                    Result = user,
                    Message = "El Aula_Materia ha sido eliminado exitosamente"
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
                    Result = db.Aula_Materia.ToList(),
                    Message = db.Aula_Materia.ToList().Count == 0 ? "No hay Aula_Materias registrados" : ""
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
                var user = db.Aula_Materia.Find(id);
                if (user == null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "No se encontro ningun Aula_Materia con el id " + id
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

        public Response Post(Aula_Materia item)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Aula_Materia.Add(item);
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

        public Response Put(Aula_Materia item)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                var user = db.Aula_Materia.Find(item.Id_Aula_Materia);
                if (user == null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "No se encontro ningun Aula_Materia para actualizar"
                    };
                }
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