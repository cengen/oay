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
{
    //[Authorize]
    public class BatturImagesApiController : ApiController
    {
        private ApplicationUnit _unit = new ApplicationUnit();

 

        [HttpGet]
        [ActionName("Edit")]
        //[Authorize(Roles= "admin, manager, user")]
        public BatturImage Get(int id)
        {
            BatturImage batturImage = this._unit.BatturImages.GetById(id);

            if (batturImage == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return batturImage;
        }

        //[Authorize()]
        public HttpResponseMessage Put(int id, [FromBody]BatturImage batturImage)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != batturImage.ImageId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            BatturImage existingBatturImage = this._unit.BatturImages.GetById(id);
            _unit.BatturImages.Detach(existingBatturImage);

            //beholder original Opprettet verdi
            if (batturImage.Opprettet == null)
            {
                batturImage.Opprettet = existingBatturImage.Opprettet;
            }

            this._unit.BatturImages.Update(batturImage);

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
        public HttpResponseMessage Post(BatturImage batturImage)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this._unit.BatturImages.Add(batturImage);
                    this._unit.SaveChanges();

                    HttpResponseMessage result =
                        Request.CreateResponse(HttpStatusCode.Created, batturImage);

                    result.Headers.Location =
                        new Uri(Url.Link("DefaultApi", new { id = batturImage.ImageId }));

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
            BatturImage batturImage = this._unit.BatturImages.GetById(id);

            if (batturImage == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            this._unit.BatturImages.Delete(batturImage);

            try
            {
                this._unit.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, batturImage);
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
