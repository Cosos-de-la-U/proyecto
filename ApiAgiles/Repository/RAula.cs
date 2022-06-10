using ApiAgiles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiAgiles.Repository
{
    public class RAula : IAula<Aula>
    {
        private readonly Model1 db = new Model1();
        public Response Delete(int id)
        {
            try
            {
                var user = db.Aula.Find(id);
                if (user == null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "No se encontro ningun Aula con el id " + id
                    };
                }
                var resp = db.Aula.Remove(user);
                db.SaveChanges();
                if (resp == null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "El Aula no existe"
                    };
                }
                return new Response
                {
                    IsSuccess = true,
                    Result = user,
                    Message = "El Aula ha sido eliminado exitosamente"
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
                    Result = db.Aula.ToList(),
                    Message = db.Aula.ToList().Count == 0 ? "No hay Aulas registrados" : ""
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

        public Response GetAulaByDocente(int id)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                var aula = db.Aula.Where(x => x.Id_Usuario.Equals(id));
                if (aula==null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "Record not found"
                    };
                }
                return new Response
                {
                    IsSuccess = true,
                    Result = aula
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

        public Response GetById(int id)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                var user = db.Aula.Find(id);
                if (user == null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "No se encontro ningun Aula con el id " + id
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

        public Response GetStudents(int id)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                var students = db.Usuario.Where(x => x.Id_Aula.Equals(id));
                if (students.Count()<=0)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "Not results at all"
                    };
                }
                return new Response
                {
                    IsSuccess = true,
                    Result = students
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
                throw;
            }
        }

        public Response Post(Aula item)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Aula.Add(item);
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

        public Response Put(Aula item)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                var user = db.Aula.Find(item.Id_Aula);
                if (user == null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "No se encontro ningun Aula para actualizar"
                    };
                }
                user.Anio = item.Anio;
                user.Nombre = item.Nombre;
                user.Seccion = item.Seccion;
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