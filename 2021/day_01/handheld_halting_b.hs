import System.IO
import Data.Array

check:: [Int] -> Int -> Int
check nums 1 = greaterThan (head nums) (nums!!1)
check nums i = greaterThan (nums!!(i-1)) (nums!!i) + check nums (i-1)

greaterThan :: Int -> Int -> Int 
greaterThan x y = if x > y then 1 else 0

makeSumsList:: [Int] -> Int -> [Int]
makeSumsList nums 2 = [sumOfThree (head nums) (nums!!1) (nums!!2)]
makeSumsList nums i = sumOfThree (nums!!i) (nums!!(i-1)) (nums!!(i-2)) : makeSumsList nums (i-1)

sumOfThree:: Int -> Int -> Int -> Int
sumOfThree a b c = a + b + c

makeInteger:: [String] -> [Int]
makeInteger = map read

readLines:: FilePath -> IO [String]
readLines = fmap lines .  readFile

main = do
    contents <- readLines "data.txt"
    let nums = makeInteger contents
    let newContents = makeSumsList nums (length nums-1)
    let count = check newContents (length newContents-1)
    print count