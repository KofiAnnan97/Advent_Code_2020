using System.IO;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text.RegularExpressions;
using System.Text;

namespace encoding_error_1{
    class encoding_error_1{
        static bool isValueValid(string[] lines, int start, int preambleLength, int value){
            int end = start+preambleLength+1;
            for(int j = start; j < end-1; j++){
                int a = int.Parse(lines[j]);
                for(int k=start; k < end-1; k++){
                    int b = int.Parse(lines[k]);
                    if(a!=b)
                        if(a + b == value)
                            return true;
                }
            }
            return false;
        }

        static int getFirstVulnerableNum(string[] lines, int preambleLength){    
            for(int i=preambleLength; i < lines.Length; i++){
                int currNum = int.Parse(lines[i]);
                if(!isValueValid(lines, i-preambleLength, preambleLength, currNum))
                    return currNum;
            }
            return -1;
        }
        static void Main(String[] args){
            int preambleLength = 25; 
            string path = Path.GetFullPath("data.txt");
            string[] lines = System.IO.File.ReadAllLines(@path);
            int vulnerableNum = getFirstVulnerableNum(lines, preambleLength);
            Console.WriteLine("1st Vulnerable Num: {0}", vulnerableNum);
        }
    }
}