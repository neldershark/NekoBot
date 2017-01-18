﻿using Discord;
using PluginContracts;
using System;
using System.Collections.Generic;

namespace NekoBot
{
    public class DiscordConnector
    {
        //https://discordapp.com/oauth2/authorize?&client_id=CLIENT_ID&scope=bot&permissions=0

        private Dictionary<string, IPlugin> availablePlugins;
        private DiscordClient client;
        private Config config;

        public DiscordConnector(Config config, Dictionary<string, IPlugin> availablePlugins)
        {
            this.availablePlugins = availablePlugins;
            this.config = config;
            client = new DiscordClient();
            client.Log.Message += Log_Message;
        }

        private void Log_Message(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine($"[{DateTime.Now.ToString()}][{e.Source}] {e.Message}");
        }

        public void Connect()
        {
            client.Log.Info("NekoBot", "Loading Plugins...");

            foreach (var plugin in availablePlugins)
            {
                plugin.Value.Connect(client);
                client.Log.Info("NekoBot", $"{plugin.Key} loaded");
            }
            client.Log.Info("NekoBot", "All Plugins loaded");

            client.ExecuteAndWait(async () => 
            {
                await client.Connect(config.BotAccountToken, TokenType.Bot);
            });
        }
    }
}