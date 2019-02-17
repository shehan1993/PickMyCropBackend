using PickMyCropBackend.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PickMyCropBackend.Models.ViewModels
{
    public class AdvertisetmentVM
    {
        public AdvertisetmentVM() {
        }
        public AdvertisetmentVM(AdvertisetmentDTO row) {
            Id = row.Id;
            price = row.price;
            amount = row.amount;
            vegtype = row.vegtype;
            vegid = row.vegid;
            lat = row.lat;
            lng = row.lng;
        }
        public int Id { get; set; }
        public int price { get; set; }
        public int amount { get; set; }
        public string vegtype { get; set; }
        public int vegid { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public string[] Image { get; set; }
    }
}