using System.IO;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace handheld_game_console_1{
    class handheld_game_console_1{
        static string[] instructions = {"acc", "jmp", "nop"};
        static int getPosOrNeg(string val){
            if(Regex.IsMatch(val, @"\+\d+"))
                return int.Parse(Regex.Replace(val,@"\+",""));  
            else if(Regex.IsMatch(val, @"-\d+"))
                return -1 * int.Parse(Regex.Replace(val,"-",""));
            return -1;
        }
        static int getCountTotal(string[] lines){
            List<int> indexes = new List<int>();
            int accVal = 0;
            for(int i = 0; i < lines.Length;){
                string[] op = lines[i].Split(" ", 2);
                if(indexes.Contains(i))
                    return accVal;
                else{
                    indexes.Add(i);
                    if(op[0] == instructions[0]){
                        accVal += getPosOrNeg(op[1]);
                        i++;
                    }else if(op[0] == instructions[1])
                        i += getPosOrNeg(op[1]);
                    else if(op[0] == instructions[2])
                        i++;
                }
            }
            return accVal;
        }
        static void Main(String[] args){
            string path = Path.GetFullPath("data.txt");
            string[] lines = System.IO.File.ReadAllLines(@path);
            int accVal = getCountTotal(lines);
            Console.WriteLine("Accumulator Value: {0}", accVal);
        }
    }
}