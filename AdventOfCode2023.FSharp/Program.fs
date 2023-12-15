// For more information see https://aka.ms/fsharp-console-apps

let lines = getLines "Day4/input.txt"
printfn "Scores: %A" (Day4.solve1 lines)