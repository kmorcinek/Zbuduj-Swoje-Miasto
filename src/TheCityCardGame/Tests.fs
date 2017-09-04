module Tests

open TheCityCardGame
open TheCityCardGameMethods
open Xunit

    [<Fact>]
        let ``Can calculate winning points for simple points``() = 
            let card = {Cost = 2; CashPoints = 1; WinPoints = 3}
            let cardsList = [card]

            Assert.Equal(3, calculateWinningPoints cardsList)

    [<Fact>]
        let ``Can_play_Parking_card``() = 
            let parking = {Cost = 0; CashPoints = 0; WinPoints = 0}

            let player = {CardsInHand = [parking]; PlayedCards = []}

            let playedPlayer = playCard player 0 []
            Assert.Equal(0, playedPlayer.CardsInHand.Length)
            Assert.Equal(1, playedPlayer.PlayedCards.Length)