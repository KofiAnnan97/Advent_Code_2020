using System.IO;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text.RegularExpressions;
using System.Text;

namespace handy_haversacks_2{
    class handy_haversacks_2{
        static string targetColor = "shiny gold";
        static ConcurrentDictionary<string,string> getBagColors(string[] lines){
            ConcurrentDictionary<string,string> colors = new ConcurrentDictionary<string, string>();
            foreach(var line in lines){
                string bag = Regex.Replace(line, @"(\sbags|\sbag|\.)", "");
                string[] main = bag.Split(" contain ", 2);
                if(main[1] == "no other")
                    colors.GetOrAdd(main[0], "0");
                else
                    colors.GetOrAdd(main[0], main[1]);
            }
            return colors;
        }
        static string getNumberOfBagsHelper(ConcurrentDictionary<string, string> colors, List<string> children, string index){ 
            int sum = 0;
            int multi = 0;
            int value = 0;
            int canHold = 0;
            foreach (var item in children)
                Console.Write("<{0}>",item);
            Console.WriteLine();
            string[] totalBags = index.Split(' ', 2);
            foreach(string child in children){
                Console.WriteLine("Child:{0}", child);
                if(Regex.IsMatch(child, @"^\d{1,2}$"))
                    return child;
                else{ 
                    string[] tmp = child.Split(' ', 2);
                    List<string> group = new List<string>(Regex.Split(colors[tmp[1]],", "));
                    multi = int.Parse(tmp[0]);
                    value = int.Parse(getNumberOfBagsHelper(colors, group, child));
                }
                canHold += multi;
                sum += (multi * value);
            }
            sum += canHold;
            Console.WriteLine("Value: {0}", totalBags[0]);
            Console.WriteLine("{0}:{1}", totalBags[1], sum);
            colors.AddOrUpdate(totalBags[0], value.ToString(), (k,v) => value.ToString());
            return sum.ToString();
        }
        static int getNumberOfBags(ConcurrentDictionary<string, string> colors){    
            List<string> nodes = new List<string>();
            string top = colors[targetColor];
            nodes = new List<string>(Regex.Split(top, @",\s"));
            foreach (var item in nodes)
                Console.Write("|{0}|",item);
            Console.WriteLine();
            string value = getNumberOfBagsHelper(colors, nodes, top);
            return int.Parse(value);
        }
        static void Main(String[] args){
            string path = Path.GetFullPath("data.txt");
            string[] lines = System.IO.File.ReadAllLines(@path);
            ConcurrentDictionary<string, string> colors = getBagColors(lines);
            int bagColors = getNumberOfBags(colors);
            Console.WriteLine("\"{0}\" bag contains: {1} bags", targetColor, bagColors);
        }
    }
}