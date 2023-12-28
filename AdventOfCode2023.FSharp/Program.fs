// For more information see https://aka.ms/fsharp-console-apps

let lines = getLines "Day6/input.txt"
let races = Day6.parseRaces lines
printfn "Total Margin: %i" (Day6.totalMarginOfError races)