using System;
using System.Collections.Generic;
using System.Text;

namespace RailwayManagementSystem
{
    class Trains
    {
        public int TrainId { get; set; }
        public int TrainNo { get; set; }
        public string TrainName { get; set; }
        public string SourceCity { get; set; }
        public string DestinationCity { get; set; }

    }

    class Stations
    {
        public int StationNo { get; set; }
        public string StationName { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public int TrainId { get; set; }
        
    }

    class Days
    {
        public string Day { get; set; }
        public int TrainId { get; set; }
      
    }
      
}
