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