using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace PickMyCropBackend.Models
{
    /**
    ** Get the harvesine Distance of farmers
    ** Sort farmers array according to distance
    ** 
    **/

    public class FindFarmers
    {
        Dictionary<String, AdvertisingDetails> farmersAdvDetailsDic;
        Position buyerPosition;

        public FindFarmers(Dictionary<String, AdvertisingDetails> farmersAdvDetailsDic, Position buyerPosition)
        {
            this.farmersAdvDetailsDic = farmersAdvDetailsDic;
            this.buyerPosition = buyerPosition;
        }

        /**
        ** 
        **/
        public ArrayList getFarmersGroup(double amountOfKg)
        {
            ArrayList SearchResultFarmerLists = new ArrayList();

            distanceDataStruct[] DataArrayOfFarmers = getDistanceFromHaversine();
            distanceDataStruct[] SortedDataArrayOfFarmers = sortDataDistance(DataArrayOfFarmers);

            double maxHrvDistance = SortedDataArrayOfFarmers[SortedDataArrayOfFarmers.Length - 1].distance;

            distanceDataStruct[] distanceFilteredDataArrayOfFarmers = filterDataDistance(SortedDataArrayOfFarmers, 0, 1);

            double weightKg = countOfWeights(distanceFilteredDataArrayOfFarmers);

            distanceDataStruct[] sortWeights;
            distanceDataStruct[] sortPrice;

            if (weightKg >= amountOfKg)
            {
                sortWeights = sortDataWeights(distanceFilteredDataArrayOfFarmers);
                distanceDataStruct[] farmerSet_weights = selectFarmers_weights(sortWeights, amountOfKg);
                SearchResultFarmerLists.Add(farmerSet_weights);

                sortPrice = sortDataPrice(distanceFilteredDataArrayOfFarmers);
                distanceDataStruct[] farmerSet_price = selectFarmers_price(sortPrice, amountOfKg);
                SearchResultFarmerLists.Add(farmerSet_price);

                //sortPrice = sortDataPrice(distanceFilteredDataArrayOfFarmers);
                //distanceDataStruct[] farmerSet_price = selectFarmers_price(sortPrice, amountOfKg);
            }

            ArrayList sortedFarmersList = DataFormatConverter.arrayToArrayList(SortedDataArrayOfFarmers);

            ArrayList removedDataFrom_sortedFarmersList = new ArrayList();

            //nearest farmers -> radius <= 1 KM ; 
            //This is test radius anlysing reak world data we can get correct value for radius,  
            double radius = 1;

            Haversine hsv = new Haversine();
            while (sortedFarmersList.Count >= 1)
            {
                distanceDataStruct start = (distanceDataStruct)sortedFarmersList[0];
                sortedFarmersList.RemoveAt(0);
                removedDataFrom_sortedFarmersList.Add(start);

                ArrayList farmerSet_ArrayList = new ArrayList();

                while (removedDataFrom_sortedFarmersList.Count > 0)
                {
                    distanceDataStruct temp = (distanceDataStruct)removedDataFrom_sortedFarmersList[0];

                    farmerSet_ArrayList.Add((distanceDataStruct)removedDataFrom_sortedFarmersList[0]);

                    removedDataFrom_sortedFarmersList.RemoveAt(0);
                    double tempDistance = temp.distance;

                    int count = sortedFarmersList.Count;

                    for (int i = 0; i < count; i++)
                    {

                        if (sortedFarmersList.Count > 0)
                        {
                            distanceDataStruct stru = (distanceDataStruct)sortedFarmersList[i];

                            if (stru.distance - tempDistance > radius)
                            {
                                break;
                            }
                            double dist = hsv.harvesineDistance(temp.userTwoPosition, stru.userTwoPosition);

                            if (dist <= radius)
                            {
                                distanceDataStruct t1 = stru;
                                removedDataFrom_sortedFarmersList.Add(t1);
                                sortedFarmersList.Remove(stru);
                                i--;
                            }
                        }
                    }

                    foreach (distanceDataStruct stru in sortedFarmersList)
                    {
                        if (stru.distance - tempDistance > radius)
                        {
                            break;
                        }

                        double dist = hsv.harvesineDistance(temp.userTwoPosition, stru.userTwoPosition);

                        if (dist <= radius)
                        {
                            distanceDataStruct t1 = stru;
                            removedDataFrom_sortedFarmersList.Add(t1);
                            sortedFarmersList.Remove(stru);
                        }
                    }
                }

                distanceDataStruct[] farmerSet = farmerSet_ArrayList.ToArray(typeof(distanceDataStruct)) as distanceDataStruct[];
                SearchResultFarmerLists.Add(farmerSet);

            }

            return SearchResultFarmerLists;
        }

        /**
        ** 
        ** {Harvesine.cs -> Distance()} required (distanceDataStruct array) to process the data 
        ** getDistanceFromHaversine() convert (dictionay data structure) to (distance array) by using { DataFormatConverter.cs }   
        ** and return (distanceDataStruct array)
        **
        **/
        public distanceDataStruct[] getDistanceFromHaversine()
        {
            DataFormatConverter dfc = new DataFormatConverter();
            distanceDataStruct[] DataArrayOfFarmers = dfc.DicToDistanceDataStructArray(farmersAdvDetailsDic, buyerPosition);

            Haversine hvs = new Haversine();
            DataArrayOfFarmers = hvs.harvesineDistance(DataArrayOfFarmers);
            return DataArrayOfFarmers;
        }

        /**
        ** sortDataDistance() function sort the farmers ( distanceDataStruct array ) according to distance by using { sort.cs -> selectionSortDistance() }   
        **/
        public distanceDataStruct[] sortDataDistance(distanceDataStruct[] DataArrayOfFarmers)
        {
            Sorting sort = new Sorting();
            DataArrayOfFarmers = sort.selectionSortDistance(DataArrayOfFarmers);
            return DataArrayOfFarmers;
        }

        public distanceDataStruct[] sortDataWeights(distanceDataStruct[] distanceFilteredDataArrayOfFarmers)
        {
            Sorting sort = new Sorting();
            distanceFilteredDataArrayOfFarmers = sort.selectionSortWeight(distanceFilteredDataArrayOfFarmers);
            return distanceFilteredDataArrayOfFarmers;
        }

        public distanceDataStruct[] sortDataPrice(distanceDataStruct[] distanceFilteredDataArrayOfFarmers)
        {
            Sorting sort = new Sorting();
            distanceFilteredDataArrayOfFarmers = sort.selectionSortPrice(distanceFilteredDataArrayOfFarmers);
            return distanceFilteredDataArrayOfFarmers;
        }

        /**
        ** filterDataDistance() function filter the farmers (distanceDataStruct array) according to a given Distance. 
        **/
        public distanceDataStruct[] filterDataDistance(distanceDataStruct[] SortedDataArrayOfFarmers, double dStart, double dEnd)
        {
            Filter filter = new Filter();
            distanceDataStruct[] filteredDataArrayOfFarmers = filter.distanceFilter(SortedDataArrayOfFarmers, dStart, dEnd);
            return filteredDataArrayOfFarmers;
        }

        /**
        ** countOfWeights() function count the weight of vegitable in given (distanceDataStruct array).  
        **/
        public double countOfWeights(distanceDataStruct[] distanceFilteredDataArrayOfFarmers)
        {
            Count weights = new Count();
            double weightKG = weights.countWeight(distanceFilteredDataArrayOfFarmers);
            return weightKG;
        }


        /**
        ** selectFarmers_weights() give most weighted farmers as suggetion.  
        **/
        public distanceDataStruct[] selectFarmers_weights(distanceDataStruct[] sortWeights, double amountOfKg)
        {

            ArrayList farmerList = new ArrayList();

            int i = sortWeights.Length - 1;
            double initWeight = 0;

            while (initWeight <= amountOfKg)
            {
                farmerList.Add(sortWeights[i]);
                initWeight += sortWeights[i].weight;
                i--;
            }

            distanceDataStruct[] farmerSet = farmerList.ToArray(typeof(distanceDataStruct)) as distanceDataStruct[];
            return farmerSet;
        }

        public distanceDataStruct[] selectFarmers_price(distanceDataStruct[] sortPrice, double amountOfKg)
        {

            ArrayList farmerList = new ArrayList();

            int len = sortPrice.Length;
            double initWeight = 0;
            int i = 0;

            while (initWeight <= amountOfKg && i < len)
            {
                farmerList.Add(sortPrice[i]);
                initWeight += sortPrice[i].weight;
                i++;
            }

            distanceDataStruct[] farmerSet = farmerList.ToArray(typeof(distanceDataStruct)) as distanceDataStruct[];
            return farmerSet;
        }

    }
}