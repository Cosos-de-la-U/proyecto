using ApiAgiles.Models;
using ApiAgiles.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ApiAgiles.Controllers
{
    public class UsuarioController : ApiController
    {
        private readonly ICrudGeneral<Usuario> UserRepository = new RUsuario();
        private readonly IUsuario LoginRepository = new RUsuario();
        [HttpGet]
        public HttpResponseMessage GetUsuarios()
        {
            var resp = UserRepository.Get();
            List<Usuario> usuarios = (List<Usuario>)resp.Result;
            if (usuarios.Count==0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, resp.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK, resp);
        }
        [HttpGet]
        public HttpResponseMessage GetUsuariosById(int id)
        {
            var resp = UserRepository.GetById(id);
            if (!resp.IsSuccess)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, resp.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK, resp);
        }
        [Route("api/Usuario/Docentes")]
        [HttpGet]
        public HttpResponseMessage GetDocentes()
        {
            var resp = LoginRepository.GetDocentes();
            if (!resp.IsSuccess)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, resp.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK, resp);
        }
        [Route("api/Usuario/Alumnos")]
        [HttpGet]
        public HttpResponseMessage GetAlumnos()
        {
            var resp = LoginRepository.GetAlumnos();
            if (!resp.IsSuccess)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, resp.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK, resp);
        }
        [HttpPost]
        public HttpResponseMessage AddUser(Usuario item)
        {
            var resp = UserRepository.Post(item);
            if (!resp.IsSuccess)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Error al agregar el item a la base de datos");
            }
            return Request.CreateResponse(HttpStatusCode.OK, resp);
        }
        [HttpDelete]
        public HttpResponseMessage RemoveUser(int id)
        {
            var resp = UserRepository.Delete(id);
            if (!resp.IsSuccess)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, "No se ha podido eliminar el registro");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "El registro ha sido eliminado");
        }
        [HttpPut]
        public HttpResponseMessage PutUser(Usuario item)
        {
            var resp = UserRepository.Put(item);
            if (!resp.IsSuccess)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, "No se ha podido actualizar el registro");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "El registro ha sido actualizado");
        }
        [Route("api/Usuario/Login")]
        [HttpPost]
        public HttpResponseMessage Login(Usuario usuarioLogin)
        {
            var user = LoginRepository.Login(usuarioLogin.Username, usuarioLogin.Clave);
            if (!user.IsSuccess)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, user.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }
    }
}