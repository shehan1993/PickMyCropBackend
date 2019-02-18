using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PickMyCropBackend.Models
{
    /**
    ** Count class functions are responsible to count the total,average parameters of a given farmers set.  
        **/

    public class Count
    {

        public double countWeight(distanceDataStruct[] DataArrayOfFarmers)
        {

            int len = DataArrayOfFarmers.Length;
            double weight = 0;
            for (int i = 0; i < len; i++)
            {
                weight += DataArrayOfFarmers[i].weight;
            }

            return weight;
        }
    }
}