using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BlackDesertMarket.API
{
    internal class WebAPIRequest
    {
        const string BASE_URL = "https://api.blackdesertmarket.com";
        const string LANGUAGE = "language=";
        const string REGION = "region=";


        string MakeURLWithID(int _id)
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

        public string RequestWithItemID(int _id)
        { 
            return Request(MakeURLWithID(_id));
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

        string Request(string _url)
        {

            WebRequest request;
            request = WebRequest.Create(_url);
            Stream _object;
            _object = request.GetResponse().GetResponseStream();
            StreamReader objReader = new StreamReader(_object);
            return objReader.ReadToEnd();
        }

        public string RequestQueue()
        {
           return Request(MakeURLQueue());
        }
    }
}
