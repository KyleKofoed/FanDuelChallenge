using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FanDuelChallenge
{
    public class FanDuelJsonHttpClient
    {
        private const string PlayersURL = "https://cdn.rawgit.com/liamjdouglas/bb40ee8721f1a9313c22c6ea0851a105/raw/6b6fc89d55ebe4d9b05c1469349af33651d7e7f1/Player.json";
        private HttpClient HttpClient = new HttpClient();
        
        /// <summary>
        /// Excutes a get request and returns players
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Player>> ReadPlayers()
        {
            try {

                HttpResponseMessage response = await HttpClient.GetAsync(PlayersURL);
                response.EnsureSuccessStatusCode();
                string playerJsonString = await response.Content.ReadAsStringAsync();
                PlayerJson playerJson = JsonConvert.DeserializeObject<PlayerJson>(playerJsonString);
                //filter out players with null fppg
                return playerJson.Players.Where(x=>x.FPPG.HasValue);
            }
            catch (Exception ex)
            {
                //if exception return empty list
                return new List<Player>();
            }
        }
    }
}
