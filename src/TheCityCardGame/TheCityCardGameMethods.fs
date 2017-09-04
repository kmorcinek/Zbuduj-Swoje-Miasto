module TheCityCardGameMethods

open TheCityCardGame

let calculateWinningPoints cards = 
    let initialValue = 0
    let action sumSoFar (x:Card) = sumSoFar + x.WinPoints
    cards |> List.fold action initialValue

let playCard (player: Player) index (cardsToDiscard: int List) =
    let playedCard = player.CardsInHand.[index]

    let player1 = { player with CardsInHand = [] }
    let player2 = { player1 with PlayedCards = [playedCard] }

    player2
