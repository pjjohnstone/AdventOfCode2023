module Day7Should

open NUnit.Framework
open Day7

let valueCases = [
  TestCaseData('A').Returns(13)
  TestCaseData('2').Returns(1)
]

[<TestCaseSource("valueCases")>]
let ``Return correct value for a given card`` s =
  value s