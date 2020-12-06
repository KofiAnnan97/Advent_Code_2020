using System.IO;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace custom_customs_1{
    class custom_customs_1{
        static int getGroupCount(string group, int numOfPeople){
            Dictionary<char, int> noDups = new Dictionary<char, int>();
            int count = 0;
            for(int i = 0; i < group.Length; i++){
                if(!noDups.ContainsKey(group[i]))
                    noDups.Add(group[i], 1);
                else
                    noDups[group[i]] += 1;
            } 
            foreach(var item in noDups)
                if(item.Value == numOfPeople)
                    count += 1;
            return count;
        }
        static int getCountTotal(string[] lines){
            int sum = 0;
            int people = 0;
            StringBuilder group = new StringBuilder();
            foreach(string line in lines){
                if(line == ""){
                    sum += getGroupCount(group.ToString(), people);
                    group.Clear();
                    people = 0;
                }else{
                    group.Append(line); 
                    people+=1;
                }
            }
            sum += getGroupCount(group.ToString(), people);
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