using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PickMyCropBackend.Models.Data
{
    public class Db : DbContext
    {
        //public DbSet<VegCategoryDTO> VegCategories { get; set; }
        //public DbSet<QuestionDTO> Questions { get; set; }
        //public DbSet<AnswerDTO> Answers { get; set; }
        //public DbSet<ApplicationUser> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<QuestionDTO>()
            //    .HasMany<VegCategoryDTO>(s => s.tags)
            //    .WithMany(c => c.Questions)
            //    .Map(cs =>
            //    {
            //        cs.MapLeftKey("QuestiontRefId");
            //        cs.MapRightKey("VegCategoryRefId");
            //        cs.ToTable("QuestiontVegCategory");
            //    });
            //modelBuilder.Entity<AnswerDTO>()
            //.HasRequired<QuestionDTO>(s => s.Question)
            //.WithMany(g => g.answers)
            //.HasForeignKey<int>(s => s.QuestionId)
            //.WillCascadeOnDelete(); ;
            //modelBuilder.Entity<VegCategoryDTO>().ToTable("tblVegCategory");
            //modelBuilder.Entity<QuestionDTO>().ToTable("tblQuestion");
            //modelBuilder.Entity<VegCategoryDTO>().ToTable("tblAnswers");
        }
    }
}