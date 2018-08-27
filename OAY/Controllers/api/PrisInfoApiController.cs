using System;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OAY.Data;
using OAY.Models;


namespace OAY.Web.Controllers.Api
{
    //[Authorize]
    public class PrisInfoApiController : ApiController
    {
        private readonly ApplicationUnit _unit = new ApplicationUnit();



        [HttpGet]
        [ActionName("Edit")]
        //[Authorize(Roles= "admin, manager, user")]
        public PrisInfo Get(int id)
        {
            var pris = _unit.PrisInfo.GetById(id);


            if (pris == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return pris;
        }

        //[Authorize()]
        public HttpResponseMessage Put(int id, [FromBody]PrisInfo prisInfo)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != prisInfo.PrisInfoId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            var existingPrisInfo = this._unit.PrisInfo.GetById(id);
            _unit.PrisInfo.Detach(existingPrisInfo);

            this._unit.PrisInfo.Update(prisInfo);

            try
            {
                this._unit.SaveChanges();
                //returner en verdi for å unngå å trigge feil-callbacken
                return Request.CreateResponse(HttpStatusCode.OK,
                    "{success: 'true', verb: 'PUT'}");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


       

      



    }
}
