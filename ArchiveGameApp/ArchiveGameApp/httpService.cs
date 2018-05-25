using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ArchiveGameApp
{
    class httpService
    {
        HttpClient client;


        string postPlayerUrl = "http://192.168.1.144:3000/player";

        public httpService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async void PostNewPlayer(Object player)
        {
            //   var player = new { playerNickName = nameEntry.Text };
            var json = JsonConvert.SerializeObject(player);
            //var json = "{\"playerNickName\": \"" + player.Text + "\"}";
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                HttpResponseMessage response = await client.PostAsync(postPlayerUrl, content);
                System.Diagnostics.Debug.WriteLine(response.ToString());

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Alert ", e.ToString());
            }
        }
    }
}
