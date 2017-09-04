module Tests

open TheCityCardGame
open TheCityCardGameMethods
open Xunit

    [<Fact>]
        let ``Can calculate winning points for simple points``() = 
            let card = {Cost = 2; CashPoints = 1; WinPoints = 3}
            let cardsList = [card]

            Assert.Equal(3, calculateWinningPoints cardsList)