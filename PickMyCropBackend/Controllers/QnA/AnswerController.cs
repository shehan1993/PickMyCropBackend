using PickMyCropBackend.Models;
using PickMyCropBackend.Models.Data;
using PickMyCropBackend.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace PickMyCropBackend.Controllers
{
    public class AnswerController : ApiController
    {
        // Post: Answer
        [System.Web.Http.AllowAnonymous]
        public AnswerVM Post(AnswerVM model)
        {
            AnswerDTO dto = new AnswerDTO();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                dto.Answar = model.Answar;
                dto.QuestionId = model.QuestionId;
                string userId = "c234e83d-2d42-4fae-a479-ee35c231b818";//User.Identity.GetUserId();
                ApplicationUser currentUser = (new ApplicationDbContext()).Users.FirstOrDefault(x => x.Id == userId);
                dto.userId = currentUser.Id;

                db.Answers.Add(dto);
                db.SaveChanges();
            }
            //_DbContext.SaveChanges();
            return new AnswerVM(dto);
        }
    }
}