using PickMyCropBackend.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PickMyCropBackend.Models.ViewModels
{
    public class QuestionVM
    {
        public QuestionVM() {
        }
        public QuestionVM(QuestionDTO row) {
            Id = row.Id;
            Title = row.Title;
            votes = row.votes;
            question = row.question;
            starterId = row.starterId;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string question { get; set; }
        public int votes { get; set; }
        public String starterId { get; set; }
        public virtual List<VegCategoryDTO> tags { get; set; }
        public List<AnswerVM> answers { get; set; }
    }
}