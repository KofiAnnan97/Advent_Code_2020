using System.IO;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace rain_risk_1{
    class rain_risk_1{
        static string compassPoints = "E";
        static Dictionary<string,int> angles = new Dictionary<string,int>{
            {"N", 270},
            {"E", 0},
            {"S", 90},
            {"W", 180}
        };
        static int[] setWayPoint(int[] waypoint, string turn, int amount){
            if(amount == 180)
                return new int[]{-waypoint[0], -waypoint[1]};
            else if((turn=="L" && amount==90) || (turn=="R" && amount==270))
                return new int[]{waypoint[1],-1*waypoint[0]};
            else if((turn=="R" && amount==90 || (turn=="L" && amount==270)))
                return new int[]{-1*waypoint[1],waypoint[0]};
            return waypoint;
        }
        static void setDirection(string turn, int amount){
            int currAngle = angles[compassPoints];
            switch(turn){
                case "L":
                    int tmp = currAngle-amount;
                    if(tmp < 0)
                        currAngle = 360+tmp;
                    else
                        currAngle = tmp;
                    break;
                case "R":
                    currAngle = (currAngle+amount)%360;
                    break;
            }
            foreach (string key in angles.Keys)
                if(angles[key] == currAngle){
                    compassPoints = key;
                    break;
                }
        }
        static int getDistance(string[] lines){
            int[] point = {0,0};
            int[] waypoint = {10,-1};
            foreach (string action in lines){
                string move = action.Substring(0,1);
                int val = int.Parse(action.Substring(1));
                if(move == "F"){
                    if(waypoint[1] > 0)  //South
                        point[1] += Math.Abs(val*waypoint[1]);
                    if(waypoint[0] > 0)  //East
                        point[0] += Math.Abs(val*waypoint[0]);
                    if(waypoint[1] < 0)  //North
                        point[1] -= Math.Abs(val*waypoint[1]);
                    if (waypoint[0] < 0) //West
                        point[0] -= Math.Abs(val*waypoint[0]);
                }
                else if(move == "N")
                    waypoint[1] -= val;
                else if(move == "E")
                    waypoint[0] += val;
                else if(move == "S")
                    waypoint[1] += val;
                else if (move == "W")
                    waypoint[0] -= val; 
                else if(move == "L" || move == "R"){
                    setDirection(move, val);
                    waypoint = setWayPoint(waypoint, move, val);
                }    
            }
            return Math.Abs(point[0]) + Math.Abs(point[1]);
        }
        static void Main(String[] args){
            string path = Path.GetFullPath("data.txt");
            string[] lines = System.IO.File.ReadAllLines(@path);
            int distance = getDistance(lines);
            Console.WriteLine("Number of Occupied Seats: {0}", distance);
        }
    }
}