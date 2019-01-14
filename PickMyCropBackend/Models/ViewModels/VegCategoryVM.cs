using PickMyCropBackend.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PickMyCropBackend.Models.ViewModels
{
    public class VegCategoryVM
    {
        public VegCategoryVM() {
        }
        public VegCategoryVM(VegCategoryDTO row) {
            Id = row.Id;
            Name = row.Name;
            Description = row.Description;
            Image = row.Image;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}