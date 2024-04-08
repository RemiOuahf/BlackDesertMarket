using BlackDesertMarket.Items;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace BlackDesertMarket.API
{
    internal class WebAPIRequest
    {
        const string BASE_URL = "https://api.blackdesertmarket.com";
        const string LANGUAGE = "language=";
        const string REGION = "region=";

        public Action<string> OnRequestDone = null;
        public Action<APIRequest<QueueItem>> OnRequestQueueDone = null;

        string MakeURLWithID(long _id)
        {
            return BASE_URL + "/item/" + _id.ToString() + "?" + GetSaveRegionLanguage() ;
        }

        string GetSaveRegionLanguage()
        {
            return REGION + "eu" + "&" + LANGUAGE + "en-US";
        }

        string MakeURLIcon(int _id)
        {
            return BASE_URL + "/item/" + _id.ToString() + "/icon";   
        }

        string MakeURLQueue()
        {
            return BASE_URL + "/list/queue?" + GetSaveRegionLanguage();
        }
        
        string MakeURLMainSubCategories(int _main, int _sub)
        {
            return BASE_URL + "/list/" + _main + "/" + _sub + "?" + GetSaveRegionLanguage();
        } 

        public void RequestWithItemID(long _id)
        { 
           Request(MakeURLWithID(_id));
        }
        

        public byte[] RequestIconWithID(int _id)
        {
            WebClient client = new WebClient();
            byte[] imageData = client.DownloadData(MakeURLIcon(_id));
            return imageData;
            //string sURL;
            //sURL = MakeURLIcon(_id);
            //WebRequest request;
            //request = WebRequest.Create(sURL);
            //Stream _object;
            //_object = request.GetResponse().GetResponseStream();
            //StreamReader objReader = new StreamReader(_object);
            //return objReader.ReadToEnd();
        }

        async void Request(string _url)
        {
            HttpResponseMessage response = await new HttpClient().GetAsync(_url);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Request Error");
                return;
            }
            response.EnsureSuccessStatusCode();
            string _res = await response.Content.ReadAsStringAsync();
            OnRequestDone.Invoke(_res);
        }

        async void RequestQueue(string _url)
        {
                HttpResponseMessage response = await new HttpClient().GetAsync(_url);
                if (!response.IsSuccessStatusCode)
                    return;
                response.EnsureSuccessStatusCode();
                byte[] _res = await response.Content.ReadAsByteArrayAsync();
                string asciiString = Encoding.ASCII.GetString(_res, 0, _res.Length);
                APIRequest<QueueItem> _finalRes = Json.JsonConverter.ConvertTo<APIRequest<QueueItem>>(asciiString);
                
                OnRequestQueueDone?.Invoke(_finalRes);
        }

        async void RequestAsync(string _url)
        {
            HttpClient _client = new HttpClient();
            _client.BaseAddress = new Uri(_url);
            HttpRequestMessage _req = new HttpRequestMessage(HttpMethod.Get, _url);
            _client.SendAsync(_req).Wait();
            string _res = await _req.Content.ReadAsStringAsync();
            OnRequestDone.Invoke(_res);
        }

        public void RequestMainSub(int _main, int _sub)
        {
           Request(MakeURLMainSubCategories(_main, _sub));
        }

        public void RequestQueue()
        {
           RequestQueue(MakeURLQueue());
        }
    }
}
