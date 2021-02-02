using System.IO;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace seating_system_1{
    class seating_system_1{
        static int adjacentOccupiedSeats(string[] lines, int i, int j){
            StringBuilder builder = new StringBuilder();
            for (int k = i-1;k<i+2; k++)
                for (int m = j-1;m<j+2; m++)
                    try{
                        if(k!=i || m!=j)
                            builder.Append(lines[k][m]);
                    }catch(IndexOutOfRangeException e){
                        continue;
                    }
            return Regex.Matches(builder.ToString(),"#").Count;;
        }
        static int getOccupiedSeats(string[] lines){
            bool isDone = false; 
            while(!isDone){
                string[] temp = new string[lines.Length];
                for(int i=0;i<lines.Length;i++){
                    StringBuilder newLine = new StringBuilder();
                    for(int j=0; j<lines[i].Length;j++){
                        int occupied = adjacentOccupiedSeats(lines, i, j);
                        if(lines[i][j] == 'L' && occupied == 0)
                            newLine.Append('#');
                        else if(lines[i][j] == '#' && occupied >= 4)
                            newLine.Append('L');
                        else
                            newLine.Append(lines[i][j]);
                    }
                    temp[i] = newLine.ToString();
                }
                if(!lines.SequenceEqual(temp)){
                    lines = temp;
                    temp = new string[lines.Length];
                }else
                    isDone = true;
            }
            StringBuilder final = new StringBuilder();
                foreach (string item in lines)
                    final.Append(item);
            return Regex.Matches(final.ToString(),"#").Count;
        }
        static void Main(String[] args){
            string path = Path.GetFullPath("data.txt");
            string[] lines = System.IO.File.ReadAllLines(@path);
            int occupiedSeats = getOccupiedSeats(lines);
            Console.WriteLine("Number of Occupied Seats: {0}", occupiedSeats);
        }
    }
}