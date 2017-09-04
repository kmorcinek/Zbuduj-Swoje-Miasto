// Learn more about F# at http://fsharp.org. See the 'F# Tutorial' project
// for more guidance on F# programming.

#load "Card.fs"
#load "TheCityCardGameMethods.fs"
open TheCityCardGame
open TheCityCardGameMethods

// Define your library scripting code here

let action (stateSoFar: 'T List*'T*bool) current =
    let (lista, treshold, isAlreadyRemoved) = stateSoFar

    if isAlreadyRemoved = false &&  current = treshold then (lista, treshold, true)
    else (current::lista, treshold, isAlreadyRemoved)
//
//let a = getMeAnyCard
//let b = {a with Cost = 0} 
//let items = [a;b]
//
//let r = items |> List.fold action ([], a, false)

let numbers = [1;2;2;2;3]
let result = numbers |> List.fold action ([], 2, false)
//let action2 (stateSoFar: Card List*CardEnum*bool) current =
//    let (lista, treshold, isAlreadyRemoved) = stateSoFar
//
//    if isAlreadyRemoved = false &&  current >= treshold then (lista, treshold, true)
//    else (current::lista, treshold, isAlreadyRemoved)
