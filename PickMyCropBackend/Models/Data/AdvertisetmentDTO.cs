using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PickMyCropBackend.Models.Data
{
    [Table("tblAdvertisetment")]
    public class AdvertisetmentDTO
    {
        [Key]
        public int Id { get; set; }
        public int price { get; set; }
        public int amount { get; set; }
        public string vegtype { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public string userId { get; set; }
    }
}