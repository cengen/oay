using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OAY.Data;
using OAY.Models;

namespace OAY.Web.Controllers.api
{//[Authorize]
    public class SamarbeidspartnereApiController : ApiController
    {
        private ApplicationUnit _unit = new ApplicationUnit();

        [HttpGet]
        [ActionName("Edit")]
        //[Authorize(Roles= "admin, manager, user")]
        public Samarbeidspartner Get(int id)
        {
            Samarbeidspartner samarbeidspartner = this._unit.Samarbeidspartnere.GetById(id);


            if (samarbeidspartner == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return samarbeidspartner;
        }

        //[Authorize()]
        public HttpResponseMessage Put(int id, [FromBody]Samarbeidspartner samarbeidspartner)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != samarbeidspartner.SamarbeidspartnerId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            Samarbeidspartner existingSamarbeidspartner = this._unit.Samarbeidspartnere.GetById(id);
            _unit.Samarbeidspartnere.Detach(existingSamarbeidspartner);

            //beholder original Opprettet verdi
            if (samarbeidspartner.Opprettet == null)
            {
                samarbeidspartner.Opprettet = existingSamarbeidspartner.Opprettet;
            }


            this._unit.Samarbeidspartnere.Update(samarbeidspartner);

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


        [HttpPost]
        //[Authorize()]
        public HttpResponseMessage Post(Samarbeidspartner samarbeidspartner)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this._unit.Samarbeidspartnere.Add(samarbeidspartner);
                    this._unit.SaveChanges();

                    HttpResponseMessage result =
                        Request.CreateResponse(HttpStatusCode.Created, samarbeidspartner);

                    result.Headers.Location =
                        new Uri(Url.Link("DefaultApi", new { id = samarbeidspartner.SamarbeidspartnerId }));

                    return result;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //[Authorize]
        public HttpResponseMessage Delete(int id)
        {
            Samarbeidspartner samarbeidspartner = this._unit.Samarbeidspartnere.GetById(id);

            if (samarbeidspartner == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            this._unit.Samarbeidspartnere.Delete(samarbeidspartner);

            try
            {
                this._unit.SaveChanges();



                return Request.CreateResponse(HttpStatusCode.OK, samarbeidspartner);
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
