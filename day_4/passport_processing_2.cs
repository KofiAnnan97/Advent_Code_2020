using System.IO;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace passport_processing{
    class passport_processing_1{
        static string[] expectedFields = {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"};
        static bool hasExpectedFields(Dictionary<string, string> dict){
            foreach(string field in expectedFields){
                if(dict.Count == 0)
                    return false;
                else if(!dict.ContainsKey(field))
                    return false;
                else if (dict.ContainsKey(field)){
                    bool status = true;
                    var value = dict[field];
                    switch(field){
                        case "byr":
                            status = (int.Parse(value) >= 1920 && int.Parse(value) <= 2002);
                            break;
                        case "iyr":
                            status = (int.Parse(value) >= 2010 && int.Parse(value) <= 2020);
                            break;
                        case "eyr":
                            status = (int.Parse(value) >= 2020 && int.Parse(value) <= 2030);
                            break;
                        case "hgt":
                            if(Regex.IsMatch(value, "cm")){
                                int cm = int.Parse(value.Replace("cm", ""));
                                status = (cm >= 150 && cm <= 193);
                            } else if (Regex.IsMatch(value, "in")){
                                int imperial = int.Parse(value.Replace("in",""));
                                status = (imperial >= 59 && imperial <= 76);
                            } else
                                status = false;
                            break;
                        case "hcl":
                            status = Regex.IsMatch(value, "#[a-f0-9]{6}");
                            break;
                        case "ecl":
                            List<string> colors = new List<string>(){"amb", "blu", "brn", "gry", "grn", "hzl", "oth"};
                            status = colors.Contains(value);
                            break;
                        case "pid":
                            status = Regex.IsMatch(value, @"\d{9}");
                            break;
                    }
                    if(status == false)
                        return false;
                }
            }   
            return true;
        }

        static int getValidPassports(string[] lines){
            int count = 0;
            Dictionary<string, string> passport = new Dictionary<string, string>();
            for(int i = 0; i < lines.Length; i++){
                if(i == lines.Length-1 || lines[i] == ""){
                    if(hasExpectedFields(passport))
                        count+=1;
                    passport.Clear();
                }else{
                    string[] line = lines[i].Split(" ");
                    foreach (var item in line){
                        string[] tmp = item.Split(":");
                        passport.Add(tmp[0], tmp[1]);
                    }
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