open System.IO

let input = File.ReadAllLines "./Day3/input.txt"
let columns = (input.[0]).Length
let rows = input.Length

let move slope =
  let rec loop (slope: int * int) (column, row) (treesCount: int64) =
    if row < rows then
      match input.[row].[column] with
      | '#' -> loop slope ((column + (fst slope)) % columns, (row + snd slope)) (treesCount + int64 1)
      | _ -> loop slope ((column + (fst slope)) % columns, (row + snd slope)) treesCount
    else
      treesCount
  loop slope (0, 0) (int64 0)

let result = (move (1, 1)) * (move (3, 1)) * (move (5, 1)) * (move (7, 1)) * (move (1, 2))
printfn $"{result}"