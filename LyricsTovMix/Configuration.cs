using System.Configuration;

namespace LyricsTovMix
{
    internal class Configuration
    {
        public int LyricsPortNumber { get; set; }

        public string LyricsIP { get; set; }

        public string VMixIP { get; set; }

        public int VMixPort { get; set; }

        public int VMixInput { get; set; }

        public int VMixSelectedIndex { get; set; }


        private static Configuration _instance;
        public static Configuration Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }

                _instance = new Configuration
                {
                    LyricsIP = ConfigurationManager.AppSettings.Get("LyricsIp"),
                    LyricsPortNumber = int.Parse(ConfigurationManager.AppSettings.Get("LyricsPort")),
                    VMixIP = ConfigurationManager.AppSettings.Get("vMixIp"),
                    VMixPort = int.Parse(ConfigurationManager.AppSettings.Get("vMixPort")),
                    VMixInput = int.Parse(ConfigurationManager.AppSettings.Get("vMixInput")),
                    VMixSelectedIndex = int.Parse(ConfigurationManager.AppSettings.Get("vMixSelectedIndex")),
                };

                return _instance;
            }
        }
    }
}
