using System.IO;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace LyricsTovMix
{
    internal class Settings
    {
        public int LyricsPortNumber { get; set; }

        public string LyricsIP { get; set; }

        public string VMixIP { get; set; }

        public int VMixPort { get; set; }

        public int VMixInput { get; set; }

        public int VMixSelectedIndex { get; set; }
    }
    internal class Configuration
    {
        private static Settings _instance;

        public static Settings Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }

                IConfigurationRoot config2 = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("AppSettings.json", false, true)
                    .Build();
                Settings settings = config2.Get<Settings>();
                _instance = settings;
                return _instance;
            }
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
    }
}
