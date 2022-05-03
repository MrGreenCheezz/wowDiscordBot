using Discord;
using Discord.WebSocket;
using System.Text.RegularExpressions;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordBot
{
    public class MessageComponentHandler
    {
        char containerBorder = '^';
        private readonly DiscordSocketClient _client;
        Regex regexForContainer = new Regex(@"\^.+\^");
        Regex regexForData = new Regex(@"_{1}\S+");
        public MessageComponentHandler(DiscordSocketClient client)
        {
            _client = client;
        }
        public async Task InstallHandler()
        {
            _client.SelectMenuExecuted += MyMenuHandler;
            _client.ButtonExecuted += MyButtonsHandler;
            await Task.CompletedTask;
        }

      

        public async Task MyButtonsHandler(SocketMessageComponent component)
        {
            
            switch (component.Data.CustomId)
            {
                
                case "mm+":
                    {
                        var builder = new ComponentBuilder();
                        var menu = CreateClassSelector("mm+ClassSelector");

                        await component.UpdateAsync(x =>
                       {
                           x.Content = "Какой класс?" + "\n" + containerBorder + "_MM+ " + containerBorder;
                           x.Components = new ComponentBuilder().WithSelectMenu(menu).Build();
                       });
                        break;
                    }
                case "arena2s":
                    {
                        var builder = new ComponentBuilder();
                        var menu = CreateClassSelector("arena2sClassSelector");
                        await component.UpdateAsync(x =>
                        {
                            x.Content =  "Какой класс?" + "\n" + containerBorder + "_2v2 " + containerBorder;
                            x.Components = new ComponentBuilder().WithSelectMenu(menu).Build();
                        });
                        break;
                    }
                case "arena3s":
                    {
                        var builder = new ComponentBuilder();
                        var menu = CreateClassSelector("arena3sClassSelector");
                        await component.UpdateAsync(x =>
                        {
                            x.Content = "Какой класс?" + "\n" + containerBorder + "_3v3 " + containerBorder;
                            x.Components = new ComponentBuilder().WithSelectMenu(menu).Build();
                        });
                        break;
                    }
            }
        }
        public SelectMenuBuilder CreateClassSelector( string CustomId)
        {
            var menu = new SelectMenuBuilder()
                .WithCustomId(CustomId)
                .WithPlaceholder("Select a class")
                .WithMaxValues(1)
                .WithMinValues(1)
                .AddOption("Mage", "Mage")
                .AddOption("Warrior", "Warrior")
                .AddOption("Rogue", "Rogue")
                .AddOption("Hunter", "Hunter")
                .AddOption("Priest", "Priest")
                .AddOption("Druid", "Druid")
                .AddOption("Paladin", "Paladin")
                .AddOption("Shaman", "Shaman")
                .AddOption("Death Knight", "Death-Knight")
                .AddOption("Warlock", "Warlock")
                .AddOption("Monk", "Monk")
                .AddOption("Demon Hunter", "Demon-Hunter");
            return menu;
        }
        public SelectMenuBuilder CreateSpecSelector(string CustomId, string selectedClass)
        {
            switch (selectedClass)
            {
                case "Mage":
                    {
                        var menu = new SelectMenuBuilder()
                        .WithCustomId(CustomId)
                        .WithPlaceholder("Select a specialization")
                        .WithMaxValues(1)
                        .WithMinValues(1)
                        .AddOption("Arcane", "Arcane")
                        .AddOption("Fire", "Fire")
                        .AddOption("Frost", "Frost");
                        return menu;
                    }
                case "Warrior":
                    {
                        var menu = new SelectMenuBuilder()
                        .WithCustomId(CustomId)
                        .WithPlaceholder("Select a specialization")
                        .WithMaxValues(1)
                        .WithMinValues(1)
                        .AddOption("Arms", "Arms")
                        .AddOption("Fury", "Fury")
                        .AddOption("Protection", "Protection");
                        return menu;
                    }
                case "Rogue":
                    {
                        var menu = new SelectMenuBuilder()
                        .WithCustomId(CustomId)
                        .WithPlaceholder("Select a specialization")
                        .WithMaxValues(1)
                        .WithMinValues(1)
                        .AddOption("Assassination", "Assassination")
                        .AddOption("Outlaw", "Outlaw")
                        .AddOption("Subtlety", "Subtlety");
                        return menu;
                    }
                case "Hunter":
                    {
                        var menu = new SelectMenuBuilder()
                        .WithCustomId(CustomId)
                        .WithPlaceholder("Select a specialization")
                        .WithMaxValues(1)
                        .WithMinValues(1)
                        .AddOption("Beast Mastery", "Beast-Mastery")
                        .AddOption("Marksmanship", "Marksmanship")
                        .AddOption("Survival", "Survival");
                        return menu;
                    }
                case "Priest":
                    {
                        var menu = new SelectMenuBuilder()
                        .WithCustomId(CustomId)
                        .WithPlaceholder("Select a specialization")
                        .WithMaxValues(1)
                        .WithMinValues(1)                        
                        .AddOption("Discipline", "Discipline")
                        .AddOption("Holy", "Holy")
                        .AddOption("Shadow", "Shadow");
                        return menu;
                    }
                case "Druid":
                    {
                        var menu = new SelectMenuBuilder()
                        .WithCustomId(CustomId)
                        .WithPlaceholder("Select a specialization")
                        .WithMaxValues(1)
                        .WithMinValues(1)                        
                        .AddOption("Balance", "Balance")
                        .AddOption("Feral", "Feral")
                        .AddOption("Guardian", "Guardian")
                        .AddOption("Restoration", "Restoration");
                        return menu;
                    }
                case "Paladin":
                    {
                        var menu = new SelectMenuBuilder()
                        .WithCustomId(CustomId)
                        .WithPlaceholder("Select a specialization")
                        .WithMaxValues(1)
                        .WithMinValues(1)                        
                        .AddOption("Holy", "Holy")
                        .AddOption("Protection", "Protection")
                        .AddOption("Retribution", "Retribution");
                        return menu;
                    }
                case "Shaman":
                    {
                        var menu = new SelectMenuBuilder()
                        .WithCustomId(CustomId)
                        .WithPlaceholder("Select a specialization")
                        .WithMaxValues(1)
                        .WithMinValues(1)
                        .AddOption("Elemental", "Elemental")
                        .AddOption("Enhancement", "Enhancement")
                        .AddOption("Restoration", "Restoration");
                        return menu;
                    }
                case "Death-Knight":
                    {
                        var menu = new SelectMenuBuilder()
                        .WithCustomId(CustomId)
                        .WithPlaceholder("Select a specialization")
                        .WithMaxValues(1)
                        .WithMinValues(1)
                        .AddOption("Blood", "Blood")
                        .AddOption("Frost", "Frost")
                        .AddOption("Unholy", "Unholy");
                        return menu;
                    }
                case "Warlock":
                    {
                        var menu = new SelectMenuBuilder()
                        .WithCustomId(CustomId)
                        .WithPlaceholder("Select a specialization")
                        .WithMaxValues(1)
                        .WithMinValues(1)                        
                        .AddOption("Affliction", "Affliction")
                        .AddOption("Demonology", "Demonology")
                        .AddOption("Destruction", "Destruction");
                        return menu;
                        
                    }
                case "Monk":
                    {
                        var menu = new SelectMenuBuilder()
                        .WithCustomId(CustomId)
                        .WithPlaceholder("Select a specialization")
                        .WithMaxValues(1)
                        .WithMinValues(1)
                        .AddOption("Brewmaster", "Brewmaster")
                        .AddOption("Mistweaver", "Mistweaver")
                        .AddOption("Windwalker", "Windwalker");
                        return menu;
                    }
                case "Demon-Hunter":
                    {
                        var menu = new SelectMenuBuilder()
                        .WithCustomId(CustomId)
                        .WithPlaceholder("Select a specialization")
                        .WithMaxValues(1)
                        .WithMinValues(1)
                        .AddOption("Havoc", "Havoc")
                        .AddOption("Vengeance", "Vengeance");
                        return menu;
                    }
                    

            }
            return new SelectMenuBuilder();

        }
        public SelectMenuBuilder CreateInfoSelector(string CustomId)
        {
            var menu = new SelectMenuBuilder()
                .WithCustomId(CustomId)
                .WithPlaceholder("Select a info type")
                .WithMaxValues(1)
                .WithMinValues(1)
                .AddOption("Статы", "Stats")
                .AddOption("Таланты", "Talents")
                .AddOption("Legendary (будет позже)", "Legendary")
                .AddOption("ПвП Таланты", "PvP Talents")
                .AddOption("Ковенанты", "Covenants");
            return menu;

        }
        public async Task MyMenuHandler(SocketMessageComponent arg)
        {
            switch (arg.Data.CustomId)
            {
                case "mm+ClassSelector":
                    {
                        var builder = new ComponentBuilder();
                        var specMenu = CreateSpecSelector("mm+SpecSelector", arg.Data.Values.First());
                        var matches = regexForContainer.Match(arg.Message.Content.ToString());
                        string tempInfo = matches.Value;                      
                        await arg.UpdateAsync(x =>
                        {                             
                            x.Content = "Какая специализация?" + "\n" + containerBorder + tempInfo.Substring(1, tempInfo.Length - 1) + "_" + arg.Data.Values.First() + " " + containerBorder;
                            x.Components = new ComponentBuilder().WithSelectMenu(specMenu).Build();
                        });
                        break;
                    }
                case "arena2sClassSelector":
                    {
                        var builder = new ComponentBuilder();
                        var specMenu = CreateSpecSelector("arena2sSpecSelector", arg.Data.Values.First());
                        var matches = regexForContainer.Match(arg.Message.Content.ToString());
                        string tempInfo = matches.Value;
                        await arg.UpdateAsync(x =>
                        {
                            x.Content = "Какая специализация?" + "\n" + containerBorder + tempInfo.Substring(1, tempInfo.Length - 1) + "_" + arg.Data.Values.First() + " " + containerBorder;
                            x.Components = new ComponentBuilder().WithSelectMenu(specMenu).Build();
                        });
                        break;
                    }
                case "arena3sClassSelector":
                    {
                        var builder = new ComponentBuilder();
                        var specMenu = CreateSpecSelector("arena3sSpecSelector", arg.Data.Values.First());
                        var matches = regexForContainer.Match(arg.Message.Content.ToString());
                        string tempInfo = matches.Value;
                        await arg.UpdateAsync(x =>
                        {
                            x.Content = "Какая специализация?"+ "\n" + containerBorder + tempInfo.Substring(1, tempInfo.Length - 1) + "_" + arg.Data.Values.First() + " " + containerBorder;
                            x.Components = new ComponentBuilder().WithSelectMenu(specMenu).Build();
                        });
                        break;
                    }
                case "mm+SpecSelector":
                    {
                        var builder = new ComponentBuilder();
                        var infoMenu = CreateInfoSelector("InfoSelector");
                        var matches = regexForContainer.Match(arg.Message.Content.ToString());
                        string tempInfo = matches.Value;
                        await arg.UpdateAsync(x =>
                        {
                            x.Content = "Какой информационный тип?" + "\n" + containerBorder + tempInfo.Substring(1, tempInfo.Length - 1) + "_" + arg.Data.Values.First() + " " + containerBorder;
                            x.Components = new ComponentBuilder().WithSelectMenu(infoMenu).Build();
                        });
                        break;
                    }
                case "arena2sSpecSelector":
                    {
                        var builder = new ComponentBuilder();
                        var infoMenu = CreateInfoSelector("InfoSelector");
                        var matches = regexForContainer.Match(arg.Message.Content.ToString());
                        string tempInfo = matches.Value;
                        await arg.UpdateAsync(x =>
                        {
                            x.Content = "Какой информационный тип?" + "\n" + containerBorder + tempInfo.Substring(1, tempInfo.Length - 1) + "_" + arg.Data.Values.First() + " " + containerBorder;
                            x.Components = new ComponentBuilder().WithSelectMenu(infoMenu).Build();
                        });
                        break;
                    }
                case "arena3sSpecSelector":
                    {
                        var builder = new ComponentBuilder();
                        var infoMenu = CreateInfoSelector("InfoSelector");
                        var matches = regexForContainer.Match(arg.Message.Content.ToString());
                        string tempInfo = matches.Value;
                        await arg.UpdateAsync(x =>
                        {
                            x.Content = "Какой информационный тип?" + "\n" + containerBorder + tempInfo.Substring(1, tempInfo.Length - 1) + "_" + arg.Data.Values.First() + " " + containerBorder;
                            x.Components = new ComponentBuilder().WithSelectMenu(infoMenu).Build();
                        });
                        break;
                    }
                case "InfoSelector":
                    {
                        var matches = regexForContainer.Match(arg.Message.Content.ToString());
                        var infoMatches = regexForData.Matches(matches.Value);
                        var statsHandler = new CharactersStatisticsHandler();
                        string tempInfo = matches.Value;
                        string contentType = infoMatches[0].Value;
                        string classType = infoMatches[1].Value;
                        string specType = infoMatches[2].Value;
                        var contentTypeEdited = contentType.Substring(1, contentType.Length - 1).ToLower();
                        var classTypeEdited = classType.Substring(1, classType.Length - 1).ToLower();
                        var specTypeEdited = specType.Substring(1, specType.Length - 1).ToLower();
                        string infoType = arg.Data.Values.First();
                        string taskString = await statsHandler.GetStatsPopularity(classTypeEdited, specTypeEdited, contentTypeEdited, infoType);
                        await arg.UpdateAsync(async x =>
                        {
                            x.Content = containerBorder + contentType + " " + classType + " " + specType + " " + "_" + arg.Data.Values.First() + " " + containerBorder + "\n" + "```json\n" + '"'+ "\n" + taskString + '"' + "\n" + "```";
                        });
                        break;
                    }
                    
            }
            
        }
    }
}
