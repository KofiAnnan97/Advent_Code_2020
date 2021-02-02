using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace crab_combat_1{
    class crab_combat_1{
        static Queue<int> GameLoop(Queue<int> p1, Queue<int> p2){
            while(p1.Count != 0 && p2.Count != 0){
                int a = p1.Dequeue();
                int b = p2.Dequeue();
                if(a>b){
                    p1.Enqueue(a);
                    p1.Enqueue(b);
                }else if(a<b){
                    p2.Enqueue(b);
                    p2.Enqueue(a);
                }
            }
            if(p1.Count > 0)
                return p1;
            else
                return p2;
        }
        static int GetWinnerValue(string[] lines){
            Queue<int> p1 = new Queue<int>();
            Queue<int> p2 = new Queue<int>();
            Queue<int> curr = new Queue<int>();
            foreach (string line in lines){
                if(line.Contains("Player 1:"))
                    curr = p1;
                else if(line.Contains("Player 2:"))
                    curr = p2;
                else if(line != "")
                    curr.Enqueue(int.Parse(line));
            }
            curr = GameLoop(p1,p2);
            int val = 0;
            while(curr.Count>0)
                val += (curr.Count * curr.Dequeue());
            return val;
        }
        static void Main(String[] args){
            string path = Path.GetFullPath("data.txt");
            string[] lines = System.IO.File.ReadAllLines(@path);
            int val = GetWinnerValue(lines);
            Console.WriteLine("Winning Value: {0}", val);
        }
    }
}