using System;
using System.Collections.Generic;
using System.Text;

namespace LyricsTovMix.OpenLP
{
    internal class Poll
    {
        public PollResult Results { get; set; }

        internal class PollResult
        {
            public bool Display { get; set; }

            public bool Blank { get; set; }

            public bool IsSecure { get; set; }

            public int Version { get; set; }

            public bool Theme { get; set; }

            public string Item { get; set; }

            public int Service { get; set; }

            public int Slide { get; set; }

            public bool Twelve { get; set; }
        }

    }
}
