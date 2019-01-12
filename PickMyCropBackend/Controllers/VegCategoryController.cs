using PickMyCropBackend.Models;
using PickMyCropBackend.Models.Data;
using PickMyCropBackend.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
//using System.Web.Mvc;

namespace PickMyCropBackend.Controllers
{
    public class VegCategoryController: ApiController
    {
        // GET: VegCategories
        [AllowAnonymous]
        //[Route("VegCategories")]
        public List<VegCategoryVM> Get()
        {
            //Declare of the model
            List<VegCategoryVM> categoryVMList;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                //init the list
                categoryVMList = db.VegCategories
                                    .ToArray()
                                    .Select(x => new VegCategoryVM(x))
                                    .ToList();
            }

            //Return view with list
            return categoryVMList;
        }
        [AllowAnonymous]
        public VegCategoryVM Post(VegCategoryVM model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return null;
            //}
            VegCategoryDTO dto = new VegCategoryDTO();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                dto.Name = model.Name;
                dto.Description = model.Description;
                db.VegCategories.Add(dto);
                db.SaveChanges();
            }
            //_DbContext.SaveChanges();
            return new VegCategoryVM(dto);
        }
        [AllowAnonymous]
        public VegCategoryVM Put(VegCategoryVM model) {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                VegCategoryDTO dto = db.VegCategories.Find(model.Id);
                dto.Name = model.Name;
                dto.Description = model.Description;
                db.SaveChanges();
            }
                return model;
        }
        [AllowAnonymous]
        public VegCategoryVM Delete(VegCategoryVM model)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                VegCategoryDTO dto = db.VegCategories.Find(model.Id);
                db.VegCategories.Remove(dto);
                db.SaveChanges();
            }
            return null;
        }
    }
}