using System.IO;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ticket_translation_1{
    class ticket_translation_1{
        static bool isTicketFieldInvalid(string ticketVal, List<string[]> daRules){
            foreach(string[] rule in daRules){
                int field = int.Parse(ticketVal);
                if(field >= int.Parse(rule[0]) && field <= int.Parse(rule[1]))
                    return true;
                else if(field >= int.Parse(rule[2]) && field <= int.Parse(rule[3]))
                    return true;
            }
            return false;
        }
        static int GetTicketErrorRate(string[] lines){
            List<string[]> tickets = new List<string[]>();
            List<string[]> daRules = new List<string[]>();
            string[] myTicket;
            int i = 0;
            while(lines[i] != ""){
                string tmp = Regex.Replace(lines[i], @".*?:\s", "");
                tmp = Regex.Replace(tmp, @"(-|\sor\s)", " ");
                daRules.Add(Regex.Split(tmp, " "));
                i++;
            }
            myTicket = Regex.Split(lines[i+2], ",");
            for (int k = i+5; k < lines.Length; k++)
                tickets.Add(Regex.Split(lines[k], ","));
            int sum = 0;
            foreach (string[] ticket in tickets)
                for(int j = 0; j < ticket.Length; j++)
                    if(!isTicketFieldInvalid(ticket[j], daRules))
                        sum += int.Parse(ticket[j]);
            return sum;
        }
        static void Main(String[] args){
            string path = Path.GetFullPath("data.txt");
            string[] lines = System.IO.File.ReadAllLines(@path);
            int errorRate = GetTicketErrorRate(lines);
            Console.WriteLine("Error Rate: {0}", errorRate);
        }
    }
}