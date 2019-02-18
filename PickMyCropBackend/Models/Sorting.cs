using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PickMyCropBackend.Models
{
    public class Sorting
    {
        public distanceDataStruct[] selectionSortDistance(distanceDataStruct[] DataArray)
        {

            int length = DataArray.Length;

            if (length <= 1)
            {
                return DataArray;
            }

            for (int i = 0; i < length; i++)
            {

                int tempIndex = 0;
                for (int j = 1; j < length - i; j++)
                {

                    if (DataArray[tempIndex].distance < DataArray[j].distance)
                    {
                        tempIndex = j;
                    }

                }

                int setIndex = length - 1 - i;
                distanceDataStruct temp = DataArray[setIndex];
                DataArray[setIndex] = DataArray[tempIndex];
                DataArray[tempIndex] = temp;
            }

            return DataArray;
        }

        public distanceDataStruct[] selectionSortPrice(distanceDataStruct[] DataArray)
        {

            int length = DataArray.Length;
            if (length <= 1)
            {
                return DataArray;
            }

            for (int i = 0; i < length; i++)
            {
                int tempIndex = 0;
                for (int j = 1; j < length - i; j++)
                {
                    if (DataArray[tempIndex].price < DataArray[j].price)
                    {
                        tempIndex = j;
                    }
                }

                int setIndex = length - 1 - i;
                distanceDataStruct temp = DataArray[setIndex];
                DataArray[setIndex] = DataArray[tempIndex];
                DataArray[tempIndex] = temp;
            }

            return DataArray;
        }

        public distanceDataStruct[] selectionSortWeight(distanceDataStruct[] DataArray)
        {

            int length = DataArray.Length;

            if (length <= 1)
            {
                return DataArray;
            }


            for (int i = 0; i < length; i++)
            {
                int tempIndex = 0;
                for (int j = 1; j < length - i; j++)
                {

                    if (DataArray[tempIndex].weight < DataArray[j].weight)
                    {
                        tempIndex = j;
                    }

                }

                int setIndex = length - 1 - i;
                distanceDataStruct temp = DataArray[setIndex];
                DataArray[setIndex] = DataArray[tempIndex];
                DataArray[tempIndex] = temp;
            }
            return DataArray;
        }


    }
}