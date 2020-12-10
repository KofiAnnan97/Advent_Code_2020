using System.IO;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace adapter_array_1{
    class adapter_array_1{
        static int getmultiJoltDifferences(string[] lines){
            List<int> jolts = new List<int>();
            jolts.Add(0);
            foreach (string item in lines)
                jolts.Add(int.Parse(item));
            jolts.Sort();
            int oneJolts = 0;
            int threeJolts = 0;
            for(int i=0;i<jolts.Count-1;i++){
                int curr = jolts[i];
                int next = jolts[i+1];
                if(next - curr == 1)
                    oneJolts++;
                else if(next-curr == 3)
                    threeJolts++;
            }
            return oneJolts * (threeJolts+1);
        }
        static void Main(String[] args){
            string path = Path.GetFullPath("data.txt");
            string[] lines = System.IO.File.ReadAllLines(@path);
            int diff = getmultiJoltDifferences(lines);
            Console.WriteLine("Difference: {0}", diff);
        }
    }
}