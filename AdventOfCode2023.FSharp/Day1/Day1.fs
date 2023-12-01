module Day1

let writtenNumbers = ["one"; "two"; "three"; "four"; "five"; "six"; "seven"; "eight"; "nine"]

let containsNumbers (str: string) =
  if 
    str 
    |> Seq.toList
    |> List.exists (fun c -> System.Char.IsNumber(c)) then true
  else false

let containsWrittenNumbers (str: string) =
  if writtenNumbers |> List.exists (fun n -> str.Contains(n)) || writtenNumbers |> List.exists (fun n -> str.Contains(stringReverse n)) then true
  else false

let removeNumbers (str: string) =
  match str with
  | str when str.StartsWith "one" -> ('1', str.Replace("one", ""))
  | str when str.StartsWith "two" -> ('2', str.Replace("two", ""))
  | str when str.StartsWith "three" -> ('3', str.Replace("three", ""))
  | str when str.StartsWith "four" -> ('4', str.Replace("four", ""))
  | str when str.StartsWith "five" -> ('5', str.Replace("five", ""))
  | str when str.StartsWith "six" -> ('6', str.Replace("six", ""))
  | str when str.StartsWith "seven" -> ('7', str.Replace("seven", ""))
  | str when str.StartsWith "eight" -> ('8', str.Replace("eight", ""))
  | str when str.StartsWith "nine" -> ('9', str.Replace("nine", ""))
  | str when System.Char.IsNumber(str[0]) -> (str[0], str.Substring 1)
  | _ -> ('-', str.Substring 1)

let removeNumbersRev (str: string) =
  match str with
  | str when str.StartsWith "eno" -> ('1', str.Replace("eno", ""))
  | str when str.StartsWith "owt" -> ('2', str.Replace("owt", ""))
  | str when str.StartsWith "eerht" -> ('3', str.Replace("eerht", ""))
  | str when str.StartsWith "ruof" -> ('4', str.Replace("ruof", ""))
  | str when str.StartsWith "evif" -> ('5', str.Replace("evif", ""))
  | str when str.StartsWith "xis" -> ('6', str.Replace("xis", ""))
  | str when str.StartsWith "neves" -> ('7', str.Replace("neves", ""))
  | str when str.StartsWith "thgie" -> ('8', str.Replace("thgie", ""))
  | str when str.StartsWith "enin" -> ('9', str.Replace("enin", ""))
  | str when System.Char.IsNumber(str[0]) -> (str[0], str.Substring 1)
  | _ -> ('-', str.Substring 1)

let rec replaceWrittenNumbersRec func str (result: char list) =
  match containsWrittenNumbers str || containsNumbers str with
  | true -> 
     let char,newStr = func str
     replaceWrittenNumbersRec func newStr (char::result)
  | false -> 
     result

let numbersOnly (str:string) =
  let firstNum = 
    replaceWrittenNumbersRec removeNumbers str []
    |> List.rev
    |> List.filter (fun c -> System.Char.IsNumber(c))
    |> List.head
  let lastNum =
    replaceWrittenNumbersRec removeNumbersRev (stringReverse str) []
    |> List.rev
    |> List.filter (fun c -> System.Char.IsNumber(c))
    |> List.head
  System.String.Concat [|firstNum; lastNum|] 

let solve1 lines =
  lines
  |> List.map numbersOnly
  |> List.map stringToInt
  |> List.sum
