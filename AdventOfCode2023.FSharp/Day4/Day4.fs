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
  let cardNumber =
    halves.Head.Split(':')[0]
    |> Seq.toList
    |> List.filter (fun c -> System.Char.IsNumber(c))
    |> System.String.Concat
    |> stringToInt
  (cardNumber,winning,own)

let cards lines =
  lines
  |> List.map card

let scoringNumbers (card: int * int list * int list) =
  let (cardNum,winning,own) = card
  let scoringNumbers = 
    Set.intersect (Set.ofList winning) (Set.ofList own)
    |> Set.toList
  (cardNum,scoringNumbers)

let calculateScore (scoringNumbers: int * int list) =
  let (_,scoring) = scoringNumbers
  match scoring.Length with
  | 0 -> 0.0
  | 1 -> 1.0
  | _ -> 2.0 ** (float (scoring.Length - 1))

let solve1 lines =
  lines
  |> cards
  |> List.map scoringNumbers
  |> List.map calculateScore
  |> List.sum
  |> int

let getCardWithNumber cards num =
  cards
  |> List.find (fun (n,_,_) -> n = num)

let awardCardsWithIndices (scoringCard: int * int list) =
  let (cardNo,score) = scoringCard
  List.init score.Length (fun v -> (v + 1) + cardNo)

let awardCards cards =
  let rec awardCardsRec cards totalCards =
    match cards with
    | [] -> totalCards
    | _ ->
      cards
      |> List.map scoringNumbers
      |> List.map awardCardsWithIndices
      |> List.concat
      |> List.map (fun n -> getCardWithNumber totalCards n)
      |> fun nc -> awardCardsRec nc totalCards@nc
  awardCardsRec cards cards

let solve2 lines =
  lines
  |> cards
  |> awardCards
  |> fun c -> c.Length