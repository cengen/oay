using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OAY.Data;
using OAY.Models;
using System.IO;


namespace OAY.Web.Controllers.Api
{//[Authorize]
    public class BatturerApiController : ApiController
    {
        private ApplicationUnit _unit = new ApplicationUnit();

        [HttpGet]
        [ActionName("Edit")]
        //[Authorize(Roles= "admin, manager, user")]
        public Battur Get(int id)
        {
            var battur = this._unit.Batturer.GetById(id);


            if (battur == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return battur;
        }

        //[Authorize()]
        public HttpResponseMessage Put(int id, [FromBody]Battur battur)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != battur.BatturId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            Battur existingBattur = this._unit.Batturer.GetById(id);
            _unit.Batturer.Detach(existingBattur);

            //beholder original Opprettet verdi
            if(battur.Opprettet == null)
            {
                battur.Opprettet = existingBattur.Opprettet;
            }
            

            this._unit.Batturer.Update(battur);

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
        public HttpResponseMessage Post(Battur battur)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this._unit.Batturer.Add(battur);
                    this._unit.SaveChanges();

                    HttpResponseMessage result =
                        Request.CreateResponse(HttpStatusCode.Created, battur);

                    result.Headers.Location =
                        new Uri(Url.Link("DefaultApi", new { id = battur.BatturId }));

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
            Battur battur = this._unit.Batturer.GetById(id);

            if (battur == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            this._unit.Batturer.Delete(battur);

            try
            {
                this._unit.SaveChanges();

               

                return Request.CreateResponse(HttpStatusCode.OK, battur);
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

    