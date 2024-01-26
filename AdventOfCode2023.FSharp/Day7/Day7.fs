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

let fullHouse (hand: string) =
  let (_,counts) = 
    hand
    |> Seq.toList
    |> List.countBy id
    |> List.unzip
  counts
  |> List.distinct
  |> List.filter (fun c -> c >= 2)
  |> List.length = 2

let twoPair (hand: string) =
  hand
  |> Seq.toList
  |> List.countBy id
  |> List.filter (fun (_,c) -> c = 2)
  |> List.length = 2

let handRank hand =
  match (fiveOfAKind hand) with
  | true -> 7
  | false ->
    match (fourOfAKind hand) with
    | true -> 6
    | false ->
      match (fullHouse hand) with
      | true -> 5
      | false ->
        match (threeOfAKind hand) with
        | true -> 4
        | false ->
          match (twoPair hand) with
          | true -> 3
          | false ->
            match (pair hand) with
            | true -> 2
            | false -> 1

let tieBreak (hand1: string) (hand2: string) =
  let pairs = List.zip (hand1 |> Seq.toList) (hand2 |> Seq.toList)
  let indexOfFirstDifference = 
    pairs
    |> List.findIndex (fun (left,right) -> left <> right)
  let (card1,card2) = pairs[indexOfFirstDifference]
  if value card1 > value card2 then hand1 else hand2

let tieBreakHandsList (hand1: string * int * int) (hand2: string * int * int) =
  let (lHand, lBid, lRank) = hand1
  let (rHand, rBid, rRank) = hand2
  if lRank = rRank then
    if (tieBreak lHand rHand) = lHand 
      then [(lHand,lBid,lRank + 1);(rHand,rBid,rRank)]
    else [(lHand,lBid,lRank);(rHand,rBid,rRank + 1)]
  else [(lHand,lBid,lRank);(rHand,rBid,rRank)]

let handArrange (handsWithBidsAndRanks: (string * int * int) list) =
  let rec handArrangeRec (handsWithBidsAndRanks: (string * int * int) list) orderedHands =
    match handsWithBidsAndRanks with
    | [] -> orderedHands
    | _ ->
      match orderedHands with
      | [] ->
        handArrangeRec (List.removeManyAt 0 2 handsWithBidsAndRanks) (tieBreakHandsList handsWithBidsAndRanks[0] handsWithBidsAndRanks[1])
      | _ ->
        let newOrdered = List.removeAt ((List.length orderedHands) - 1) orderedHands
        handArrangeRec (handsWithBidsAndRanks.Tail) (newOrdered@(tieBreakHandsList (List.last orderedHands) handsWithBidsAndRanks[0]))
  handArrangeRec handsWithBidsAndRanks []

let handOrder (handsWithBids: (string * int) list) =
  handsWithBids
  |> List.map (fun (hand,bid) -> (hand,bid,(handRank hand)))
  |> List.sortByDescending (fun (_,_,score) -> score)
  |> handArrange
  |> List.sortByDescending (fun (_,_,score) -> score)
  |> List.map (fun (hand,bid,_) -> (hand,bid))

let calculateValue (handsWithBids: (string * int) list) =
  handsWithBids
  |> handOrder
  |> List.rev
  |> List.mapi (fun i (_,b) -> b * (i + 1))
  |> List.sum

let parseLine (line: string) =
  line.Split(' ')
  |> fun a -> (a[0], stringToInt a[1])