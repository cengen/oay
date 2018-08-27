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
    public class BloggsvarApiController : ApiController
    {
        private ApplicationUnit _unit = new ApplicationUnit();



        [HttpGet]
        [ActionName("Edit")]
        //[Authorize(Roles= "admin, manager, user")]
        public Bloggsvar Get(int id)
        {
            Bloggsvar bloggsvar = this._unit.Bloggsvar.GetById(id);

            if (bloggsvar == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return bloggsvar;
        }

        //[Authorize()]
        public HttpResponseMessage Put(int id, [FromBody]Bloggsvar bloggsvar)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != bloggsvar.BloggsvarId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            //trenger state for å si at det har skjedd endringer og lagre dem
            Bloggsvar existingBloggsvar = this._unit.Bloggsvar.GetById(id);
            _unit.Bloggsvar.Detach(existingBloggsvar);

            //beholder original Opprettet verdi
            if (bloggsvar.Opprettet == null)
            {
                bloggsvar.Opprettet = existingBloggsvar.Opprettet;
            }


            this._unit.Bloggsvar.Update(bloggsvar);

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
        public HttpResponseMessage Post(Bloggsvar bloggsvar)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this._unit.Bloggsvar.Add(bloggsvar);
                    this._unit.SaveChanges();

                    HttpResponseMessage result =
                        Request.CreateResponse(HttpStatusCode.Created, bloggsvar);

                    result.Headers.Location =
                        new Uri(Url.Link("DefaultApi", new { id = bloggsvar.BloggsvarId }));

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
            Bloggsvar bloggsvar = this._unit.Bloggsvar.GetById(id);

            if (bloggsvar == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            this._unit.Bloggsvar.Delete(bloggsvar);

            try
            {
                this._unit.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, bloggsvar);
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
