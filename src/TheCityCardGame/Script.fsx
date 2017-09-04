// Learn more about F# at http://fsharp.org. See the 'F# Tutorial' project
// for more guidance on F# programming.

#load "Card.fs"
open TheCityCardGame

// Define your library scripting code here
type NameAndSize= {Name:string;Size:int}
 
let maxNameAndSize list = 
    
    let innerMaxNameAndSize initialValue rest = 
        let action maxSoFar x = if maxSoFar.Size < x.Size then x else maxSoFar
        rest |> List.fold action initialValue 

    // handle empty lists
    match list with
    | [] -> 
        None
    | first::rest -> 
        let max = innerMaxNameAndSize first rest
        Some max

  
let maxNameAndSize2 list = 

    let action2 (currentItem:int) (soFar: int List) (wasAlreadyRemoved: bool) =
        match
    
    let innerMaxNameAndSize initialValue rest = 
        let action maxSoFar x = if maxSoFar.Size < x.Size then x else maxSoFar
        rest |> List.fold action initialValue 

    // handle empty lists
    match list with
    | [] -> 
        None
    | first::rest -> 
        let max = innerMaxNameAndSize first rest
        Some max  