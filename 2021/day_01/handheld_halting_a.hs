import System.IO
import Data.Array

check:: [Int] -> Int -> Int
check nums 1 = lessThan (head nums) (nums!!1)
check nums i = lessThan (nums!!(i-1)) (nums!!i) + check nums (i-1)

lessThan :: Int -> Int -> Int 
lessThan x y = if x < y then 1 else 0

makeInteger:: [String] -> [Int]
makeInteger = map read

readLines:: FilePath -> IO [String]
readLines = fmap lines .  readFile

main = do
    contents <- readLines "data.txt"
    let nums = makeInteger contents
    let count = check nums (length nums-1)
    print count
