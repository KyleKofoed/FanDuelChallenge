
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FanDuelChallenge
{
    public class Player
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
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