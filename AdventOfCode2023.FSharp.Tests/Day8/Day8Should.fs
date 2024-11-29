module AdventOfCode2023.FSharp.Tests.Day8.Day8Should

open NUnit.Framework
open AdventOfCode2023.FSharp.Day8.Day8

let instructionCases = [
  TestCaseData(Left, {Label = "AAA"; Left = "BBB"; Right = "CCC"} ).Returns("BBB")
  TestCaseData(Right, {Label = "AAA"; Left = "BBB"; Right = "CCC"} ).Returns("CCC")
] 

[<TestCaseSource("instructionCases")>]
let ``Pick correct path based on instruction`` input =
  let (instruction, paths) = input
  nextNode instruction paths