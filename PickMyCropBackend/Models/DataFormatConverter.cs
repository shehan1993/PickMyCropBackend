using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/**
*converting dataformat as diffrent function required
**/

namespace PickMyCropBackend.Models
{
    public class DataFormatConverter
    {
        /**
        *coveting Dictionary data format to position array 
        **/

        public distanceDataStruct[] DicToDistanceDataStructArray(Dictionary<String, AdvertisingDetails> farmersAdvDetailsDic, Position buyerPosition)
        {

            int len = farmersAdvDetailsDic.Count;
            distanceDataStruct[] distanceDataArray = new distanceDataStruct[len];
            int i = 0;
            foreach (var keyValue in farmersAdvDetailsDic)
            {

                AdvertisingDetails temp = keyValue.Value;
                distanceDataArray[i].AdevertizementID = temp.AdevertizementID;
                distanceDataArray[i].userOnePosition = buyerPosition;
                Position data = new Position();
                data.id = temp.UserId;
                data.Latitude = temp.Latitude;
                data.Longitude = temp.Longitude;
                distanceDataArray[i].userTwoPosition = data;
                distanceDataArray[i].weight = temp.Weight;
                distanceDataArray[i].price = temp.Price;
                i++;
            }
            return distanceDataArray;
        }

        public static ArrayList arrayToArrayList(distanceDataStruct[] SortedDataArrayOfFarmers)
        {

            ArrayList temp = new ArrayList();
            int len = SortedDataArrayOfFarmers.Length;

            for (int i = 0; i < len; i++)
            {

                temp.Add(SortedDataArrayOfFarmers[i]);
            }

            return temp;
        }

    }
}