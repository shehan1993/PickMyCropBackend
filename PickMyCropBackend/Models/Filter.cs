using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PickMyCropBackend.Models
{
    public class Filter
    {

        /**
       * distance filters are applied to sorted array according distance
       **/
        public distanceDataStruct[] distanceFilter(distanceDataStruct [] DataArrayOfFarmers, double distance) {

            int len = DataArrayOfFarmers.Length;
            ArrayList  al = new ArrayList();
            int i = 0;
            while(DataArrayOfFarmers[i].distance <= distance) { 
                al.Add(DataArrayOfFarmers[i]);
                i++;
            }

            distanceDataStruct[] FilteredData = al.ToArray(typeof(distanceDataStruct)) as distanceDataStruct[];
            return FilteredData;
        }

        public distanceDataStruct[] distanceFilter(distanceDataStruct[] DataArrayOfFarmers, double start, double end) {

            int len = DataArrayOfFarmers.Length;
            ArrayList al = new ArrayList();
            int i = 0;
            while (DataArrayOfFarmers[i].distance <= end)
            {
                if (DataArrayOfFarmers[i].distance >= start)
                {
                    al.Add(DataArrayOfFarmers[i]);
                }
                i++;
            }

            distanceDataStruct[] FilteredData = al.ToArray(typeof(distanceDataStruct)) as distanceDataStruct[];
            return FilteredData;
        }


        /**
        ** {DataArrayOfFarmers} arrays are sorted to distance 
        **/
        public distanceDataStruct[] priceFilter(distanceDataStruct[] DataArrayOfFarmers, double price){

            int len = DataArrayOfFarmers.Length;
            ArrayList al = new ArrayList();
            for (int i = 0; i < len; i++) {
                if (DataArrayOfFarmers[i].price <= price) {
                    al.Add(DataArrayOfFarmers[i]);
                }
            }
            distanceDataStruct[] FilteredData = al.ToArray(typeof(distanceDataStruct)) as distanceDataStruct[];
            return FilteredData;

        }

     

    }
}