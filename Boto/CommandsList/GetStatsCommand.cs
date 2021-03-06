using Discord.Commands;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Globalization;

namespace DiscordBot
{
    public class GetStats : ModuleBase<SocketCommandContext>
    {
        [Command("guideStats")]
        [Summary("Get guide for character")]
        public async Task GetGuide(string CharClass, string specialization)
        {

            HttpClient client = new HttpClient();
            string url = "https://murlok.io/guides/" + CharClass + "/" + specialization + "/mm+";
            var resultString = await client.GetStringAsync(url);
            dynamic jsonResult = JsonConvert.DeserializeObject(resultString);
            string strHaste = jsonResult.Characters[0].HasteValue;
            string strMastery = jsonResult.Characters[0].MasteryValue;
            string strCrit = jsonResult.Characters[0].CritValue;
            string strVers = jsonResult.Characters[0].VersatilityATK;
            double haste = Math.Round(float.Parse(strHaste, CultureInfo.InvariantCulture), 1);
            double crit = Math.Round(float.Parse(strMastery, CultureInfo.InvariantCulture), 1);
            double mastery = Math.Round(float.Parse(strCrit, CultureInfo.InvariantCulture), 1);
            double versatility = Math.Round(float.Parse(strVers, CultureInfo.InvariantCulture), 1);
            string ParsedStats = "Haste: " + haste + "%\n" + "Crit: " + crit + "%\n" + "Mastery: " + mastery + "%\n" + "Versatility: " + versatility + "%";
            await ReplyAsync(ParsedStats);
        }



    }
}