using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace jurassic_jigsaw_1{
    class jurassic_jigsaw_1{
        static Dictionary<long, List<char[]>> tiles;
        static List<long> tileIDs =new List<long>();
        static void SetTiles(string[] lines){
            tiles = new Dictionary<long, List<char[]>>();
            List<char[]> tile = new List<char[]>();
            long tileNum = 0;
            foreach (string line in lines){
                if(line==""){
                    tiles.Add(tileNum, tile);
                    tileIDs.Add(tileNum);
                    tile = new List<char[]>();
                }else if(line.Contains("Tile"))
                    tileNum = long.Parse(Regex.Replace(line, @"([a-zA-Z]|\s|:)",""));
                else
                    tile.Add(line.ToCharArray());
            }
            tiles.Add(tileNum, tile);
            tileIDs.Add(tileNum);
        }
        static bool CheckFaces(List<char[]> tile, long other){
            List<char[]> tile2 = tiles[other];
            if(tile[0].SequenceEqual(tile2[tile2.Count-1]))   //up
                return true;
            else if(tile[tile.Count-1].SequenceEqual(tile2[0]))  //down
                return true;
            bool left = true;
            bool right = true;
            for(int k=0; k<tile.Count; k++){
                if(tile[k][0] != tile2[k][tile2.Count-1]) //left
                    left = false;
                if(tile[k][tile[k].Length-1] != tile2[k][0]) //right
                    right = false;
            }
            return (left || right);
        }
        static List<char[]> Rotate(List<char[]> tile){
            List<char[]> temp = new List<char[]>();
            for(int k=0;k<tile[0].Length;k++)
                temp.Add(new char[tile.Count]);
            for(int i=0;i<tile.Count;i++)
                for(int j=0;j<tile[i].Length;j++)
                    temp[j][tile.Count-i-1] = tile[i][j];
            return temp;
        }
        static List<char[]> FlipHorizontal(List<char[]> tile){
            List<char[]> temp = new List<char[]>();
            foreach(char[] t in tile)
                temp.Add(new char[t.Length]);
            for(int i=0;i<tile.Count;i++)
                for(int j=tile[i].Length-1;j>=0;j--)
                    temp[i][tile[i].Length-j-1] = tile[i][j];
            return temp;
        }    
        static List<char[]> FlipVertical(List<char[]> tile){
            List<char[]> temp = new List<char[]>();
            for(int i=tile.Count-1;i>=0;i--)
                temp.Add(tile[i]);
            return temp;
        }    
        static bool CheckManipulatedTile(List<char[]> tile, long other){
            if(CheckFaces(tile, other)) 
                return true;
            List<char[]> temp = Rotate(tile);
            for(int i=0;i<3;i++){
                if(CheckFaces(temp, other))
                    return true;
                temp = Rotate(temp);
            }
            temp = FlipVertical(tile);
            for(int i=0;i<3;i++){
                if(CheckFaces(temp, other))
                    return true;
                temp = Rotate(temp);
            }
            temp = FlipHorizontal(tile);
            for(int i=0;i<3;i++){
                if(CheckFaces(temp, other))
                    return true;
                temp = Rotate(temp);
            }
            return false;
        }
        static long GetCornersMulti(string[] lines){
            SetTiles(lines);
            List<long> cornerTiles = new List<long>(); 
            for(int i=0;i<tileIDs.Count;i++){
                int count=0;
                for(int j=0; j<tileIDs.Count;j++)
                    if(i!=j && CheckManipulatedTile(tiles[tileIDs[j]], tileIDs[i]))
                        count++;
                if(count == 2)
                    cornerTiles.Add(tileIDs[i]);
            }
            long multi = 1;
            foreach(long cornerID in cornerTiles)
                multi *= cornerID;
            return multi;
        }
        static void Main(String[] args){
            string path = Path.GetFullPath("data.txt");
            string[] lines = System.IO.File.ReadAllLines(@path);
            long cornerMulti = GetCornersMulti(lines);
            Console.WriteLine("Corners Multiplied: {0}", cornerMulti);
        }
    }
}