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
        public AnswerVM Post(AnswerVM model)
        {
            AnswerDTO dto = new AnswerDTO();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                dto.Answar = model.Answar;
                dto.QuestionId = model.QuestionId;
                string userId = ((System.Security.Claims.ClaimsIdentity)User.Identity).
                                FindFirst("UserId").Value;
                ApplicationUser currentUser = (new ApplicationDbContext()).Users.FirstOrDefault(x => x.Id == userId);
                dto.userId = currentUser.Id;

                db.Answers.Add(dto);
                db.SaveChanges();
            }
            return new AnswerVM(dto);
        }
    }
}