using Discord.Commands;
using System.Threading.Tasks;

namespace DiscordBot
{
    public class TestCommand : ModuleBase<SocketCommandContext>
    {
        [Command("test")]
        [Summary("A test command")]
        public async Task Test(string arg)
        {
            await ReplyAsync("Test command was called with argument: " + arg);
        }
        [Command("test2")]
        [Summary("A test command")]
        public async Task Test2(int arg1, string arg2)
        {
            await ReplyAsync("Test command was called with argument: " + arg1 + " " + arg2);
        }

    }
}