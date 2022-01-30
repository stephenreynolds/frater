open System

// There are three categories: Art, Plot, and Enjoyment
type Categories = { Art: double; Sound: double; Character: double; Plot: double; Enjoyment: double }

// Weigh each category according to their weights
let artWeight = 0.11
let soundWeight = 0.11
let characterWeight = 0.12
let plotWeight = 0.26
let enjoymentWeight = 0.40

let weighCategories categories =
    { Art = categories.Art * artWeight;
      Sound = categories.Sound * soundWeight;
      Character = categories.Character * characterWeight;
      Plot = categories.Plot * plotWeight;
      Enjoyment = categories.Enjoyment * enjoymentWeight }

// Add the weighted scores to get a total pre-scaled score from 1 to 5
let sumCategories weighted = weighted.Art + weighted.Sound + weighted.Character + weighted.Plot + weighted.Enjoyment

// Categories are scored from 1 to 5; the final score is 1 to 10
let categoryMax = 5.0
let categoryMin = 1.0
let scoreMax = 10.0
let scoreMin = 1.0

// Scale the score from 1 to 5 so that it is 1 to 10
let scaleScore score = ((scoreMax - scoreMin) / (categoryMax - categoryMin)) * (score - categoryMax) + scoreMax

// Round down the score to the nearest 0.5
let floorToHalf score = Math.Floor(score * 2.0) / 2.0

// Helper function for printing info about this program
let printInfo () =
    printfn "This program was written to help with rating media."
    printfn "\nMedia are rated in five categories: Art, Sound, Character, Plot, and Enjoyment."
    printfn "Each category is weighted according the following percentages:"
    printfn "\tArt: 11%%"
    printfn "\tSound: 11%%"
    printfn "\tCharacter: 12%%"
    printfn "\tPlot: 26%%"
    printfn "\tEnjoyment: 40%%"
    printfn "\nWhen you run the program, you will be prompted to rate each category on a scale of 1.0 to 5.0."
    printfn "You can enter integers or decimal numbers."
    printfn "\nAfter each category is rated they are weighted, added together, scaled to 1 to 10, and rounded down to the nearest 0.5.\n"

// Helper function to receive input for each rating, making sure they are in range
let rec getRating name =
    printf "%s: " name
    let score = Double.Parse(Console.ReadLine())

    match score with
    | x when x >= 1.0 && x <= 5.0 -> score
    | _ -> printfn "Rating must be 1.0 to 5.0!"; getRating name

// Helper function for prompting whether to run again.
let runAgain () =
    printf "\n\nRate another? (y/n): "
    Console.ReadLine() = "y"

// Helper function for rating
let rec promptRatings () =
    printfn "Rate the following categories on a scale of 1.0 to 5.0:\n"

    let art = getRating "Art"
    let sound = getRating "Sound"
    let character = getRating "Character"
    let plot = getRating "Plot"
    let enjoyment = getRating "Enjoyment"

    let categoryScores = { Art = art; Sound = sound; Character = character; Plot = plot; Enjoyment = enjoyment }

    let finalScore = categoryScores |> weighCategories |> sumCategories |> scaleScore |> floorToHalf

    printf "\nAggregate Score: %.1f" finalScore

    // Prompt to run again or not.
    match runAgain() with
    | true -> printfn ""; promptRatings()
    | false -> 0 |> ignore

[<EntryPoint>]
let main argv =
    // Prompt for ratings or print info if "help" arg given.
    match argv.Length with
    | length when length > 0 ->
        match argv.[0] with
        | "help" -> printInfo()
        | _ -> promptRatings()
    | _ -> promptRatings()
    0
