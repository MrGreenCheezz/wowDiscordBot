using Discord;
using Discord.Commands;
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
       
    }
}
