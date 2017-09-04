module TheCityCardGameMethods

open TheCityCardGame

let calculateWinningPoints cards = 
    let initialValue = 0
    let action sumSoFar (x:Card) = sumSoFar + x.WinPoints
    cards |> List.fold action initialValue

let playCard (player: Player) cardToPlay (cardsToDiscard: CardEnum List) =
    let playedCard = (List.filter (fun x -> x.CardEnum = cardToPlay) player.CardsInHand).Head

    if playedCard.Cost > 0 then invalidOp "Cannot discard the same card twice"

    // remove first occurence of ...


    let player1 = { player with CardsInHand = [] }
    { player1 with PlayedCards = [playedCard] }

// Just for tests
let getMeAnyCard =
    {Cost = 0; CashPoints = 0; WinPoints = 0; CardEnum=CardEnum.Parking}