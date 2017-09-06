module TheCityCardGameMethods

open TheCityCardGame

let calculateWinningPoints cards = 
    let initialValue = 0
    let action sumSoFar (x:Card) = sumSoFar + x.WinPoints
    cards |> List.fold action initialValue

let playCard (player: Player) cardToPlay (cardsToDiscard: CardEnum List) =
    let playedCard = (List.filter (fun x -> x.CardEnum = cardToPlay) player.CardsInHand).Head

    let rec removeFirst predicate = function
    | [] -> []
    | h :: t when predicate h -> t
    | h :: t -> h :: removeFirst predicate t

    let withoutPlayedCard = removeFirst (fun x -> x.CardEnum = cardToPlay) player.CardsInHand

//    let removeExactlyOne (bigLista: Card List) card =
//        let (withoutDiscardedCard, _, wasRemoved) = removeFirstCard player.CardsInHand cardToPlay
//
//        if wasRemoved = false then invalidOp "Cannot discard the same card twice"
//        else withoutDiscardedCard
//
//    let leftInHand = cardsToDiscard |> List.fold (fun x acc -> removeExactlyOne acc x) withoutPlayedCard

    { player with
        PlayedCards = [playedCard]
        CardsInHand = []  }

// Just for tests
let getMeAnyCard =
    {Cost = 0; CashPoints = 0; WinPoints = 0; CardEnum=CardEnum.Parking}