using ApiAgiles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ApiAgiles.Repository
{
    public class RUsuario : ICrudGeneral<Usuario>, IUsuario
    {
        private readonly Model1 db = new Model1();
        public Response Delete(int id)
        {
            try
            {
                var user = db.Usuario.Find(id);
                if (user == null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "No se encontro ningun usuario con el id " + id
                    };
                }
                var resp = db.Usuario.Remove(user);
                db.SaveChanges();
                if (resp == null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "El usuario no existe"
                    };
                }
                return new Response
                {
                    IsSuccess = true,
                    Result = user,
                    Message = "El usuario ha sido eliminado exitosamente"
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
                    Result = db.Usuario.ToList(),
                    Message = db.Usuario.ToList().Count == 0 ? "No hay usuarios registrados" : ""
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
                var user = db.Usuario.Find(id);
                if (user == null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "No se encontro ningun usuario con el id " + id
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

        public Response Post(Usuario item)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Usuario.Add(item);
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

        public Response Put(Usuario item)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                var user = db.Usuario.Find(item.Id_Usuario);
                if (user == null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "No se encontro ningun usuario para actualizar"
                    };
                }
                user.Apellido = item.Apellido;
                user.Clave = item.Clave;
                user.Direccion = item.Direccion;
                user.Documento = item.Documento;
                user.Documento_Representante = item.Documento_Representante;
                user.Fecha_Nacimiento = item.Fecha_Nacimiento;
                user.Id_Aula = item.Id_Aula;
                user.Nombre = item.Nombre;
                user.Representante = item.Representante;
                user.Telefono = item.Telefono;
                user.Telefono_Representante = item.Telefono_Representante;
                user.Tipo = item.Tipo;
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
        public Response Login(string Username, string Passcode)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                var loggedUser = db.Usuario.ToList();
                var user = from c in loggedUser
                           where c.Username.Equals(Username) && c.Clave.Equals(Passcode)
                           select c;
                if (user.Count() == 0)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "Credenciales invalidas"
                    };
                }
                return new Response
                {
                    IsSuccess = true,
                    Result = user.FirstOrDefault(),
                    Message = "Usuario encontrado"
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

        public Response GetDocentes()
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                var LDocentes = db.Usuario.ToList();
                var Docentes = from c in LDocentes
                               where c.Tipo.Equals(1)
                               select c;
                if (Docentes.Count() == 0)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "No hay docentes registrados"
                    };
                }
                return new Response
                {
                    IsSuccess = true,
                    Result = Docentes,
                    Message = "Docentes encontrados"
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


        public Response GetAlumnos()
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                var LDocentes = db.Usuario.ToList();
                var Docentes = from c in LDocentes
                               where c.Tipo.Equals(2)
                               select c;
                if (Docentes.Count() == 0)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "No hay Alumnos registrados"
                    };
                }
                return new Response
                {
                    IsSuccess = true,
                    Result = Docentes,
                    Message = "Alumnos encontrados"
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

