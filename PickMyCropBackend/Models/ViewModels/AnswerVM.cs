using PickMyCropBackend.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PickMyCropBackend.Models.ViewModels
{
    public class AnswerVM
    {
        public AnswerVM() {
        }
        public AnswerVM(AnswerDTO row) {
            Id = row.Id;
            Answar = row.Answar;
            vots = row.vots;
            userId = row.userId;
            QuestionId = row.QuestionId;
        }
        public int Id { get; set; }
        public string Answar { get; set; }
        public int vots { get; set; }
        public string userId { get; set; }
        public string username { get; set; }
        public int QuestionId { get; set; }
    }

}