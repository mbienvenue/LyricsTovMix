using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LyricsTovMix
{
    internal interface ILyrics
    {
        public Task<string> GetCurrentSlideTextAsync();
       
    }
}
