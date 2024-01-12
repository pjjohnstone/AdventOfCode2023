module Day7Should

open NUnit.Framework
open Day7

let valueCases = [
  TestCaseData('A').Returns(13)
  TestCaseData('K').Returns(12)
  TestCaseData('Q').Returns(11)
  TestCaseData('J').Returns(10)
  TestCaseData('T').Returns(9)
  TestCaseData('9').Returns(8)
  TestCaseData('8').Returns(7)
  TestCaseData('7').Returns(6)
  TestCaseData('6').Returns(5)
  TestCaseData('5').Returns(4)
  TestCaseData('4').Returns(3)
  TestCaseData('3').Returns(2)
  TestCaseData('2').Returns(1)
]

[<TestCaseSource("valueCases")>]
let ``Return correct value for a given card`` s =
  value s