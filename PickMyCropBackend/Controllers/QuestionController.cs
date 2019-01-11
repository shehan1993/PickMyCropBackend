using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Mvc;
using System.Web.Http;
using PickMyCropBackend.Models.ViewModels;
using PickMyCropBackend.Models.Data;
using PickMyCropBackend.Models;
using Microsoft.AspNet.Identity;

namespace PickMyCropBackend.Controllers
{
    public class QuestionController : ApiController
    {
        // GET: Question
        [AllowAnonymous]
        public List<QuestionDTO> Get()
        {
            List<QuestionVM> QuestionVMList;
            List<QuestionDTO> QuestionDTOList;
            using (Db db = new Db())
            {
                QuestionDTOList = db.Questions
                                    .ToArray()
                                    .ToList();
            }
                return QuestionDTOList;
        }
        [AllowAnonymous]
        public QuestionVM Post(QuestionVM model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return null;
            //}
            QuestionDTO dto = new QuestionDTO();
            using (Db db = new Db())
            {
                dto.Id = model.Id;
                dto.Title = model.Title;
                dto.votes = model.votes;
                dto.question = model.question;
                string userId = "e12a6764-2ab0-4821-9717-b5ecdd2ee857";//User.Identity.GetUserId();
                ApplicationUser currentUser = (new ApplicationDbContext()).Users.FirstOrDefault(x => x.Id == userId);

                dto.starter = currentUser;
                dto.tags = model.tags;
                dto.answers = model.answers;

                db.Questions.Add(dto);
                db.SaveChanges();
            }
            //_DbContext.SaveChanges();
            return new QuestionVM(dto);
        }
    }
}