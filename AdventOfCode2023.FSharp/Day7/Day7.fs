module Day7

let value card =
  match card with
  | 'A' -> 13
  | 'K' -> 12
  | 'Q' -> 11
  | 'J' -> 10
  | 'T' -> 9
  | '9' -> 8
  | '8' -> 7
  | '7' -> 6
  | '6' -> 5
  | '5' -> 4
  | '4' -> 3
  | '3' -> 2
  | '2' -> 1
  | _ -> 0

let xOfAKind (hand: string) count =
  hand
  |> Seq.toList
  |> List.countBy id
  |> List.filter (fun (_,c) -> c = count)
  |> List.length = 1

let fiveOfAKind hand =
  xOfAKind hand 5

let fourOfAKind hand =
  xOfAKind hand 4

let threeOfAKind hand =
  xOfAKind hand 3

let pair hand =
  xOfAKind hand 2

let handRank hand =
  1