﻿// For more information see https://aka.ms/fsharp-console-apps

let lines = getLines "Day4/test.txt"
printfn "Cards: %A" (Day4.solve2 lines)