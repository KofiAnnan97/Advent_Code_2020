using System.IO;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace custom_customs_1{
    class custom_customs_1{
        static int getGroupCount(string group){
            List<char> noDups = new List<char>();
            for(int i = 0; i < group.Length; i++)
                if(!noDups.Contains(group[i]))
                    noDups.Add(group[i]);
            return noDups.Count;
        }
        static int getCountTotal(string[] lines){
            int sum = 0;
            StringBuilder group = new StringBuilder();
            foreach(string line in lines){
                if(line == ""){
                    sum += getGroupCount(group.ToString());
                    group.Clear();
                }
                else
                    group.Append(line); 
            }
            sum += getGroupCount(group.ToString());
            return sum;
        }
        static void Main(String[] args){
            string path = Path.GetFullPath("data.txt");
            string[] lines = System.IO.File.ReadAllLines(@path);
            int sumOfCounts = getCountTotal(lines);
            Console.WriteLine("Sum of counts: {0}", sumOfCounts);
        }
    }
}