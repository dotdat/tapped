module Fable.Tapped.Core

open Fable.Core

type TestResult =
    | TestFailure of string

type TestBuilder (name) =
    member __.Zero () = TestFailure <| sprintf "The test \"%s\" did not assert anything" name

let test name = TestBuilder (name)
