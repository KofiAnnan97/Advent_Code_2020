using System.IO;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text.RegularExpressions;
using System.Text;

namespace encoding_error_2{
    class encoding_error_2{
        static int[] getWeaknessRange(string[] lines, int invalidNum){
            for(int i = 0; i < lines.Length; i++){
                int c = int.Parse(lines[i]);
                int low = c;
                int high = c;
                int sum = c;
                for(int j=i+1; j< lines.Length; j++){
                    int d = int.Parse(lines[j]);
                    if(d<low)
                        low = d;
                    else if(d>high)
                        high = d;
                    sum += d;
                    if(sum > invalidNum)
                        break;
                    else if(sum == invalidNum){
                        return new int[]{low,high};
                    }
                }
            }
            return new int[2];
        }

        static bool isValueValid(string[] lines, int start, int preambleLength, int value){
            int end = start+preambleLength+1;
            for(int j = start; j < end-1; j++){
                int a = int.Parse(lines[j]);
                for(int k=start; k < end-1; k++){
                    int b = int.Parse(lines[k]);
                    if(a!=b)
                        if(a+b == value)
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
            int[] range = getWeaknessRange(lines, vulnerableNum);
            int encryptWeakness = 0;
            foreach (int val in range)
                encryptWeakness += val;
            Console.WriteLine("Encryption Weakness:{0}",encryptWeakness);
        }
    }
}