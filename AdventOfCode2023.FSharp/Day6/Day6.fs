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
  