module AdventOfCode2023.FSharp.Tests

open NUnit.Framework
open Day6

[<SetUp>]
let Setup () =
    ()

let distanceTestCases = 
  [
    TestCaseData(7,0).Returns(0)
    TestCaseData(7,1).Returns(6)
    TestCaseData(7,2).Returns(10)
    TestCaseData(7,3).Returns(12)
    TestCaseData(7,4).Returns(12)
    TestCaseData(7,5).Returns(10)
    TestCaseData(7,6).Returns(6)
    TestCaseData(7,7).Returns(0)
  ]

[<TestCaseSource("distanceTestCases")>]
let ``Calculate total distance travelled`` s =
  let (duration,press) = s
  distance duration press

let winningResultsCases = 
  [
    TestCaseData(7,9).Returns(4)
    TestCaseData(15,40).Returns(8)
    TestCaseData(30,200).Returns(9)
  ]

[<TestCaseSource("winningResultsCases")>]
let ``Return number of strategies that beat the record`` s =
  let (duration,record) = s
  winningResults duration record

let totalMarginOfErrorCases = 
  [
    TestCaseData([(7,9);(15,40);(30,200)]).Returns(288)
  ]

[<TestCaseSource("totalMarginOfErrorCases")>]
let ``Return product of all winning strategies`` s =
  totalMarginOfError s