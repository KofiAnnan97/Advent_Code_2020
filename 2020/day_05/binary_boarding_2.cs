using System.IO;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace binary_boarding_1{
    class binary_boarding_1{
        static int getPoint(string val, char lower, char upper, int limit){
            int low = 0;
            int high = limit-1;
            for(int i = 0; i < val.Length; i++){
                if(i == val.Length-1){
                    if(val[i] == lower)
                        return low;
                    else if(val[i] == upper)
                        return high;
                }else{
                    if(val[i] == lower)
                        high -= (high-low+1)/2;
                    else if(val[i] == upper)
                        low += (high-low-1)/2 + 1;
                }
            }
            return -1;
        }
        static int getSeatID(int row, int col){
            return (row * 8) + col;
        }
        static Dictionary<int, string> getFullSeats(string[] seats){
            Dictionary<int, string> temp = new Dictionary<int, string>();
            int rowLimit = 128;
            int colLimit = 8;
            foreach(string seat in seats){
                int row = getPoint(seat.Substring(0, 7),'F', 'B', rowLimit);
                int col = getPoint(seat.Substring(7),'L', 'R', colLimit);
                int currSeatID = getSeatID(row, col);
                temp.Add(currSeatID, seat);
            }
            return temp;
        }
        static void Main(String[] args){
            string path = Path.GetFullPath("data.txt");
            string[] lines = System.IO.File.ReadAllLines(@path);
            Dictionary<int, String> seats = getFullSeats(lines);
            List<int> seatNums = new List<int>();
            foreach(var item in seats){
                seatNums.Add(item.Key);
            }
            seatNums.Sort();
            for(int j = 0; j < seatNums.Count-2;j++){
                if(seatNums[j+1] - seatNums[j] == 2){
                        Console.WriteLine("Boarding Pass: {0}, SeatID: {1}", seats[seatNums[j]], seatNums[j]);
                        Console.WriteLine("Boarding Pass: {0}, SeatID: {1}", seats[seatNums[j+1]], seatNums[j+1]);
                    }
            }
        }
    }
}