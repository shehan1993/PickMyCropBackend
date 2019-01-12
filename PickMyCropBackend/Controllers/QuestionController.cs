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
using System.Web.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;

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
                    int anscount = db.Answers.Where(x => x.QuestionId == qId)
                                         .ToArray().Count();

                    QuestionVM temp = new QuestionVM(QuestionDTOList[i]);
                    string userId = QuestionDTOList[i].starterId;
                    ApplicationUser currentUser = (new ApplicationDbContext()).Users.FirstOrDefault(x => x.Id == userId);

                    temp.username = currentUser.UserName;
                    temp.answarcount = anscount;
                    //temp.answers=ans;
                    QuestionVMList.Add(temp);
                }
            }
                return QuestionVMList;
        }
        // GET: Question/id
        [AllowAnonymous]
        public QuestionVM Get(int id)
        {
            QuestionVM QuestionVM = new QuestionVM();
            QuestionDTO QuestionDTO;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                QuestionDTO = db.Questions.Find(id);
                if (QuestionDTO==null) {
                    return null;
                }
                int qId = QuestionDTO.Id;
                List<AnswerVM> ans = db.Answers.Where(x => x.QuestionId == qId)
                                        .ToArray().Select(y => new AnswerVM(y)).ToList();
                foreach (AnswerVM temp in ans) {
                    string ansuserId = temp.userId;
                    ApplicationUser ansUser = db.Users.FirstOrDefault(x => x.Id == ansuserId);
                    temp.username = ansUser.UserName;
                }
                QuestionVM = new QuestionVM(QuestionDTO);
                string userId = QuestionDTO.starterId;
                ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == userId);

                QuestionVM.username = currentUser.UserName;
                QuestionVM.answers = ans;
                QuestionVM.answarcount = ans.Count();
                
            }
            return QuestionVM;
        }
        public QuestionVM Post(QuestionVM model)
        {
            QuestionDTO dto = new QuestionDTO();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                dto.Title = model.Title;
                dto.votes = model.votes;
                dto.question = model.question;
                
                string userId = ((System.Security.Claims.ClaimsIdentity)User.Identity).
                                FindFirst("UserId").Value;
                ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == userId);

                dto.starterId = currentUser.Id;
                //dto.tags = model.tags;

                db.Questions.Add(dto);
                db.SaveChanges();
            }
            return new QuestionVM(dto);
        }
    }
}