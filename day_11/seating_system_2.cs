using System.IO;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace seating_system_2{
    class seating_system_2{
        static int[] changeCoord(List<char[]> lines, string direction, int i, int j){
            try{
                if(lines[i][j] == 'L'){
                    return new int[2]{i,j};
                }else{
                    if(direction=="TLD"){
                        return changeCoord(lines, "TLD", i-1, j-1);
                    }else if(direction == "TD"){
                        return changeCoord(lines, "TD", i-1, j);
                    }else if(direction=="TRD"){
                        return changeCoord(lines, "TRD", i-1, j+1);
                    }else if(direction == "LD"){
                        return changeCoord(lines, "LD", i, j-1);
                    }else if(direction == "RD"){
                        return changeCoord(lines, "RD", i, j+1);
                    }else if(direction=="DLD"){
                        return changeCoord(lines, "DLD", i+1, j-1);
                    }else if(direction == "DD"){
                        return changeCoord(lines, "DD", i+1, j);
                    }else if(direction =="DRD"){
                        return changeCoord(lines, "DRD", i+1, j+1);
                    }
                }
            }catch(Exception){}
            return new int[2]{-1,-1};
        }
        static List<int[]> getPossibleSeats(List<char[]> lines, int i, int j){
            List<int[]> seats = new List<int[]>();
            seats.Add(changeCoord(lines, "TLD", i-1, j-1));
            seats.Add(changeCoord(lines, "TD", i-1, j));
            seats.Add(changeCoord(lines, "TRD", i-1, j+1));
            seats.Add(changeCoord(lines, "LD", i, j-1));
            seats.Add(changeCoord(lines, "RD", i, j+1));
            seats.Add(changeCoord(lines, "DLD", i+1, j-1));
            seats.Add(changeCoord(lines, "DD", i+1, j));
            seats.Add(changeCoord(lines, "DRD", i+1, j+1));
            return seats;
        }
        static int[] getDesiredSeat(List<int[]> seats){
            int desiredX = seats[0][0];
            for(int k = 1; k < seats.Count; k++)
                if(seats[k][0] < desiredX)
                    desiredX = seats[k][0];
            for(int m = seats.Count -1; m >= 0; m--)
                if(seats[m][0] != desiredX)
                    seats.RemoveAt(m);
            int desiredY = seats[0][1];
            for(int l = 1; l < seats.Count; l++){
                if(seats[l][1] < desiredY)
                    desiredY =seats[l][1];
            }
            //Console.WriteLine("DesiredX:{0}, DesiredY:{1}", desiredX, desiredY);           
            return new int[]{desiredX, desiredY};
        }
        static int adjacentOccupiedSeats(List<char[]> lines, int i, int j){
            int adjacentOccupied = 0;
            StringBuilder builder = new StringBuilder();
            for (int k = i-1;k<i+2; k++){
                for (int m = j-1;m<j+2; m++){
                    try{
                        if(k!=i || m!=j)
                            builder.Append(lines[k][m]);
                    }catch(Exception e){continue;}
                }
            }
            adjacentOccupied = Regex.Matches(builder.ToString(),@"(#|\.)").Count;
            return adjacentOccupied;
        }
        static List<char[]> convertToCharArrs(string[] lines){
            List<char[]> newLines = new List<char[]>();
            foreach(string var in lines)
                newLines.Add(var.ToCharArray());
            return newLines;
        }
        static int getOccupiedSeats(List<char[]> lines){
            int seatsTotal = 0;
            bool isDone = false; 
            //Console.WriteLine("({0}, {1})", example[0], example[1]);
            //while(!isDone){
                Console.WriteLine("\nOLD");
                foreach (char[] item in lines)
                    Console.WriteLine(string.Join("",item));
                List<char[]> old = lines;
                for(int i=0;i<lines.Count;i++){
                    //Console.WriteLine(lines[i]);
                    for(int j=0; j<lines[i].Length;j++){
                        List<int[]> seats = getPossibleSeats(lines, i, j);
                        int[] xy = getDesiredSeat(seats);
                        int occupied = adjacentOccupiedSeats(lines, xy[0], xy[1]);
                        if(lines[i][j] == 'L'){
                            if(occupied == 0){
                                lines[i][j] = '#';
                            }
                            if(!xy.SequenceEqual(new int[]{-1, -1}))
                                lines[xy[0]][xy[1]] = '#';
                        }else if(lines[i][j] == '#' && occupied >= 5){
                            lines[i][j] = 'L';
                        }/*else if(lines[i][j] == '.'){
                            lines[i][j] = '.';
                        }*/else{}//Stays the same (should include '.')
                    }
                }
                Console.WriteLine("\nNEW");
                foreach (var item in old)
                    Console.WriteLine(string.Join("", item));
                if(!lines.SequenceEqual(old)){
                    lines = old;
                    old.Clear();
                    Console.WriteLine("New Seating order");
                }else{
                    isDone = true;
                    /* Counts occupied seats
                    StringBuilder final = new StringBuilder();
                    foreach (char[] item in lines)  
                        final.Append(string.Join("", item));
                    seatsTotal = Regex.Matches(final.ToString(),"#").Count;*/
                }
            //}
            return seatsTotal;
        }
        static void Main(String[] args){
            string path = Path.GetFullPath("test.txt");
            string[] lines = System.IO.File.ReadAllLines(@path);
            List<char[]> linesTwo = convertToCharArrs(lines);
            int occupiedSeats = getOccupiedSeats(linesTwo);
            Console.WriteLine("Number of Occupied Seats: {0}", occupiedSeats);
            //Answer < 2476
        }
    }
}