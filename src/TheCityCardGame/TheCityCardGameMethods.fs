module TheCityCardGameMethods

open TheCityCardGame

let calculateWinningPoints cards = 
    let initialValue = 0
    let action sumSoFar (x:Card) = sumSoFar + x.WinPoints
    cards |> List.fold action initialValue

let playCard (player: Player) cardToPlay (cardsToDiscard: CardEnum List) =
    let playedCard = (List.filter (fun x -> x.CardEnum = cardToPlay) player.CardsInHand).Head

    let removeFirstCard bigList card =
        let action (stateSoFar: Card List*CardEnum*bool) current =
            let (items, cardToFind, isAlreadyRemoved) = stateSoFar

            if isAlreadyRemoved = false &&  current.CardEnum = cardToFind
                then (items, cardToFind, true)
                else (current::items, cardToFind, isAlreadyRemoved)

        bigList |> List.fold action ([], cardToPlay, false)

    // remove first occurence of ...
    let (withoutPlayedCard, _, _) = (removeFirstCard player.CardsInHand cardToPlay)

    let removeExactlyOne (bigLista: Card List) card =
        let (withoutDiscardedCard, _, wasRemoved) = removeFirstCard player.CardsInHand cardToPlay

        if wasRemoved = false then invalidOp "Cannot discard the same card twice"
        else withoutDiscardedCard

    let player1 = { player with CardsInHand = [] }
    { player1 with PlayedCards = [playedCard] }

// Just for tests
let getMeAnyCard =
    {Cost = 0; CashPoints = 0; WinPoints = 0; CardEnum=CardEnum.Parking}