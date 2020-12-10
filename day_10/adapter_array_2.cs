using System.IO;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace adapter_array_2{
    class adapter_array_2{

        static void removeUnwantedJolts(List<List<int>> variations, List<int> jolts, int start, int end){
            for(int k = end-1; k > start; k++){
                jolts.RemoveAt(k);
            }
        }
        static int getPermutationsHelper(List<int> jolts, int prev, int next){
            
        }

        static int getPermutations(string[] lines){
            int distinct = 0;
            for(int i = 1; i < jolts.Count-2;i++){

            }
            return distinct;
        }
        static List<int> getOrderedJolts(string[] lines){
            List<int> jolts = new List<int>();
            jolts.Add(0);
            foreach (string item in lines)
                jolts.Add(int.Parse(item));
            jolts.Sort();
            //jolts.Add(jolts[jolts.Count-1]+3);
            return jolts;
        }
        static void Main(String[] args){
            string path = Path.GetFullPath("test.txt");
            string[] lines = System.IO.File.ReadAllLines(@path);
            int jolts = getOrderedJolts();
            int permus = getPermutations(lines);
            Console.WriteLine("Jolt Permutations: {0}", permus);
        }
    }
}