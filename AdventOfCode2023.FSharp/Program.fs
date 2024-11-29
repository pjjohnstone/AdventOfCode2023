// For more information see https://aka.ms/fsharp-console-apps

let lines = getLines "Day8/input.txt"
printfn $"Total Steps: %i{(AdventOfCode2023.FSharp.Day8.Day8.calculate lines)}"