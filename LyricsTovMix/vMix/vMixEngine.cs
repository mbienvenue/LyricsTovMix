using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace LyricsTovMix.vMix
{
    internal class VMixEngine
    {
        private readonly string _vMixIp;
        private readonly int _vMixPort;
        private readonly int _vMixInput;
        private readonly int _vMixSelectedIndex;

        public VMixEngine(string vMixIp, int vMixPort, int vMixInput, int vMixSelectedIndex)
        {
            _vMixIp = vMixIp;
            _vMixPort = vMixPort;
            _vMixInput = vMixInput;
            _vMixSelectedIndex = vMixSelectedIndex;
        }

        public async Task<bool> SendTovMix(string text)
        {
            //"http://" + config.vmix_ip + ":" + config.vmix_port + "/api/?Function=SetText&SelectedIndex=0&Input=" + config.vmix_input + "&Value=" + text,            

            var uri = new Uri("http://" + _vMixIp + ":" + _vMixPort + "/api/?Function=SetText&SelectedIndex=" + _vMixSelectedIndex + "&Input=" + _vMixInput + "&Value=" + text);
            var request = new HttpRequestMessage
            {
                RequestUri = uri,
                Method = HttpMethod.Get
            };

            using (var client = new HttpClient
            {
                Timeout = new TimeSpan(0, 0, 0, 0, 500)
            })
            using (HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false))
            {
                response.EnsureSuccessStatusCode();
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
