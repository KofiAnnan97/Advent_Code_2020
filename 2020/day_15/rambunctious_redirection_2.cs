using System.IO;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace rambunctious_redirection_2{
    class rambunctious_redirection_2{       
        static int GetNthTerm(string[] lines, int nTerm){
            string[] starter = Regex.Split(lines[0], ",");
            Dictionary<int,int[]> seq = new Dictionary<int,int[]>();
            int lastKey = 0;
            for(int i = 0;i < starter.Length;i++){
                seq.Add(int.Parse(starter[i]), new int[]{-1,i});
                lastKey = int.Parse(starter[i]);
            }
            for(int j = starter.Length; j < nTerm; j++){
                int[] temp = seq[lastKey];
                if(temp[0]==-1){
                    if(seq.ContainsKey(0))
                        seq[0] = new int[]{seq[0][1], j};
                    else
                        seq.Add(0,new int[]{-1,j});
                    
                    lastKey=0;
                }else{
                    lastKey = seq[lastKey][1]-seq[lastKey][0];
                    if(seq.ContainsKey(lastKey))
                        seq[lastKey] = new int[]{seq[lastKey][1], j};
                    else
                        seq.Add(lastKey, new int[]{-1, j});
                }
            }
            return lastKey;
        }
        static void Main(String[] args){
            string path = Path.GetFullPath("data.txt");
            string[] lines = System.IO.File.ReadAllLines(@path);
            int nTerm = 30000000;
            int nTermVal = GetNthTerm(lines, nTerm);
            Console.WriteLine("Turn {0}: {1}", nTerm, nTermVal);
        }
    }
}