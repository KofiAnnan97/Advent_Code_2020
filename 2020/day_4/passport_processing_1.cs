using System.IO;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace passport_processing{
    class passport_processing_1{
        static string[] expectedFields = {"byr:", "iyr:", "eyr:", "hgt:", "hcl:", "ecl:", "pid:"};
        static bool hasExpectedFields(string val){
            if(val.Split(" ").Length < expectedFields.Length)
                return false;
            foreach(string pattern in expectedFields)
                if(!Regex.IsMatch(val, pattern))
                    return false;
            return true;
        }
        static int getValidPassports(string[] lines){
            int count = 0;
            string passport = "";
            for(int i = 0; i < lines.Length; i++){
                if(i == lines.Length-1 || lines[i] == ""){
                    if(hasExpectedFields(passport))
                        count+=1;
                    passport="";
                }else{
                    passport += " " + lines[i];
                }
            }
            return count;
        }       
        static void Main(string[] args){
            string path = Path.GetFullPath("data.txt");
            string[] lines = System.IO.File.ReadAllLines(@path);
            int valid_count = getValidPassports(lines);
            Console.WriteLine("Valid Passports: " + valid_count);
        }
    }
}