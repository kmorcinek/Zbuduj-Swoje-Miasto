module Tests

open TheCityCardGame
open TheCityCardGameMethods
open Xunit
open FsUnit
open System

    [<Fact>]
        let ``Can calculate winning points for simple points``() = 
            let card = { getMeAnyCard with WinPoints = 3 }
            let cardsList = [card]

            Assert.Equal(3, calculateWinningPoints cardsList)

    [<Fact>]
        let ``Can play Parking card``() = 
            let parking = { getMeAnyCard with Cost = 0 }

            let player = {CardsInHand = [parking]; PlayedCards = []}

            let playedPlayer = playCard player 0 []
            Assert.Equal(0, playedPlayer.CardsInHand.Length)
            Assert.Equal(1, playedPlayer.PlayedCards.Length)

    [<Fact>]
        let ``Can play House card``() = 
            let house = { getMeAnyCard with Cost = 1 }

            let player = {CardsInHand = [house; house]; PlayedCards = []}

            let playedPlayer = playCard player 0 [1]
            Assert.Equal(0, playedPlayer.CardsInHand.Length)
            Assert.Equal(1, playedPlayer.PlayedCards.Length)

    [<Fact>]
        let ``Cannot play card when enough cards are not discarded``() = 
            let house = { getMeAnyCard with Cost = 1 }

            let player = {CardsInHand = [house; house]; PlayedCards = []}

            (fun () -> playCard player 0 [] |> ignore) |> should throw typeof<InvalidOperationException>