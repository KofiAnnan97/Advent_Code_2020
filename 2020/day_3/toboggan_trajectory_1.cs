using System.IO;
using System;

namespace toboggan_trajectory_1{
    class toboggan_trajectory_1{
        static int find_hit_trees(string[] lines, int right, int down){
            int tree_hit = 0;
            int index = 0;
            for(int j = 0; j < lines.Length; j+=down){
                if(index > lines[j].Length-1){
                    index-=lines[j].Length;
                }
                if (lines[j][index] == '#'){
                        tree_hit++;
                }
                //Console.WriteLine("Index: " + index);
                index+=right;
            }
            return tree_hit;
        }       
        static void Main(string[] args){
            string path = Path.GetFullPath("data.txt");
            string[] lines = System.IO.File.ReadAllLines(@path);
            int num_of_trees = find_hit_trees(lines, 3,1);
            Console.WriteLine("Trees hit: " + num_of_trees);
            //Answer is 247
        }
    }
}