module Day1

let numbersOnly (str:string) =
  str
  |> Seq.toList
  |> List.filter (fun c -> System.Char.IsNumber(c))

let returnEnds (nums: char list) =
  System.String.Concat [|nums.Head; List.last nums|]
   

let solve1 lines =
  lines
  |> List.map numbersOnly
  |> List.map returnEnds
  |> List.map stringToInt
  |> List.sum

