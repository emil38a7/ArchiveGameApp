﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveGameApp
{
    class httpService
    {
        HttpClient client;

        string postPlayerUrl = "http://192.168.1.144:3000/player";
        string getGameURL = "http://192.168.1.144:3000/game";
        string getCurrentQuestionURL = "http://192.168.1.144:3000/currentQuestion";

        public httpService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<List<Game>> GetGame()
        {
            //Object game = null;
            HttpResponseMessage response = await client.GetAsync(getGameURL);
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                var games = JsonConvert.DeserializeObject<List<Game>>(res);
                System.Diagnostics.Debug.WriteLine((JsonConvert.SerializeObject(games)).ToString());
                return games;
            }
            return null;
        }

        public async Task<List <CurrentQoestion>> LoadQuestion()
        {
            HttpResponseMessage response = await client.GetAsync(getCurrentQuestionURL);
            if (response.IsSuccessStatusCode)
            {             
                var res = await response.Content.ReadAsStringAsync();
                var currentQuestion = JsonConvert.DeserializeObject<List<CurrentQoestion>>(res);
                System.Diagnostics.Debug.WriteLine((JsonConvert.SerializeObject(currentQuestion)).ToString());
                return currentQuestion;
            }
            return null;
        }

        public async void PostNewPlayer(Object player)
        {
            var json = JsonConvert.SerializeObject(player);
            System.Diagnostics.Debug.WriteLine(json.ToString());
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
