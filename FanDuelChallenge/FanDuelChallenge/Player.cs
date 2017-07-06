
using System.Collections.Generic;

namespace FanDuelChallenge
{
    public class Player
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Images Images{ get; set;}
        /// <summary>
        /// FanDuel Points Per Game
        /// </summary>
        public double? FPPG { get; set;}
    }

    public class Images
    {
        public Image Default;
    }

    public class Image
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public string URL { get; set; }
    }
}