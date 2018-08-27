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
    public class BatturKategorierApiController : ApiController
    {
        private ApplicationUnit _unit = new ApplicationUnit();



        [HttpGet]
        [ActionName("Edit")]
        //[Authorize(Roles= "admin, manager, user")]
        public BatturKategori Get(int id)
        {
            BatturKategori batturKategori = this._unit.BatturKategorier.GetById(id);




            if (batturKategori == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return batturKategori;
        }

        //[Authorize()]
        public HttpResponseMessage Put(int id, [FromBody]BatturKategori batturKategori)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != batturKategori.BatturKategoriId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            BatturKategori existingBatturKategori = this._unit.BatturKategorier.GetById(id);
            _unit.BatturKategorier.Detach(existingBatturKategori);

            this._unit.BatturKategorier.Update(batturKategori);

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
        public HttpResponseMessage Post(BatturKategori batturKategori)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this._unit.BatturKategorier.Add(batturKategori);
                    this._unit.SaveChanges();

                    HttpResponseMessage result =
                        Request.CreateResponse(HttpStatusCode.Created, batturKategori);

                    result.Headers.Location =
                        new Uri(Url.Link("DefaultApi", new { id = batturKategori.BatturKategoriId }));

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
            BatturKategori batturKategori = this._unit.BatturKategorier.GetById(id);

            if (batturKategori == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            this._unit.BatturKategorier.Delete(batturKategori);

            try
            {
                this._unit.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, batturKategori);
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
