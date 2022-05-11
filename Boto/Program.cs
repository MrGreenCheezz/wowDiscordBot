using System;
using Discord;
using Discord.Commands;
using System.Threading.Tasks;
using Discord.WebSocket;


namespace DiscordBot
{
    public class Program
    {
       
        public static Task Main(string[] args) => new Program().MainAsync();
        private DiscordSocketClient _client;
        private CommandService _commands;
        private CommandHandler _handler;
        private MessageComponentHandler _messageHandler;
        [STAThread]
        public async Task MainAsync()
        {
           
            _client = new DiscordSocketClient();
            _commands = new CommandService();
            _handler = new CommandHandler(_client, _commands);
            _handler.InstallCommandsAsync();
            _messageHandler = new MessageComponentHandler(_client);
            _messageHandler.InstallHandler();

            _commands.Log += Log;
            _client.Log += Log;
          
            var token = "Token here!";

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }
        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }



    }
}