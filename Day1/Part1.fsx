open System
open System.IO

let input = File.ReadAllLines "./Day1/input.txt" |> Seq.map (fun e -> int e) |> Seq.toList

for i = 0 to input.Length - 2 do
  for j = i + 1 to input.Length - 1 do
    if input.[i] + input.[j] = 2020 then printfn $"{input.[i] * input.[j]}"
  
