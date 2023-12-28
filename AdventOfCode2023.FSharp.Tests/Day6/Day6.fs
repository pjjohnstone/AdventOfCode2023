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
    TestCaseData([(7L,9L);(15L,40L);(30L,200L)]).Returns(288L)
  ]

[<TestCaseSource("totalMarginOfErrorCases")>]
let ``Return product of all winning strategies`` s =
  totalMarginOfError s

let parseRacesCases = 
  [
    TestCaseData(["Time:        55     99     97     93";"Distance:   401   1485   2274   1405"])
  ]

[<TestCaseSource("parseRacesCases")>]
let ``Return races and records as tuples from text input`` s =
  let expected = [(55,401);(99,1485);(97,2274);(93,1405)]
  Assert.That((parseRaces s), Is.EquivalentTo expected)

[<TestCaseSource("parseRacesCases")>]
let ``Return one single massive race from text input`` s =
  let expected = (55999793L,401148522741405L)
  Assert.That((parseRaces2 s), Is.EqualTo expected)