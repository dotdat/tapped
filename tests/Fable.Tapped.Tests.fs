namespace Fable.Tapped

open System
open Fable.Core
open Fable.Core.JsInterop
module Tapped = Fable.Tapped.Core

module Assert =

    let raiseAssertionError msg =
        let raisedMsg = sprintf "AssertionError: %s" msg
        System.Exception raisedMsg |> raise

    let equal x y msg =
        if x = y
        then printfn msg
        else raiseAssertionError <| sprintf "%s is not equal to %s" (x.ToString ())  (y.ToString ())

module Test =

    let EmptyTestsProduceAFailure () =
        let testResult = Tapped.test "testFn" { 1 }
        let expectedResult = Tapped.TestFailure "The test \"testFn\" did not assert anything"
        Assert.equal expectedResult testResult "ok: testFn results in a failure"

    EmptyTestsProduceAFailure ()
