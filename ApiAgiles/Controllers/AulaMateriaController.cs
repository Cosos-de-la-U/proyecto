using ApiAgiles.Models;
using ApiAgiles.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ApiAgiles.Controllers
{
    public class AulaMateriaController : ApiController
    {
        private readonly ICrudGeneral<Aula_Materia> UserRepository = new RAulaMateria();
        [HttpGet]
        public HttpResponseMessage GetAulaMaterias()
        {
            var resp = UserRepository.Get();
            List<Aula_Materia> AulaMaterias = (List<Aula_Materia>)resp.Result;
            if (AulaMaterias.Count == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, resp.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK, resp);
        }
        [HttpGet]
        public HttpResponseMessage GetAulaMateriasById(int id)
        {
            var resp = UserRepository.GetById(id);
            if (!resp.IsSuccess)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, resp.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK, resp);
        }
        [HttpPost]
        public HttpResponseMessage AddUser(Aula_Materia item)
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
        public HttpResponseMessage PutUser(Aula_Materia item)
        {
            var resp = UserRepository.Put(item);
            if (!resp.IsSuccess)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, "No se ha podido actualizar el registro");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "El registro ha sido actualizado");
        }
    }
}