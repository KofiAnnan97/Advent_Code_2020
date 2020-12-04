using System.IO;
using System;

namespace passport_processing{
    class passport_processing_1{
       
        string[] expectedFields = new string["byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid", "cid"];

        static int getValidPassports(String[] lines){
            int count = 0;
            foreach(String l in lines){
                Console.WriteLine(l);
            }
            return count;
        }       
        static void Main(string[] args){
            string path = Path.GetFullPath("data.txt");
            string[] lines = System.IO.File.ReadAllLines(@path);
            int valid_count = getValidPassports(lines);
            Console.WriteLine("Valid Passports: " + valid_count);
            //Answer is 247
        }
    }
}