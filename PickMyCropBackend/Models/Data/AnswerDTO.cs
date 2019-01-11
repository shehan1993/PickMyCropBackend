using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PickMyCropBackend.Models.Data
{
    [Table("tblAnswers")]
    public class AnswerDTO
    {
        [Key]
        public int Id { get; set; }
        public string Answar { get; set; }
        public int vots { get; set; }
        public Person user { get; set; }
        public int QuestionId { get; set; }
        public QuestionDTO Question { get; set; }
    }
}