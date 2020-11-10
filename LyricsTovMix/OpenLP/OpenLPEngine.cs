using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LyricsTovMix.OpenLP
{
    internal class OpenLPEngine : ILyrics
    {
        private string _openLPIP;
        private int _openLPPort;

        public OpenLPEngine(string openLPIP, int openLPPort)
        {
            _openLPIP = openLPIP;
            _openLPPort = openLPPort;
        }

        public async Task<string> GetCurrentSlideTextAsync()
        {
            var uri = new Uri("http://" + _openLPIP + ":" + _openLPPort + "/api/controller/live/text");
            var client = new HttpClient
            {
                Timeout = new TimeSpan(0, 0, 0, 0, 500)
            };
            //string content = await client.GetStringAsync(uri);
            var request = new HttpRequestMessage
            {
                RequestUri = uri,
                Method = HttpMethod.Get
            };
            HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();

            LiveText liveText = JsonConvert.DeserializeObject<LiveText>(content);
            string currentText = string.Empty;
            if (liveText.Results.Slides.Count > 0)
            {
                Slide currentSlide = liveText.Results.Slides.Where(slide => slide.Selected).FirstOrDefault();
                currentText = currentSlide.Text;
            }

            return currentText;
        }
    }
}
