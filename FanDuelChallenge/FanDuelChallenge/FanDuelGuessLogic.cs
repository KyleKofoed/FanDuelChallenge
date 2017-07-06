using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanDuelChallenge
{
    public class FanDuelGuessLogic
    {
        /// <summary>
        /// Gets the player in the list that the highest FanDuel Points per Game
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Player> GetPlayerWithHighestFPPG(IEnumerable<Player> players)
        {
            double maxFppg = players.Max(x => x.FPPG);
            return players.Where(x => x.FPPG == maxFppg);
        }
    }
}
