module Day6

let distance duration press =
  (duration - press) * press

let possibleResults duration =
  List.init duration (fun v -> distance duration v)

let winningResults duration record =
  possibleResults duration
  |> List.filter (fun v -> v > record)
  |> List.length

let totalMarginOfError races =
  races
  |> List.map (fun (d,r) -> winningResults d r)
  |> List.fold (*) 1
  
let parseRaces (lines: string list) =
  lines
  |> List.map (fun s -> s.Split(':'))
  |> List.map (fun l -> l[1])
  |> List.map (fun s -> s.Split(' '))
  |> List.map (fun a -> Array.filter (fun v -> v <> "") a)
  |> List.map (fun a -> Array.map stringToInt a)
  |> List.map Array.toList
  |> fun l -> List.zip l[0] l[1]