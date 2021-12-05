import System.IO
import Data.Array

firstItemList :: [[i]] -> [i]
firstItemList [] = [] 
firstItemList xxs = [head xs | xs <- xxs, not(null xs)]

lastItemList :: [[j]] -> [j]
lastItemList [] = [] 
lastItemList xxs = [last xs| xs <- xxs, not(null xs)]

updatePos:: String -> [Int]
updatePos direction = do
    let split = words direction
    let val = split!!1
    if head split == "forward" then [read val :: Int, 0]
    else if head split == "up" then [0 , -read val :: Int]
    else if head split == "down" then [0 , read val :: Int]
    else [-1,-1]

multiple:: Int -> Int -> Int 
multiple x y  = x * y

readLines:: FilePath -> IO [String]
readLines = fmap lines .  readFile

followDirections:: [String] -> [[Int]]
followDirections = map updatePos

main = do
    contents <- readLines "data.txt"
    let directions = followDirections contents
    let x = sum (firstItemList directions)
    let y = sum (lastItemList directions)
    print (multiple x y)