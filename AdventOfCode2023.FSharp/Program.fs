// For more information see https://aka.ms/fsharp-console-apps

let lines = getLines "Day1/input.txt"
printfn "Total of calibrations: %i" (Day1.solve1 lines)