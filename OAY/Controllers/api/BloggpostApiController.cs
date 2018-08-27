using System;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OAY.Data;
using OAY.Models;


namespace OAY.Web.Controllers.api
{
    //[Authorize]
    public class BloggpostApiController : ApiController
    {
        private ApplicationUnit _unit = new ApplicationUnit();



        [HttpGet]
        [ActionName("Edit")]
        //[Authorize(Roles= "admin, manager, user")]
        public Bloggpost Get(int id)
        {
            Bloggpost bloggpost = this._unit.Bloggposter.GetById(id);

            if (bloggpost == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return bloggpost;
        }

        //[Authorize()]
        public HttpResponseMessage Put(int id, [FromBody]Bloggpost bloggpost)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != bloggpost.BloggpostId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            //trenger state for å si at det har skjedd endringer og lagre dem
            Bloggpost existingBloggpost = this._unit.Bloggposter.GetById(id);
            _unit.Bloggposter.Detach(existingBloggpost);

            //beholder original Opprettet verdi
            if (bloggpost.Opprettet == null)
            {
                bloggpost.Opprettet = existingBloggpost.Opprettet;
            }


            this._unit.Bloggposter.Update(bloggpost);

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
        public HttpResponseMessage Post(Bloggpost bloggpost)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this._unit.Bloggposter.Add(bloggpost);
                    this._unit.SaveChanges();

                    HttpResponseMessage result =
                        Request.CreateResponse(HttpStatusCode.Created, bloggpost);

                    result.Headers.Location =
                        new Uri(Url.Link("DefaultApi", new { id = bloggpost.BloggpostId }));

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
            Bloggpost bloggpost = this._unit.Bloggposter.GetById(id);

            if (bloggpost == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            this._unit.Bloggposter.Delete(bloggpost);

            try
            {
                this._unit.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, bloggpost);
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
