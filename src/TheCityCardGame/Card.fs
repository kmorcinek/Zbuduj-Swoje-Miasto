namespace TheCityCardGame

type CardEnum = Parking=0 | Architect=1 | House=2  

type Card = {Cost:int; CashPoints:int; WinPoints:int; CardEnum:CardEnum }

type Player = {CardsInHand: Card List; PlayedCards: Card List}

