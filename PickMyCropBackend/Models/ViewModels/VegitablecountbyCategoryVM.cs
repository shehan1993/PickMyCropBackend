using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PickMyCropBackend.Models.ViewModels
{
    public class VegitablecountbyCategoryVM
    {
        public VegitablecountbyCategoryVM() { }
        public VegitablecountbyCategoryVM(VegCategoryVM cat, int count) {
            this.cat = cat;
            this.count = count;
        }
        public VegCategoryVM cat { get; set; }
        public int count { get; set; }
    }
}