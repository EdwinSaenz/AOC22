open System
open System.IO

// A: Rock B: Paper C: Scissors
// X: Rock Y: Paper Z: Scissors
let score =
    File.ReadAllLines "input.txt"
    |> Seq.fold (fun (score: int) (line: string) ->
        let choices = line.Split[|' '|]
        let opponentChoice = choices[0]
        let myChoice = choices[1]
        let winningScore =
            match (opponentChoice, myChoice) with
            | ("A", "X") | ("B", "Y") | ("C", "Z") -> 3
            | ("A", "Y") | ("B", "Z") | ("C", "X") -> 6
            | _ -> 0
        let choiceScore =
            match myChoice with
            | "X" -> 1
            | "Y" -> 2
            | "Z" -> 3
            | _ -> 0
        score + winningScore + choiceScore)
        0

printfn "Score: %i" score


// A: Rock B: Paper C: Scissors
// X: Lose Y: Draw  Z: Win
let correctScore =
    File.ReadAllLines "input.txt"
    |> Seq.fold (fun (score: int) (line: string) ->
        let choices = line.Split[|' '|]
        let opponentChoice = choices[0]
        let strategy = choices[1]
        let myChoice =
            match (opponentChoice, strategy) with
            | ("A", "X") | ("B", "Z") | ("C", "Y") -> "Z"
            | ("A", "Y") | ("B", "X") | ("C", "Z") -> "X"
            | ("A", "Z") | ("B", "Y") | ("C", "X") -> "Y"
            | _ -> raise (Exception("Weird choices"))
            
        let winningScore =
            match (opponentChoice, myChoice) with
            | ("A", "X") | ("B", "Y") | ("C", "Z") -> 3
            | ("A", "Y") | ("B", "Z") | ("C", "X") -> 6
            | _ -> 0
        let choiceScore =
            match myChoice with
            | "X" -> 1
            | "Y" -> 2
            | "Z" -> 3
            | _ -> 0
        score + winningScore + choiceScore)
        0

printfn "Correct score: %i" correctScore