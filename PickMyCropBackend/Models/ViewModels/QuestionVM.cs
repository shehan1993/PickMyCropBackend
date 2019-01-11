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
            starterId = row.starter.Id;
            tags = row.tags;
            answers = row.answers;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string question { get; set; }
        public int votes { get; set; }
        public String starterId { get; set; }
        public virtual ICollection<VegCategoryDTO> tags { get; set; }
        public ICollection<AnswerDTO> answers { get; set; }
    }
}