using System;
using System.Collections.Generic;
using System.Text;

namespace LyricsTovMix.OpenLP
{
    internal class LiveText
    {
        public LiveTextResults Results { get; set; }

        internal class LiveTextResults
        {
            public string Item { get; set; }
            public List<Slide> Slides { get; set; }
        }
    }
}
