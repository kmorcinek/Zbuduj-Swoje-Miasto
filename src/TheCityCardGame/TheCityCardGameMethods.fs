module TheCityCardGameMethods

open TheCityCardGame

let calculateWinningPoints cards = 
    let initialValue = 0
    let action sumSoFar (x:Card) = sumSoFar + x.WinPoints
    cards |> List.fold action initialValue

let rec removeFirst predicate = function
    | [] -> []
    | h :: t when predicate h -> t
    | h :: t -> h :: removeFirst predicate t

let rec removeFromFirstList p (cardsInHand: 'T List) (toDiscard: 'TT List) =
    match toDiscard with
    | [] -> cardsInHand
    | h :: t  when List.exists (p h) cardsInHand -> removeFromFirstList p (removeFirst (p h) cardsInHand) t
    | h :: t -> invalidOp "Cannot discard the same card twice"

let playCard (player: Player) cardToPlay (cardsToDiscard: CardEnum List) =
    let playedCard = (List.filter (fun x -> x.CardEnum = cardToPlay) player.CardsInHand).Head

    let withoutPlayedCard = removeFirst (fun x -> x.CardEnum = cardToPlay) player.CardsInHand

    if cardsToDiscard.Length <> playedCard.Cost then invalidOp "Cost requires to discard more cards (details later)"   

    let p enum card =
        card.CardEnum = enum

    let leftInHand = removeFromFirstList p withoutPlayedCard cardsToDiscard

    { player with
        PlayedCards = [playedCard]
        CardsInHand = leftInHand  }

let rec removeFirst1 predicate = function
    | [] -> []
    | h :: t when predicate h -> t
    | h :: t -> h :: removeFirst predicate t

let rec drawCards = function
    | (toAdd,h :: t, 0) -> (h :: toAdd, t)
    | (a, b, x) -> drawCards (a, b, x-1)

let calculateCashPoints cards =
    List.sumBy (fun x -> x.CashPoints) cards 

let drawNewCards (player: Player) (deck: Card List) =
    let cardsToDeal = calculateCashPoints player.PlayedCards
    
    let (newCards, newDeck) = drawCards (player.CardsInHand, deck, cardsToDeal)

    let newPlayer = { player with CardsInHand = newCards }

    (newPlayer, newDeck)

// Just for tests
let getMeAnyCard =
    {   Cost = 0
        CashPoints = 0
        WinPoints = 0
        CardEnum = CardEnum.Parking}