﻿module Tests

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

            let playedPlayer = playCard player parking.CardEnum []

            Assert.Equal(0, playedPlayer.CardsInHand.Length)
            Assert.Equal(1, playedPlayer.PlayedCards.Length)

    [<Fact>]
        let ``Can play House card``() = 
            let house = { getMeAnyCard with
                            CardEnum = CardEnum.House
                            Cost = 1}

            let player = {
                CardsInHand = [house; house]
                PlayedCards = [] }

            let playedPlayer = playCard player house.CardEnum [house.CardEnum]

            Assert.Equal(0, playedPlayer.CardsInHand.Length)
            Assert.Equal(1, playedPlayer.PlayedCards.Length)

    [<Fact>]
        let ``Cannot play card when enough cards are not discarded``() = 
            let card = { getMeAnyCard with Cost = 1 }

            let player = {CardsInHand = [card; card]; PlayedCards = []}

            (fun () -> playCard player card.CardEnum [] |> ignore) |> should throw typeof<InvalidOperationException>

    [<Fact>]
        let ``Just test``() = 
            let p a b=
                a = b

//            let xs = removeFromFirstList p [1;2;0] [2;1] 

            let pCard enum card =
                card.CardEnum = enum

            let xs2 = removeFromFirstList pCard [getMeAnyCard;getMeAnyCard] [CardEnum.Parking; CardEnum.Parking]

            xs2.Length |> should equal 0