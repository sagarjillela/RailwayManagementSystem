using System;
using System.Collections.Generic;
using System.Text;

namespace RailwayManagementSystem
{
    class BL
    {
        public static List<Trains> TrainList(string day)
        {
            List<Trains> trainList= DAL.GetTrainList(day);
            return trainList;
        }

        public static List<Stations> StationList(int trainId)
        {
            List<Stations> stationList = DAL.GetStations(trainId);
            return stationList;
        }
    }
}
