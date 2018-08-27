using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OAY.Data;
using OAY.Models;


namespace OAY.Web.Controllers
{
    //[Authorize]
    public class HvaSkjerApiController : ApiController
    {
        private ApplicationUnit _unit = new ApplicationUnit();

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<HvaSkjer> Get()
        {
            return this._unit.HvaSkjer.GetAll();
        }

        [HttpGet]
        [ActionName("Edit")]
        //[Authorize(Roles= "admin, manager, user")]
        public HvaSkjer Get(int id)
        {
            HvaSkjer hvaSkjer = this._unit.HvaSkjer.GetById(id);
            if (hvaSkjer == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return hvaSkjer;
        }

        ////[Authorize()]
        //public HttpResponseMessage Put(int id, HvaSkjer hvaSkjer)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //    }

        //    if (id != hvaSkjer.HvaSkjerID)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }

        //    HvaSkjer existingHvaSkjer = this._unit.HvaSkjer.GetById(id);
        //    _unit.HvaSkjer.Detach(existingHvaSkjer);

        //    //beholder original Opprettet verdi
        //    hvaSkjer.Opprettet = existingHvaSkjer.Opprettet;

        //    this._unit.HvaSkjer.Update(hvaSkjer);

        //    try
        //    {
        //        this._unit.SaveChanges();

        //        //returner en verdi for å unngå å trigge feil-callbacken
        //        return Request.CreateResponse(HttpStatusCode.OK,
        //            "{success: 'true', verb: 'PUT'}");
        //    }
        //    catch (DbUpdateConcurrencyException ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //}


        [HttpPost]
        //[Authorize()]
        public HttpResponseMessage Post(HvaSkjer hvaSkjer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this._unit.HvaSkjer.Add(hvaSkjer);
                    this._unit.SaveChanges();

                    HttpResponseMessage result =
                        Request.CreateResponse(HttpStatusCode.Created, hvaSkjer);

                    //result.Headers.Location =
                    //    new Uri(Url.Link("DefaultApi", new { id = hvaSkjer.HvaSkjerID }));

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
            HvaSkjer hvaSkjer = this._unit.HvaSkjer.GetById(id);

            if (hvaSkjer == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            this._unit.HvaSkjer.Delete(hvaSkjer);

            try
            {
                this._unit.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, hvaSkjer);
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
