﻿using System;
using Discord;
using PluginContracts;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace MagicBallPlugin
{
    public class MagicBallPlugin : IPlugin
    {
        public string Name => nameof(MagicBallPlugin);

        private DiscordClient client;
        private List<string> anwsers;

        public void Connect(DiscordClient client)
        {
            this.client = client;
            client.MessageReceived += Client_MessageReceived;
            anwsers = LoadAnwsers();
        }

        private void Client_MessageReceived(object sender, MessageEventArgs e)
        {
            if (!e.Message.IsAuthor && e.Message.Text.StartsWith("/8ball"))
            {
                e.Channel.SendMessage(GetRandomAnwser());
            }
        }
      
        private string GetRandomAnwser()
        {
            Random random = new Random();
            int rnd = random.Next(0, anwsers.Count - 1);
            return anwsers[rnd];
        }

        private List<string> LoadAnwsers()
        {
            const string configName = "MagicBallAnwsers.json";

            if (!File.Exists(configName))
            {
                File.WriteAllText(configName, JsonConvert.SerializeObject(new Answers(), Formatting.Indented));
            }
            return JsonConvert.DeserializeObject<Answers>(File.ReadAllText(configName)).Anwsers;
        }
    }
}
