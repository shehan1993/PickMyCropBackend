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
                List<ImagesForAdDTO> imgObj =db.ImageForAdvertiestment.Where(x => x.AdvertisetmentId == adDTO.Id).ToArray().ToList();
                AdvertisetmentVM model = new AdvertisetmentVM(adDTO);
                string[] imgs= imgObj.Select(x => x.Image).ToArray();
                model.Image = imgs;
                return model;
            }   
        }

        //[AllowAnonymous]
        //public AdvertisetmentVM GetAllWithoutImage()
        //{
        //    using (ApplicationDbContext db = new ApplicationDbContext())
        //    {
        //        AdvertisetmentDTO adDTO = db.Advertisetment.fi;
        //        if (adDTO == null)
        //        {
        //            throw new Exception("No such advertisetment");
        //        }
        //        List<ImagesForAdDTO> imgObj = db.ImageForAdvertiestment.Where(x => x.AdvertisetmentId == adDTO.Id).ToArray().ToList();
        //        AdvertisetmentVM model = new AdvertisetmentVM(adDTO);
        //        string[] imgs = imgObj.Select(x => x.Image).ToArray();
        //        model.Image = imgs;
        //        return model;
        //    }
        //}

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
                dto.vegid = model.vegid;
                dto.amount = model.amount;
                dto.price = model.price;
                dto.lat = model.lat;
                dto.lng = model.lng;
                dto.userId = userId;
                db.Advertisetment.Add(dto);
                db.SaveChanges();
                ImagesForAdDTO imgdto;
                foreach (string img in model.Image) {
                    imgdto = new ImagesForAdDTO();
                    imgdto.AdvertisetmentId = dto.Id;
                    imgdto.Image = img;
                    db.ImageForAdvertiestment.Add(imgdto);
                    db.SaveChanges();
                }
                model.Id = dto.Id;
            }
            return model;
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("api/AdvertCountByCategory")]
        public List<VegitablecountbyCategoryVM> AdvertisementcountbyCategory() {
            List<VegCategoryVM> categoryVMList;
            List<VegitablecountbyCategoryVM> output = new List<VegitablecountbyCategoryVM>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                categoryVMList = db.VegCategories
                                    .ToArray()
                                    .Select(x => new VegCategoryVM(x))
                                    .ToList();
                VegitablecountbyCategoryVM model = new VegitablecountbyCategoryVM();
                foreach (VegCategoryVM cat in categoryVMList) {
                    int count=db.Advertisetment.Where(x => x.vegtype == cat.Name).ToArray().Length;
                    output.Add(new VegitablecountbyCategoryVM(cat, count));
                }
            }
            return output;
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("api/AdvertByCategory/{id}")]
        public List<AdvertisetmentVM> AdvertByCategory(int id)
        {
            List<AdvertisetmentVM> categoryVMList;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                string vegType = db.VegCategories.Find(id).Name;
                categoryVMList = db.Advertisetment.Where(x => x.vegtype == vegType)
                                    .ToArray()
                                    .Select(x => new AdvertisetmentVM(x))
                                    .ToList();
                foreach (AdvertisetmentVM ad in categoryVMList)
                {
                    List<ImagesForAdDTO> imgObj = db.ImageForAdvertiestment.Where(x => x.AdvertisetmentId == ad.Id).ToArray().ToList();
                    string[] imgs = imgObj.Select(x => x.Image).ToArray();
                    ad.Image = imgs;
                }
            }
            return categoryVMList;
        }
    }
}