using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OAY.Data;
using OAY.Models;

namespace OAY.Web.Controllers.api
{
    //[Authorize]
    public class SamarbeidspartnerImagesApiController : ApiController
    {
        //private ApplicationUnit _unit = new ApplicationUnit();

        //[HttpGet]
        //[ActionName("Edit")]
        ////[Authorize(Roles= "admin, manager, user")]
        //public SamarbeidspartnerImage Get(int id)
        //{
        //    SamarbeidspartnerImage samarbeidspartnerImage = this._unit.SamarbeidspartnerImages.GetById(id);


        //    if (samarbeidspartnerImage == null)
        //    {
        //        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        //    }
        //    return samarbeidspartnerImage;
        //}

        ////[Authorize()]
        //public HttpResponseMessage Put(int id, [FromBody]SamarbeidspartnerImage samarbeidspartnerImage)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //    }

        //    if (id != samarbeidspartnerImage.SamarbeidspartnerImageId)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }

        //    SamarbeidspartnerImage existingSamarbeidspartnerImage = this._unit.SamarbeidspartnerImages.GetById(id);
        //    _unit.SamarbeidspartnerImages.Detach(existingSamarbeidspartnerImage);

        //    //beholder original Opprettet verdi
        //    if (samarbeidspartnerImage.Opprettet == null)
        //    {
        //        samarbeidspartnerImage.Opprettet = existingSamarbeidspartnerImage.Opprettet;
        //    }


        //    this._unit.SamarbeidspartnerImages.Update(samarbeidspartnerImage);

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


        //[HttpPost]
        ////[Authorize()]
        //public HttpResponseMessage Post(SamarbeidspartnerImage samarbeidspartnerImage)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            this._unit.SamarbeidspartnerImages.Add(samarbeidspartnerImage);
        //            this._unit.SaveChanges();

        //            HttpResponseMessage result =
        //                Request.CreateResponse(HttpStatusCode.Created, samarbeidspartnerImage);

        //            result.Headers.Location =
        //                new Uri(Url.Link("DefaultApi", new { id = samarbeidspartnerImage.SamarbeidspartnerImageId }));

        //            return result;
        //        }
        //        else
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //}

        ////[Authorize]
        //public HttpResponseMessage Delete(int id)
        //{
        //    SamarbeidspartnerImage samarbeidspartnerImage = this._unit.SamarbeidspartnerImages.GetById(id);

        //    if (samarbeidspartnerImage == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }

        //    this._unit.SamarbeidspartnerImages.Delete(samarbeidspartnerImage);

        //    try
        //    {
        //        this._unit.SaveChanges();



        //        return Request.CreateResponse(HttpStatusCode.OK, samarbeidspartnerImage);
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




    }
}
