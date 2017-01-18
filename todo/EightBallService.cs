﻿using System;
using System.Collections.Generic;

namespace NekoBot.Services
{
    public class EightBallService
    {
        //load from file
        private static List<string> anwsers = new List<string>
        {
            "As I see it, yes",
            "Better not tell you now",
            "Cannot predict now",
            "Don't count on it",
            "If you say so",
            "In your dreams",
            "It is certain",
            "Most likely",
            "My CPU is saying no",
            "My CPU is saying yes",
            "Out of psychic coverage range",
            "Signs point to yes",
            "Sure, sure",
            "Very doubtful",
            "When life gives you rice, you make rice",
            "Without a doubt",
            "Wow, Much no, very yes, so maybe",
            "Yes, definitely",
            "Yes, unless you run out of memes",
            "You are doomed",
            "You can\"t handle the truth",
            "私はあなたのお母さんを翻訳しました"
        };

        public static string Get()
        {
            Random random = new Random();
            int rnd = random.Next(0, anwsers.Count -1);
            return anwsers[rnd];
        }
    }
}