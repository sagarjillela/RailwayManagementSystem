using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RailwayManagementSystem
{
    class DAL
    {
        public static string connectionString = "Data Source=BTECH1830156;Initial Catalog=RailwayManagementSystem;Integrated Security=true";

       public static  SqlConnection connection = new SqlConnection(connectionString);
        public static List<Trains> GetTrainList(string day)
        {



            string query1 = "select * from trains";
            SqlDataAdapter sdr1 = new SqlDataAdapter(query1, connection);
            DataTable dt1 = new DataTable();
            sdr1.Fill(dt1);

            string query = "select * from Days";
            SqlDataAdapter sdr = new SqlDataAdapter(query, connection);
            sdr.SelectCommand.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            List<int> trainsOfThatDay =new  List<int>();
            foreach(DataRow row in dt.Rows)
            {
                if (row[0].ToString() == day)
                {
                    Days tempList = new Days();
                    tempList.TrainId = Convert.ToInt32(row[1].ToString());
                    trainsOfThatDay.Add(tempList.TrainId);
                }
            }

            List<Trains> trainsList = new List<Trains>();
            foreach(DataRow row in dt1.Rows)
            {
                if (trainsOfThatDay.Contains(Convert.ToInt32(row[0].ToString())))
                {
                    Trains train = new Trains();
                    train.TrainId = Convert.ToInt32(row[0].ToString());
                    train.TrainNo = Convert.ToInt32(row[1].ToString());
                    train.TrainName = row[2].ToString();
                    train.SourceCity = row[3].ToString();
                    train.DestinationCity = row[4].ToString();
                    trainsList.Add(train);
                }
            }
            return trainsList;
        }

        public static List<Stations> GetStations(int trainNo)
        {
            string query1 = "select * from Stations";
            SqlDataAdapter sdr = new SqlDataAdapter(query1, connection);
            sdr.SelectCommand.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            sdr.Fill(dt);

            List<Stations> stationsList = new List<Stations>();
            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToInt32(row[4].ToString()) == trainNo)
                {
                    Stations tempList = new Stations();
                    tempList.StationNo = Convert.ToInt32(row[0].ToString());
                    tempList.StationName = row[1].ToString();
                    tempList.ArrivalTime = Convert.ToDateTime(row[2].ToString()).TimeOfDay;
                    tempList.DepartureTime = Convert.ToDateTime(row[3].ToString()).TimeOfDay;
                    tempList.TrainId = Convert.ToInt32(row[4].ToString());
                    stationsList.Add(tempList);   
                }
            }
            return stationsList;
        }
    }
}
