module Day4

let stripCruft (str: string) =
  str.Split(' ')
  |> Array.filter (fun x -> x <> "")

let getNumbers array =
  array
  |> Array.toList
  |> List.map stringToInt

let card (line: string) =
  let halves = 
    line.Split('|') 
    |> Array.toList
  let winning = 
    stripCruft (halves.Head.Split(':')[1])
    |> getNumbers
  let own = 
    stripCruft halves[1]
    |> getNumbers
  (winning,own)

let cards lines =
  lines
  |> List.map card

let scoringNumbers (card: int list * int list) =
  let (winning,own) = card
  Set.intersect (Set.ofList winning) (Set.ofList own)
  |> Set.toList

let calculateScore (scoringNumbers: int list) =
  match scoringNumbers.Length with
  | 0 -> 0.0
  | 1 -> 1.0
  | _ -> 2.0 ** (float (scoringNumbers.Length - 1))

let solve1 lines =
  lines
  |> cards
  |> List.map scoringNumbers
  |> List.map calculateScore
  |> List.sum
  |> int
