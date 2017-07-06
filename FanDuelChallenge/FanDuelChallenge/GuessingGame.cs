using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanDuelChallenge
{
    public class GuessingGame
    {
        private const int maxCount = 10;
        private IEnumerable<Player> Players { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        private int CorrectCount { get;  set; }
        public GuessingGame(IEnumerable<Player> players)
        {
            Players = players;
            SetUpTurn();
        }

        private void SetUpTurn()
        {
            int firstIndex =0, secondIndex=0;
            if (Players.Count() >= 2) {
                while (firstIndex != secondIndex)
                {
                    Random random = new Random();
                    firstIndex = random.Next(Players.Count());
                    secondIndex = random.Next(Players.Count());
                }
            }
        }
        
        public bool CanContinue()
        {
            return CorrectCount > CorrectCount;
        }
        public bool CheckGuess(Player guessedPlayer)
        {
            IEnumerable<Player> winningPlayers =
                GetPlayerWithHighestFPPG(new List<Player> { Player1, Player2 });
            if (winningPlayers.Contains(guessedPlayer))
            {
                CorrectCount++;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the player in the list that the highest FanDuel Points per Game
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Player> GetPlayerWithHighestFPPG(IEnumerable<Player> players)
        {
            double? maxFppg = players.Max(x => x.FPPG);
            return players.Where(x => x.FPPG == maxFppg);
        }
    }
}
