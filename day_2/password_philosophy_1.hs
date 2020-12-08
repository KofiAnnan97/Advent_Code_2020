import System.IO
import Control.Monad
import Text.Read
--import Text.Regex.TDFA
--import Text.Regex.TDFA.Text ()

{-
check_policy :: String -> Int
check_policy policy = do    
    low :: Int
    high :: Int
    checkChar :: Char
    password :: String
    let count = 0
    if notElem checkChar password
        then return False
    else if elem checkChar password
        then count <- return (count + 1) 
    else count <- return count
-}
{-
    Take in a file and return a list of strings 
    where each line is a single string.
-}

parseFile:: IO [String]
parseFile = (map(map read . words) . lines) <$> (readFile "data.txt")

main::IO()
main = do
    --let count = 0
    let vals = parseFile
    hPrint vals
 
{-
main = do
    path :: String
    let path = "data.txt"
    count <- (parse_policies path)
    putStr "Count: "
    print()
-}