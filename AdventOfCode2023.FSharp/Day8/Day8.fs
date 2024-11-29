module AdventOfCode2023.FSharp.Day8.Day8

type Node = {
  Label: string
  Left: string
  Right: string
}

type Instruction =
  | Left
  | Right

let nextNode instruction node:string =
  match instruction with
  | Left -> node.Left
  | Right -> node.Right
  
let parseInstruction instructionChar =
  match instructionChar with
  | 'L' -> Some(Left)
  | 'R' -> Some(Right)
  | _ -> None
  
let parseInstructions instructionString =
  instructionString
  |> Seq.toList
  |> List.map parseInstruction
  |> List.choose id
  
let parseNode nodeString =
  nodeString
  |> Seq.toList
  |> List.filter System.Char.IsLetter
  |> List.chunkBySize 3
  |> List.map System.String.Concat
  |> fun parts -> {Label = parts[0]; Left = parts[1]; Right = parts[2]}

let findNodeByLabel nodes label =
  nodes |> List.find (fun node -> node.Label = label)

let traverseRoute nodes (instructions: Instruction list)  =
  let rec traverseRouteRec nodes activeNode (instructions: Instruction list) usedInstructions steps =
    match instructions with
    | [] -> traverseRouteRec nodes activeNode (List.rev usedInstructions) [] steps
    | _ ->
      match activeNode.Label with
      | "ZZZ" -> steps
      | _ -> traverseRouteRec nodes (findNodeByLabel nodes (nextNode instructions.Head activeNode)) instructions.Tail (instructions.Head::usedInstructions) (steps + 1)
  traverseRouteRec nodes (List.head nodes) instructions [] 0
  
let parsePuzzleInput input =
  let instructions =
    input
    |> Array.toList
    |> List.head
    |> parseInstructions
  let nodes =
    input
    |> Array.skip 2
    |> Array.toList
    |> List.map parseNode
  (instructions, nodes)