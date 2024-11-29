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