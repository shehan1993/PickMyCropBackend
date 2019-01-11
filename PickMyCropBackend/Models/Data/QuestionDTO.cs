using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PickMyCropBackend.Models.Data
{
    [Table("tblQuestion")]
    public class QuestionDTO
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string question { get; set; }
        public int votes { get; set; }
        public ApplicationUser starter { get; set; }
        public virtual ICollection<VegCategoryDTO> tags { get; set; }
        public ICollection<AnswerDTO> answers { get; set; }
    }
}