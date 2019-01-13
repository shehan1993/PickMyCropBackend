using PickMyCropBackend.Models;
using PickMyCropBackend.Models.Data;
using PickMyCropBackend.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace PickMyCropBackend.Controllers.Advertestment
{
    public class AdvertiestmentController : ApiController
    {
        //// GET: Advertiestment
        [AllowAnonymous]
        public AdvertisetmentVM Get(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                AdvertisetmentDTO adDTO = db.Advertisetment.Find(id);
                if (adDTO == null)
                {
                    throw new Exception("No such advertisetment");
                }
                ImagesForAdDTO img =db.ImageForAdvertiestment.FirstOrDefault(x => x.AdvertisetmentId == adDTO.Id);
                AdvertisetmentVM model = new AdvertisetmentVM(adDTO);
                model.Image = img.Image;
                return model;
            }   
        }
        //POST: Advertiestment
        [HttpPost]
        [Route("api/UploadImage")]
        public AdvertisetmentVM Post(AdvertisetmentVM model) {
            //return new AdvertisetmentVM();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                string userId = ((System.Security.Claims.ClaimsIdentity)User.Identity).
                                FindFirst("UserId").Value;
                AdvertisetmentDTO dto = new AdvertisetmentDTO();
                dto.vegtype = model.vegtype;
                dto.amount = model.amount;
                dto.price = model.price;
                dto.lat = model.lat;
                dto.lng = model.lng;
                dto.userId = userId;
                db.Advertisetment.Add(dto);
                db.SaveChanges();

                ImagesForAdDTO imgdto = new ImagesForAdDTO();
                imgdto.AdvertisetmentId =dto.Id;
                imgdto.Image = model.Image;

                db.ImageForAdvertiestment.Add(imgdto);
                db.SaveChanges();
            }
            return null;
        }
    }
}