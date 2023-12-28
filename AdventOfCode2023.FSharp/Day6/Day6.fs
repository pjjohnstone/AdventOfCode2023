module Day6

let distance (duration: int64) (press: int64) =
  (duration - press) * press

let possibleResults (duration: int64) =
  List.init (duration |> int) (fun v -> distance duration v)

let winningResults (duration: int64) (record: int64) =
  possibleResults duration
  |> List.filter (fun v -> v > record)
  |> List.length
  |> int64

let totalMarginOfError races =
  races
  |> List.map (fun (d,r) -> winningResults d r)
  |> List.fold (*) 1L
 
let parseRace (lines: string list) =
  lines
  |> List.map (fun s -> s.Split(':'))
  |> List.map (fun l -> l[1])
  |> List.map (fun s -> s.Split(' '))
  |> List.map Array.toList
  |> List.map (fun l -> List.filter (fun v -> v <> "") l)  

let parseRaces lines =
  parseRace lines
  |> List.map (fun l -> List.map stringToInt64 l)
  |> fun l -> List.zip l[0] l[1]

let parseRaces2 lines =
  parseRace lines
  |> List.map (fun l -> List.fold (+) "" l)
  |> List.map (fun l -> stringToInt64 l)
  |> fun l -> (l[0], l[1])