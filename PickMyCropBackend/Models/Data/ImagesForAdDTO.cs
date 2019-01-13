using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PickMyCropBackend.Models.Data
{
    [Table("tblImagesForAd")]
    public class ImagesForAdDTO
    {
        [Key]
        public int Id { get; set; }
        public string Image { get; set; }
        public int AdvertisetmentId {get;set;}
    }
}