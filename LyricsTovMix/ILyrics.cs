using System.Threading.Tasks;

namespace LyricsTovMix
{
    internal interface ILyrics
    {
        public Task<string> GetCurrentSlideTextAsync();

    }
}
