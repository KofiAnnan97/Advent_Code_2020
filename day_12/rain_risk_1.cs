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
        static void moveToPosition(int[] point, string direction, int amount){
            if(direction == "N")
                point[1] -= amount;
            else if(direction == "E")
                point[0] += amount;
            else if(direction == "S")
                point[1] += amount;
            else if (direction == "W")
                point[0] -= amount;
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
            foreach (string action in lines){
                string move = action.Substring(0,1);
                int val = int.Parse(action.Substring(1));
                if(move == "F")
                    moveToPosition(point, compassPoints, val);
                else if(move == "L" || move == "R")
                    setDirection(move, val);
                else
                    moveToPosition(point, move, val);
            }
            return Math.Abs(point[0]) + Math.Abs(point[1]);
        }
        static void Main(String[] args){
            string path = Path.GetFullPath("data.txt");
            string[] lines = System.IO.File.ReadAllLines(@path);
            int distance = getDistance(lines);
            Console.WriteLine("Distance from starting position: {0}", distance);
        }
    }
}