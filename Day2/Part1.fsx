open System.IO
open System.Text.RegularExpressions

type Line = {
  Min: int
  Max: int
  Letter: char
  Password: string
}

let lineRegex = Regex @"(\d+)-(\d+)\ (\w):\ (\w+)"

let parseLine line =
  if lineRegex.IsMatch line then
    let result = lineRegex.Match line
    Some({ 
      Min = int (result.Groups.[1].Value)
      Max = int (result.Groups.[2].Value)
      Letter = result.Groups.[3].Value.[0]
      Password = result.Groups.[4].Value
    })
  else None 

let isValidPassword (line: Line) =
  let count = line.Password |> Seq.filter (fun e -> e = line.Letter) |> Seq.length
  count >= line.Min && count <= line.Max

let result = File.ReadAllLines "./Day2/input.txt" |> Seq.choose parseLine |> Seq.filter isValidPassword |> Seq.length
printfn "%i" result