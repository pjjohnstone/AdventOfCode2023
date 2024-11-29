module AdventOfCode2023.FSharp.Tests.Day8.Day8Should

open NUnit.Framework
open AdventOfCode2023.FSharp.Day8.Day8

let instructionCases = [
  TestCaseData(Left, {Label = "AAA"; Left = "BBB"; Right = "CCC"} ).Returns("BBB")
  TestCaseData(Right, {Label = "AAA"; Left = "BBB"; Right = "CCC"} ).Returns("CCC")
] 

[<TestCaseSource("instructionCases")>]
let ``Pick correct path based on instruction`` input =
  let instruction, paths = input
  nextNode instruction paths
  
let instructionParserCases = [
  TestCaseData("LRR").Returns([Left; Right; Right])
  TestCaseData("RLR").Returns([Right; Left; Right])
]

[<TestCaseSource("instructionParserCases")>]
let ``Parse instructions from instruction string`` instructionString =
  parseInstructions instructionString
  
let nodeParseCases = [
  TestCaseData("AAA = (BBB, BBB)").Returns({Label = "AAA"; Left = "BBB"; Right = "BBB"})
  TestCaseData("ZZZ = (ZZZ, ZZZ)").Returns({Label = "ZZZ"; Left = "ZZZ"; Right = "ZZZ"})
]

[<TestCaseSource("nodeParseCases")>]
let ``Parse nodes from node strings`` nodeString =
  parseNode nodeString
  
let routeCases = [
  TestCaseData([
    Left
    Left
    Right
  ],[
    {Label = "AAA"; Left = "BBB"; Right = "BBB"}
    {Label = "BBB"; Left = "AAA"; Right = "ZZZ"}
    {Label = "ZZZ"; Left = "ZZZ"; Right = "ZZZ"}
  ]).Returns(6)
]

[<TestCaseSource("routeCases")>]
let ``Calculate steps to reach ZZZ`` input =
  let instructions, nodes = input
  traverseRoute nodes instructions
  
let inputParserCases = [
  TestCaseData([
    "LLR"
    ""
    "AAA = (BBB, BBB)"
    "BBB = (AAA, ZZZ)"
    "ZZZ = (ZZZ, ZZZ)"
  ]).Returns([
    Left
    Left
    Right
  ],[
    {Label = "AAA"; Left = "BBB"; Right = "BBB"}
    {Label = "BBB"; Left = "AAA"; Right = "ZZZ"}
    {Label = "ZZZ"; Left = "ZZZ"; Right = "ZZZ"}
  ])
]

[<TestCaseSource("inputParserCases")>]
let ``Parse whole puzzle input into instructions and nodes`` input =
  parsePuzzleInput input