using System.IO;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text.RegularExpressions;
using System.Text;

namespace handy_haversacks_1{
    class handy_haversacks_1{
        static string targetColor = "shiny gold";
        
        static ConcurrentDictionary<string,string> getBagColors(string[] lines){
            ConcurrentDictionary<string,string> colors = new ConcurrentDictionary<string, string>();
            foreach(var line in lines){
                string bag = Regex.Replace(line, @"(\sbags|\sbag|\.)", "");
                string[] main = bag.Split(" contain ");
                if(main[1] == "no other" || main[0] == targetColor)
                    colors.GetOrAdd(main[0], "0");
                else if(main[1].Contains(targetColor))
                    colors.GetOrAdd(main[0], "1");
                else
                    colors.GetOrAdd(main[0], main[1]);
            }
            return colors;
        }
        static int getBagColorCount(ConcurrentDictionary<string, string> colors){    
            List<string> canHoldTarget = new List<string>();
            var index = colors[targetColor];
            int count = 0;
            foreach (var item in colors)
                if(item.Value == "1")
                    canHoldTarget.Add(item.Key);
            while(canHoldTarget.Count != 0){
                List<string> tmp = new List<string>();
                foreach(string val in canHoldTarget){
                    count++;
                    foreach(var key in colors.Keys){
                        if(colors[key].Contains(val)){
                            tmp.Add(key);
                            colors.AddOrUpdate(key, "1", (k, v) => "1");
                        }
                    }
                }
                canHoldTarget.Clear();
                canHoldTarget = tmp;
            } 
            return count;
        }
        static void Main(String[] args){
            string path = Path.GetFullPath("data.txt");
            string[] lines = System.IO.File.ReadAllLines(@path);
            ConcurrentDictionary<string, string> colors = getBagColors(lines);
            int bagColors = getBagColorCount(colors);
            Console.WriteLine("Bag Colors: {0}", bagColors);
        }
    }
}