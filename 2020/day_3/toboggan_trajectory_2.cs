using System.IO;
using System;

namespace toboggan_trajectory_2{
    class toboggan_trajectory_2{
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
            long[] slopes = new long[5]{
                (long)find_hit_trees(lines, 1, 1),
                (long)find_hit_trees(lines, 3, 1),
                (long)find_hit_trees(lines, 5, 1),
                (long)find_hit_trees(lines, 7, 1),
                (long)find_hit_trees(lines, 1, 2)
            };
            long product = slopes[0] * slopes[1] * slopes[2] * slopes[3] * slopes[4];
            Console.WriteLine("Trees hit: " + product.ToString());
            //Answer is 2983070376
        }
    }
}