using System.IO;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace shuttle_search_1{
    class shuttle_search_1{
        static Dictionary<int, List<string>> schedule = new Dictionary<int, List<string>>();
        static int[] getStartEndTime(int expectedTime, string[] buses){
            int highestID = 0;
            foreach (string bus in buses)
                if(int.Parse(bus) > highestID)
                    highestID = int.Parse(bus);
            int endPoint = 0;
            while(endPoint < expectedTime)
                endPoint += highestID;
            return new int[]{expectedTime, (endPoint+highestID)};
        }
        static void setBusSchedule(int expectedTime, string[] buses){
            int [] range = getStartEndTime(expectedTime, buses);
            for (int i = range[0]; i <= range[1]; i++){
                schedule.Add(i, new List<string>());
                foreach(string bus in buses){
                    if(i%int.Parse(bus)==0)
                        schedule[i].Add("D");
                    else
                        schedule[i].Add(".");
                }
            }        
        }
        static int getBusID(string[] lines){
            int earliestTimestamp = int.Parse(lines[0]);
            lines[1] = Regex.Replace(lines[1], "x,", "");
            string[] buses = Regex.Split(lines[1], ",");
            setBusSchedule(earliestTimestamp,buses);
            foreach(int key in schedule.Keys)
                for(int j=0;j<schedule[key].Count;j++)
                    if(schedule[key][j]=="D"){
                        int minutesWaited = key - earliestTimestamp;
                        return int.Parse(buses[j]) * minutesWaited;
                    }
            return -1;
        }
        static void Main(String[] args){
            string path = Path.GetFullPath("data.txt");
            string[] lines = System.IO.File.ReadAllLines(@path);
            int total = getBusID(lines);
            Console.WriteLine("Earliest Bus ID * Wait Time: {0}", total);
        }
    }
}