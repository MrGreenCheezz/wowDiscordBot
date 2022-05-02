using Discord.Commands;

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
    }
}