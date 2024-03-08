module FsCheckTest

open FsCheck.NUnit

let add x y = x + y // good implementation

let commutativeProperty x y =
  add x y = add y x

let associativeProperty x y z =
  add x (add y z) = add (add x y) z

let leftIdentityProperty x =
  add x 0 = x

let rightIdentityProperty x =
  add 0 x = x

[<Property>]
let ``Commutative`` x y =
  commutativeProperty x y

[<Property>]
let ``Associative`` x y z =
  associativeProperty x y z

[<Property>]
let ``Left Identity`` x =
  leftIdentityProperty x

[<Property>]
let ``Right Identity`` x =
  rightIdentityProperty x