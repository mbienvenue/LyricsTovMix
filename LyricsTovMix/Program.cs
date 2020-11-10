using System;
using System.Threading;
using System.Threading.Tasks;
using LyricsTovMix.OpenLP;
using LyricsTovMix.vMix;

namespace LyricsTovMix
{
    internal class Program
    {

        private static int origRow;
        private static int origCol;

        private static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            //var client = new HttpClient();
            //var uri = new Uri("http://" + Configuration.Instance.LyricsIP + ":" + Configuration.Instance.LyricsPortNumber + "/api/poll?_=1604841533657");
            //var content = await client.GetStringAsync(uri);
            //Poll poll = JsonConvert.DeserializeObject<Poll>(content);


            //var uri2 = new Uri("http://" + Configuration.Instance.LyricsIP + ":" + Configuration.Instance.LyricsPortNumber + "/api/controller/live/text");
            //var content2 = await client.GetStringAsync(uri2);
            //LiveText liveText = JsonConvert.DeserializeObject<LiveText>(content2);

            //Slide currentSlide = liveText.Results.Slides.Where(slide => slide.Selected).FirstOrDefault();

            //string currentText = currentSlide.Text;
            //Console.WriteLine("Current text: " + currentText);


            Console.Clear();
            origRow = Console.CursorTop;
            origCol = Console.CursorLeft;
            long spinnerCallCount = 0;
            bool sentTovMix = false;


            string previousSlide = string.Empty;

            ILyrics lyrics = new OpenLPEngine(Configuration.Instance.LyricsIP, Configuration.Instance.LyricsPortNumber);
            var vMix = new VMixEngine(Configuration.Instance.VMixIP, Configuration.Instance.VMixPort, Configuration.Instance.VMixInput, Configuration.Instance.VMixSelectedIndex);

            while (true)
            {
                string firstLine = "Lyrics connected ";
                string text = string.Empty;
                try
                {
                    text = await lyrics.GetCurrentSlideTextAsync();
                    if (string.IsNullOrEmpty(text))
                    {
                        Console.Clear();
                        Console.WriteLine("Lyrics connected, but currently nothing projected...");
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine("Cannot retrieve Lyrics:");
                    Console.WriteLine(ex);
                }

                if (!text.Equals(previousSlide, StringComparison.Ordinal))
                {
                    Console.Clear();
                    Console.WriteLine(firstLine);
                    Console.WriteLine(string.Empty);
                    Console.WriteLine("Current slide:");
                    Console.WriteLine("_________________________________________");
                    Console.WriteLine(text);
                    Console.WriteLine("_________________________________________");

                    previousSlide = text;
                    sentTovMix = false;
                }

                if (!sentTovMix && !string.IsNullOrEmpty(text))
                {
                    try
                    {
                        string secondLine = "Sent to vMix: ";
                        WriteAt(secondLine + "pending...", 0, 1);
                        vMix.SendTovMix(text);
                        WriteAt("OK !      ", secondLine.Length, 1);
                    }
                    catch (Exception ex)
                    {
                        Console.Clear();
                        Console.WriteLine("Cannot send to vMix:");
                        Console.WriteLine(ex);
                    }
                }

                if (!string.IsNullOrEmpty(text))
                {
                    Spin(firstLine.Length, ref spinnerCallCount);
                }

                Thread.Sleep(300);
            }
        }

        private static void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(origCol + x, origRow + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        private static void Spin(int lineLength, ref long spinnerCallCount)
        {
            string charToWrite;
            if (spinnerCallCount % 5 == 0)
            {
                charToWrite = "-";
            }
            else if (spinnerCallCount % 5 == 1)
            {
                charToWrite = "\\";
            }
            else if (spinnerCallCount % 5 == 2)
            {
                charToWrite = "|";
            }
            else if (spinnerCallCount % 5 == 3)
            {
                charToWrite = "/";
            }
            else
            {
                charToWrite = "-";
            }
            WriteAt(charToWrite, lineLength, 0);

            spinnerCallCount++;
        }
    }
}
