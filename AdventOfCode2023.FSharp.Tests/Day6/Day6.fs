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
