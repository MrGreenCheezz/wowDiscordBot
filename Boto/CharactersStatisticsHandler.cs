using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Globalization;
using System.Linq;

namespace DiscordBot
{
    public class CharactersStatisticsHandler
    {
        
        public Dictionary<string, List<string>> TalentsTiers;
        public async Task GetMurlokFullInfo(string charClass, string charSpec, string contentType)
        {
            HttpClient client = new HttpClient();
            string url = "https://murlok.io/guides/" + charClass + "/" + charSpec + "/" + contentType;
            var resultString = await client.GetStringAsync(url);
            dynamic jsonResult = JsonConvert.DeserializeObject(resultString);
            await jsonResult;
        }
        
        public async Task<string> GetStatsPopularity(string charClass, string charSpec, string contentType,string infoType)
        {
            HttpClient client = new HttpClient();
            string url = "https://murlok.io/guides/" + charClass + "/" + charSpec + "/" + contentType;
            var resultString = await client.GetStringAsync(url);
            dynamic jsonResult = JsonConvert.DeserializeObject(resultString);
            Task<string> task = Task.FromResult("NO DATA");
            switch (infoType)
            {
                case "Stats":
                    string strHaste = jsonResult.Characters[0].HasteValue;
                    string strMastery = jsonResult.Characters[0].MasteryValue;
                    string strCrit = jsonResult.Characters[0].CritValue;
                    string strVers = jsonResult.Characters[0].VersatilityATK;
                    double haste = Math.Round(float.Parse(strHaste, CultureInfo.InvariantCulture), 1);
                    double crit = Math.Round(float.Parse(strMastery, CultureInfo.InvariantCulture), 1);
                    double mastery = Math.Round(float.Parse(strCrit, CultureInfo.InvariantCulture), 1);
                    double versatility = Math.Round(float.Parse(strVers, CultureInfo.InvariantCulture), 1);
                    string ParsedStats = "Скорость: " + haste + "%\n" + "Крит: " + crit + "%\n" + "Искусность: " + mastery + "%\n" + "Универсальность: " + versatility + "%";
                    task = Task.FromResult(ParsedStats);
                    return ParsedStats;

                case "Talents":
                    {
                        Dictionary<string, int> StatsByName;
                        TalentsTiers = new Dictionary<string, List<string>>();
                        StatsByName = new Dictionary<string, int>();
                        foreach (dynamic Character in jsonResult.Characters)
                        {
                            foreach (dynamic talent in Character.Talents)
                            {
                                if (TalentsTiers.ContainsKey(talent.TierIndex.ToString()))
                                {
                                    if (TalentsTiers[talent.TierIndex.ToString()].Contains(talent.Name.ToString()))
                                    {
                                        
                                    }
                                    else
                                    {
                                        TalentsTiers[talent.TierIndex.ToString()].Add(talent.Name.ToString());
                                    }
                                }
                                else
                                {
                                    TalentsTiers.Add(talent.TierIndex.ToString(), new List<string>());
                                    TalentsTiers[talent.TierIndex.ToString()].Add(talent.Name.ToString());
                                }

                                if (StatsByName.ContainsKey(talent.Name.ToString()))
                                {
                                    StatsByName[talent.Name.ToString()] += 1;
                                }
                                else
                                {
                                    StatsByName.Add(talent.Name.ToString(), 1);
                                }
                            }
                        }
                        string ParsedTalents = "";
                        foreach(KeyValuePair<string, List<string>> i in TalentsTiers)
                        {
                            ParsedTalents += i.Key + "  " + ":";
                            foreach(string tal in i.Value)
                            {
                                ParsedTalents += tal + " " + StatsByName[tal] * 2 + "%" + "    ";
                            }
                            ParsedTalents += "\n";
                        }
                        return ParsedTalents;
                    }
                case "Covenants":
                    {
                        Dictionary<string, int> StatsByName;
                        StatsByName = new Dictionary<string, int>();
                        foreach (dynamic Character in jsonResult.Characters)
                        {
                            if (StatsByName.ContainsKey(Character.CovenantSlug.ToString()))
                            {
                                StatsByName[Character.CovenantSlug.ToString()] += 1;
                            }
                            else
                            {
                                StatsByName.Add(Character.CovenantSlug.ToString(), 1);
                            }
                        }
                        string ParsedCovenants = "";
                        foreach(KeyValuePair<string, int> i in StatsByName)
                        {
                            ParsedCovenants += i.Key + "   " + i.Value * 2 + "%" + "\n";
                        }
                        return ParsedCovenants;
                    }
                case "PvP Talents":
                    {
                        Dictionary<string, int> StatsByName;                       
                        StatsByName = new Dictionary<string, int>();
                        foreach (dynamic Character in jsonResult.Characters)
                        {
                            foreach (dynamic talent in Character.PvPTalents)
                            {
                               

                                if (StatsByName.ContainsKey(talent.Name.ToString()))
                                {
                                    StatsByName[talent.Name.ToString()] += 1;
                                }
                                else
                                {
                                    StatsByName.Add(talent.Name.ToString(), 1);
                                }
                            }
                        }
                        string ParsedTalents = "";
                        var orderedDic = StatsByName.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                        int count = 0;
                        foreach (KeyValuePair<string, int> i in orderedDic)
                        {
                            if (count >= 5) break;
                            ParsedTalents += i.Key + "   " + i.Value*2 + "%" + "\n";
                            count++;

                        }
                        return ParsedTalents;
                    }

            }



            return "no data";
        }
    }
}
