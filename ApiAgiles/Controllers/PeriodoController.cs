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
    public class PeriodoController:ApiController
    {
        private readonly ICrudGeneral<Periodo> db = new RPeriodo();
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var resp = db.Get();
            if (!resp.IsSuccess)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, resp.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK, resp);
        }
        [HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            var resp = db.GetById(id);
            if (!resp.IsSuccess)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, resp.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK, resp);
        }
        [HttpPost]
        public HttpResponseMessage Post(Periodo item)
        {
            var resp = db.Post(item);
            if (!resp.IsSuccess)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, resp.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK, resp);
        }
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var resp = db.Delete(id);
            if (!resp.IsSuccess)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, resp.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK, resp);
        }
    }
}