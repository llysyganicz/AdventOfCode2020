open System.IO

let input = File.ReadAllLines "./Day3/input.txt"
let columns = (input.[0]).Length
let rows = input.Length - 1

let rec move (slope: int * int) (column, row) treesCount =
  if row < rows then
    match input.[row].[column] with
    | '#' -> move slope ((column + (fst slope)) % columns, (row + snd slope)) (treesCount + 1)
    | _ -> move slope ((column + (fst slope)) % columns, (row + snd slope)) treesCount
  else
    treesCount

let result = move (3, 1) (0, 0) 0
printfn $"{result}"