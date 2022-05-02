using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot
{
    public class GetMenuCommand : ModuleBase<SocketCommandContext>
    {
        
        [Command("guideMenu")]
        public async Task GuideMenu()
        {
            var builder = new ComponentBuilder()
                .WithButton("2v2", "arena2s")
                .WithButton("3v3", "arena3s")
                .WithButton("MM+", "mm+");
            await ReplyAsync(Context.User.Mention + "Какой тип контента?", components: builder.Build());
        }
        [Command("guideMenu2")]
        public async Task GuideMenu2()
        {
            var menuBuilder = new SelectMenuBuilder()
                .WithPlaceholder("Выберите категорию")
                .WithCustomId("custom-id")
                .WithMinValues(1)
                .WithMaxValues(3)
                .AddOption("Категория 1", "1")
                .AddOption("Категория 2", "2")
                .AddOption("Категория 3", "3");
            var builder = new ComponentBuilder()
                .WithSelectMenu(menuBuilder);
            await ReplyAsync("Кнопка блят", components: builder.Build());
        }
    }
}
