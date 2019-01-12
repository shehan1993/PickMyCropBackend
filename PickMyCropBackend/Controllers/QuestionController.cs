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
        public List<QuestionVM> Get()
        {
            List<QuestionVM> QuestionVMList = new List<QuestionVM>();
            List<QuestionDTO> QuestionDTOList;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                QuestionDTOList = db.Questions
                                    .ToArray()
                                    .ToList();
                for (int i = 0; i < QuestionDTOList.Count; i++) {

                    int qId = QuestionDTOList[i].Id;
                    List<AnswerVM> ans = db.Answers.Where(x => x.QuestionId == qId)
                                         .ToArray().Select(y => new AnswerVM(y)).ToList();
                    QuestionVM temp = new QuestionVM(QuestionDTOList[i]);
                    temp.answers=ans;
                    QuestionVMList.Add(temp);
                }
            }
                return QuestionVMList;
        }
        [AllowAnonymous]
        public QuestionVM Post(QuestionVM model)
        {
            QuestionDTO dto = new QuestionDTO();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                dto.Title = model.Title;
                dto.votes = model.votes;
                dto.question = model.question;
                string userId = "c234e83d-2d42-4fae-a479-ee35c231b818";//User.Identity.GetUserId();
                ApplicationUser currentUser = (new ApplicationDbContext()).Users.FirstOrDefault(x => x.Id == userId);

                dto.starterId = currentUser.Id;
                //dto.tags = model.tags;

                db.Questions.Add(dto);
                db.SaveChanges();
            }
            return new QuestionVM(dto);
        }
    }
}