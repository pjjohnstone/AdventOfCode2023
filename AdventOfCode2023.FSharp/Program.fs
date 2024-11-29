// For more information see https://aka.ms/fsharp-console-apps

let lines = getLines "Day7/input.txt"
let hands = 
  lines
  |> List.map Day7.parseLine
printfn $"Total Value: %i{Day7.calculateValue hands}"