using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PickMyCropBackend.Models
{

    public class Haversine
    {
        private double Distance(Position pos1, Position pos2)
        {
            double R = 6371;

            double dLat = this.toRadian(pos2.Latitude - pos1.Latitude);
            double dLon = this.toRadian(pos2.Longitude - pos1.Longitude);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(this.toRadian(pos1.Latitude)) * Math.Cos(this.toRadian(pos2.Latitude)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));
            double d = R * c;

            return d;
        }

        private double toRadian(double val)
        {
            return (Math.PI / 180) * val;
        }

        public distanceDataStruct[] harvesineDistance(distanceDataStruct[] DataArrayOfFarmers)
        {

            int i = 0;

            foreach (distanceDataStruct data in DataArrayOfFarmers)
            {

                Position pos1 = data.userOnePosition;
                Position pos2 = data.userTwoPosition;
                DataArrayOfFarmers[i].distance = Distance(pos1, pos2);
                i++;

            }

            return DataArrayOfFarmers;
        }

        public double harvesineDistance(Position pos1, Position pos2)
        {

            return Distance(pos1, pos2);

        }
    }
}