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
    public class MenyApiController : ApiController
    {
        private ApplicationUnit _unit = new ApplicationUnit();



        [HttpGet]
        [ActionName("Edit")]
        //[Authorize(Roles= "admin, manager, user")]
        public Meny Get(int id)
        {
            Meny meny = this._unit.Menyer.GetById(id);

            if (meny == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return meny;
        }

        //[Authorize()]
        public HttpResponseMessage Put(int id, [FromBody]Meny meny)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != meny.MenyId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            //trenger state for å si at det har skjedd endringer og lagre dem
            Meny existingMeny = this._unit.Menyer.GetById(id);
            _unit.Menyer.Detach(existingMeny);

            //beholder original Opprettet verdi
            if (meny.Opprettet == null)
            {
                meny.Opprettet = existingMeny.Opprettet;
            }


            this._unit.Menyer.Update(meny);

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
        public HttpResponseMessage Post(Meny meny)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this._unit.Menyer.Add(meny);
                    this._unit.SaveChanges();

                    HttpResponseMessage result =
                        Request.CreateResponse(HttpStatusCode.Created, meny);

                    result.Headers.Location =
                        new Uri(Url.Link("DefaultApi", new { id = meny.MenyId}));

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
            Meny meny = this._unit.Menyer.GetById(id);

            if (meny == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            this._unit.Menyer.Delete(meny);

            try
            {
                this._unit.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, meny);
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
