using System.IO;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace operation_order_1{
    class operation_order_1{
        static long doCalculation(string a, string b, string op){
            if(op == "+")
                return long.Parse(a) + long.Parse(b);
            else if(op == "*")
                return long.Parse(a) * long.Parse(b);
            return -1;
        }
        static string evalExpression(string expression){
            if(!expression.Contains("(") && !expression.Contains(")")){
                string[] vals = Regex.Split(expression, @"\s+");
                string total = vals[0];
                for(int j = 1; j<vals.Length-1;j+=2)
                    total = doCalculation(total, vals[j+1], vals[j]).ToString();
                return total;
            }else{
                int frontPar = 0;
                int backPar = 0;
                int start = 0;
                for(int k=0;k<expression.Length;k++){
                    if(expression[k] == '('){
                        if(frontPar == 0)
                            start = k;
                        frontPar++;
                    }else if(expression[k] == ')')
                        backPar++;
                    if(frontPar != 0 && frontPar==backPar){
                        string encased = expression.Substring(start,k-start+1);
                        string result = evalExpression(encased.Substring(1, encased.Length-2));
                        expression = expression.Replace(encased, result);
                        k = 0;
                        frontPar = 0;
                        backPar = 0;
                    }
                }
                return evalExpression(expression);
            }
        }
        static long GetHomeworkSum(string[] lines){
            long sum = 0;
            foreach (string expression in lines)
                sum += long.Parse(evalExpression(expression));
            return sum;
        }
        static void Main(String[] args){
            string path = Path.GetFullPath("data.txt");
            string[] lines = System.IO.File.ReadAllLines(@path);
            long sum = GetHomeworkSum(lines);
            Console.WriteLine("Sum: {0}", sum);
        }
    }
}