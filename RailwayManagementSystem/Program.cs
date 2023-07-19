using System;
using System.Collections.Generic;

namespace RailwayManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("Enter the date");
                    DateTime date = Convert.ToDateTime(Console.ReadLine());
                    string day = date.DayOfWeek.ToString();
                    List<Trains> trains = BL.TrainList(day);

                    foreach (Trains train in trains)
                    {
                        Console.WriteLine(train.TrainId + ": " + train.TrainName + "(" + train.TrainNo + ")    from " + train.SourceCity.ToUpper() + " to " + train.DestinationCity.ToUpper());

                    }
                    if (trains.Count != 0)
                    {
                        Console.WriteLine("Select a Train");
                        int trainNo = Convert.ToInt32(Console.ReadLine());
                        List<Stations> stations = BL.StationList(trainNo);

                        Console.WriteLine("Intermediate Station/s: ");
                        foreach (Stations station in stations)
                        {
                            Console.WriteLine("Station Name: " + station.StationName + "    Arrival Time: " + station.ArrivalTime + "    Departure Time: " + station.DepartureTime);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Sorry! No train is found for this date. Please try a different date");
                    }
                    Console.WriteLine("----------------------------------------------------------------");
                    Console.WriteLine("Press 0 to startover");
                    Console.WriteLine("Press any other key/s to exit");
                    int ans = Convert.ToInt32(Console.ReadLine());
                    if (ans != 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                    }
                }
                Console.ReadLine();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
       
        }
    }
}
