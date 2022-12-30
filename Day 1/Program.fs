open System
open System.IO

let fileName = "input.txt"

// Find the elf carrying most calories. Print calories
let (max, _) = 
    File.ReadAllLines fileName
    |> Seq.fold (fun (max, currentMax) line ->
        let mutable result = 0
        if Int32.TryParse(line, &result) then
            (max, currentMax + result)
        elif max < currentMax then
            (currentMax, 0)
        else
            (max, 0))
        (0, 0)

printfn "max: %i" max

// Find the top three elves carrying most calories. Print their sum
let sum =
    File.ReadAllLines fileName
    |> Seq.fold (fun maxes line -> 
        let mutable result = 0
        if Int32.TryParse(line, &result) then
            [maxes.Head + result] @ maxes.Tail
        else
            [0] @ maxes)
        [0]
    |> Seq.sortDescending
    |> Seq.take 3
    |> Seq.sum

printfn "sum of top 3: %i" sum