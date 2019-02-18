using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PickMyCropBackend.Models
{
    public struct Position
    {
        public String id;
        public double Latitude;
        public double Longitude;
    }

    public struct distanceDataStruct
    {
        public String AdevertizementID;
        public Position userOnePosition;
        public Position userTwoPosition;
        public double distance;
        public double weight;
        public double price;
    }

    public class StructData
    {


    }
}