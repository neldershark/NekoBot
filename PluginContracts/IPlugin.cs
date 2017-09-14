﻿using Discord;
using System.Collections.Generic;

namespace NekoBot.Services.Neko
{
    public interface IService
    {
        string Name { get; }

        void Connect(DiscordClient client);

        List<string> ComamndsHelp { get; }
    }
}
