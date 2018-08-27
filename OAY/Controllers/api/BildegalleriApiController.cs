using System;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OAY.Data;
using OAY.Models;


namespace OAY.Web.Controllers.Api
{
    [Authorize]
    public class BildegalleriApiController : ApiController
    {
        private ApplicationUnit _unit = new ApplicationUnit();



        [HttpGet]
        [ActionName("Edit")]
        //[Authorize(Roles= "admin, manager, user")]
        public Bildegalleri Get(int id)
        {
            var bildegalleri = _unit.Bildegallerier.GetById(id);

            if (bildegalleri == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return bildegalleri;
        }

        [Authorize()]
        public HttpResponseMessage Put(int id, [FromBody]Bildegalleri bildegalleri)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != bildegalleri.BildegalleriId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            //trenger state for å si at det har skjedd endringer og lagre dem
            var existingBildegalleri = this._unit.Bildegallerier.GetById(id);
            _unit.Bildegallerier.Detach(existingBildegalleri);

           


            this._unit.Bildegallerier.Update(bildegalleri);

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
        [Authorize()]
        public HttpResponseMessage Post(Bildegalleri bildegalleri)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this._unit.Bildegallerier.Add(bildegalleri);
                    this._unit.SaveChanges();

                    HttpResponseMessage result =
                        Request.CreateResponse(HttpStatusCode.Created, bildegalleri);

                    result.Headers.Location =
                        new Uri(Url.Link("DefaultApi", new { id = bildegalleri.BildegalleriId }));

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

        [Authorize]
        public HttpResponseMessage Delete(int id)
        {
            Bildegalleri bildegalleri = this._unit.Bildegallerier.GetById(id);

            if (bildegalleri == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            this._unit.Bildegallerier.Delete(bildegalleri);

            try
            {
                this._unit.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, bildegalleri);
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
