namespace TheCityCardGame

type CardEnum = Parking=0 | Architect=1 | House=2  

type Card = {Cost:int; CashPoints:int; WinPoints:int; CardEnum:CardEnum }

type Player = {CardsInHand: Card List; PlayedCards: Card List}

type Board = {Deck: Card List; Players: Player List}

type Bot = {i: int}

type DisconnectedServer = {i: int}

    type DisconnectedServerT = {First:string; Last:string} with
        // member defined with type declaration
        member this.PlayCard playedCard client= 
            let newOne =  { this with
                First = ""
                Last = "dsfa"
            }
            (newOne, client, 1)