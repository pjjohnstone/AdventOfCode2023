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

let handTypeRankCases = [
  TestCaseData("AAAAA").Returns(7)
  TestCaseData("AAAAK").Returns(6)
  TestCaseData("QQQ99").Returns(5)
  TestCaseData("23999").Returns(4)
  TestCaseData("23432").Returns(3)
  TestCaseData("A23A4").Returns(2)
  TestCaseData("23456").Returns(1)
]

[<TestCaseSource("handTypeRankCases")>]
let ``Return the type rank of a given hand`` s =
  handRank s

let fiveOfAKindCases = [
  TestCaseData("KKKKK").Returns(true)  
  TestCaseData("22222").Returns(true)
  TestCaseData("23456").Returns(false)
  TestCaseData("QQQQ5").Returns(false)
]

[<TestCaseSource("fiveOfAKindCases")>]
let ``Return true if hand is 5 of a kind`` s =
  fiveOfAKind s

let fourOfAKindCases = [
  TestCaseData("AAAAK").Returns(true)
  TestCaseData("QQQ99").Returns(false)
]

[<TestCaseSource("fourOfAKindCases")>]
let ``Return true if hand is 4 of a kind`` s =
  fourOfAKind s

let fullHouseCases = [
  TestCaseData("222KK").Returns(true)
  TestCaseData("223KK").Returns(false)
]

[<TestCaseSource("fullHouseCases")>]
let ``Return true if hand is full house`` s =
  fullHouse s

let twoPairCases = [
  TestCaseData("223KK").Returns(true)
  TestCaseData("243KK").Returns(false)
]

[<TestCaseSource("twoPairCases")>]
let ``Return true if hand is twoi pairs`` s =
  twoPair s