using System.IO;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace docking_data_1{
    class docking_data_1{
        static Dictionary<string, long> storedVals = new Dictionary<string, long>();
        static char[] ToBinary(long value){
            string binary = Convert.ToString(value, 2);
            binary = binary.PadLeft(36, '0');
            return binary.ToCharArray();
        }
        static long OverwriteBits(string value, char[] mask){
            long num = long.Parse(Regex.Replace(value, @"mem\[\d+\]\s=\s", ""));
            char[] binary = ToBinary(num);
            for(int j=binary.Length-1;j>=0;j--){
                if(mask[j] == '0')
                    binary[j] = '0';
                else if(mask[j] == '1')
                    binary[j] = '1';
            } 
            return Convert.ToInt64(new string(binary), 2);
        }
        static long GetMemorySum(string[] lines){
            string mask = "";
            foreach(string line in lines){
                string[] parts = line.Split(" = ", 2);
                if(parts[0] == "mask")
                    mask = parts[1];
                else
                    storedVals[parts[0]] = OverwriteBits(line, mask.ToCharArray());
            }
            long sum = 0;
            foreach(string key in storedVals.Keys)
                sum += storedVals[key];
            return sum;
        }
        static void Main(String[] args){
            string path = Path.GetFullPath("data.txt");
            string[] lines = System.IO.File.ReadAllLines(@path);
            long memorySum = GetMemorySum(lines);
            Console.WriteLine("Sum of All Values in Memory: {0}", memorySum);
        }
    }
}