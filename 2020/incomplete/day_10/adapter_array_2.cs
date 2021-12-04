using System.IO;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace adapter_array_2{
    class adapter_array_2{

        static List<List<int>> getSegments(List<int> jolts){
            List<List<int>> segments = new List<List<int>>();
            for (int i = 0; i < jolts.Count-1; i++){
                //Console.WriteLine("Val:{0}", jolts[i]);
                for (int j= i+1; j < jolts.Count; j++){
                    if(jolts[j]-jolts[i] > 3 || jolts[j]-jolts[j-1] == 1){
                        if(j-i >2){    
                            List<int> segment = new List<int>();
                            Console.Write("[");
                            for (int k = i; k <j; k++){
                                Console.Write("{0},", jolts[k]);
                                segment.Add(jolts[k]);
                            }
                            Console.WriteLine("]");
                            segments.Add(segment);
                            i=j-1;
                            break;
                        }else
                            break;
                    }
                }
            }
            return segments;
        }
        static int getPermutationsHelper(List<int> jolts, int start, int end){
            /*if(end - start == 4){
                return 4;
            }else if(end - start == 2){
                return 3;
            }else if(end - start == 1){
                return 2;
            }*/
            return 0;
        }

        static double getPermutations(List<int> jolts){
            List<List<int>> segments = getSegments(jolts);
            double distinct = 1;
            for(int i = 0; i < segments.Count;i++){
                //distinct *= getPermutationsHelper({segments, );
            }
            return distinct;
        }
        static List<int> getOrderedJolts(string[] lines){
            List<int> jolts = new List<int>();
            jolts.Add(0);
            foreach (string item in lines)
                jolts.Add(int.Parse(item));
            jolts.Sort();
            jolts.Add(jolts[jolts.Count-1]+3);
            return jolts;
        }
        static void Main(String[] args){
            string path = Path.GetFullPath("test.txt");
            string[] lines = System.IO.File.ReadAllLines(@path);
            List<int> jolts = getOrderedJolts(lines);
            double permus = getPermutations(jolts);
            Console.WriteLine("Jolt Permutations: {0}", permus);
        }
    }
}