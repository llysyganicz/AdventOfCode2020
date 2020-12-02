open System.IO
open System.Text.RegularExpressions

type Line = {
  First: int
  Second: int
  Letter: char
  Password: string
}

let lineRegex = Regex @"(\d+)-(\d+)\ (\w):\ (\w+)"

let parseLine line =
  if lineRegex.IsMatch line then
    let result = lineRegex.Match line
    Some({ 
      First = int (result.Groups.[1].Value) - 1
      Second = int (result.Groups.[2].Value) - 1
      Letter = result.Groups.[3].Value.[0]
      Password = result.Groups.[4].Value
    })
  else None 

let isValidPassword (line: Line) =
  let firstChar = line.Password.[line.First]
  let secondChar = line.Password.[line.Second]
  firstChar <> secondChar && (firstChar = line.Letter || secondChar = line.Letter)

let result = File.ReadAllLines "./Day2/input.txt" |> Seq.choose parseLine |> Seq.filter isValidPassword |> Seq.length
printfn "%i" result