module TheCityCardGameMethods

open TheCityCardGame

let calculateWinningPoints cards = 
    let initialValue = 0
    let action sumSoFar (x:Card) = sumSoFar + x.WinPoints
    cards |> List.fold action initialValue

let playCard (player: Player) index (cardsToDiscard: int List) =
    let playedCard = player.CardsInHand.[index]

    if playedCard.Cost > 0 then invalidOp "Cannot discard the same card twice"

    let player1 = { player with CardsInHand = [] }
    let playedPlayer = { player1 with PlayedCards = [playedCard] }

    playedPlayer

// Just for tests
let getMeAnyCard =
    {Cost = 0; CashPoints = 0; WinPoints = 0}