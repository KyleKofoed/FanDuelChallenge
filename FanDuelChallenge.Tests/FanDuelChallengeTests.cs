using FanDuelChallenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FanDuelChallenge.Tests
{
    public class FanDuelChallengeTests
    {
        [Fact]
        public void FirstPlayerIsWinnerSecondPlayerIsLoser()
        {
            Player firstPlayer = new Player()
            {
                FPPG = 99
            };

            Player secondPlayer = new Player()
            {
                FPPG = 1
            };

            List<Player> players = new List<Player> { firstPlayer, secondPlayer };
            IEnumerable<Player> HighestPlayers = FanDuelGuessLogic.GetPlayerWithHighestFPPG(players);

            Assert.True(HighestPlayers.Contains(firstPlayer), "First player was not a winner");
            Assert.True(!HighestPlayers.Contains(secondPlayer), "Second player was not a loser");

        }
        [Fact]
        public void FirstPlayerIsLoserSecondPlayerIsWinner()
        {
            Player firstPlayer = new Player()
            {
                FPPG = 1
            };

            Player secondPlayer = new Player()
            {
                FPPG = 99
            };

            List<Player> players = new List<Player> { firstPlayer, secondPlayer };
            IEnumerable<Player> HighestPlayers = FanDuelGuessLogic.GetPlayerWithHighestFPPG(players);

            Assert.True(!HighestPlayers.Contains(firstPlayer), "First player was a winner");
            Assert.True(HighestPlayers.Contains(secondPlayer), "Second player was a loser");

        }
        [Fact]
        public void TwoPlayersTie()
        {
            Player firstPlayer = new Player()
            {
                FPPG = 1
            };

            Player secondPlayer = new Player()
            {
                FPPG = 1
            };

            List<Player> players = new List<Player> { firstPlayer, secondPlayer };
            IEnumerable<Player> HighestPlayers = FanDuelGuessLogic.GetPlayerWithHighestFPPG(players);

            //everyone is a winner!
            Assert.True(HighestPlayers.Contains(firstPlayer)&& HighestPlayers.Contains(secondPlayer), "One of the players was a loser");
            

        }
    }
}
