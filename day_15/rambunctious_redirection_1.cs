using System.IO;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace rambunctious_redirection_1{
    class rambunctious_redirection_1{
        static int lastIndexOf(List<int> sequence, int i, int val){
            for(int k = i; k >=0;k--)
                if(sequence[k] == val)
                    return k;
            return -1;
        }
        
        static int GetNthTerm(string[] lines, int nTerm){
            string[] starter = Regex.Split(lines[0], ",");
            List<int> sequence = new List<int>();
            for(int i = 0;i < starter.Length;i++)
                sequence.Add(int.Parse(starter[i]));
            for(int j = starter.Length; j < nTerm;j++){
                int lastVal = sequence[j-1];
                int lastIndex = lastIndexOf(sequence, j-2, lastVal);
                if(lastIndex == -1)
                    sequence.Add(0);
                else
                    sequence.Add(j-lastIndex-1);
            }
            return sequence[nTerm-1];
        }
        static void Main(String[] args){
            string path = Path.GetFullPath("data.txt");
            string[] lines = System.IO.File.ReadAllLines(@path);
            int nTerm = 2020;
            int nTermVal = GetNthTerm(lines, nTerm);
            Console.WriteLine("Turn {0}: {1}", nTerm, nTermVal);
        }
    }
}