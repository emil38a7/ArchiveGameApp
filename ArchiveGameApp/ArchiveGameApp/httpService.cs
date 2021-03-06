﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        static string ip = "10.176.132.138";

        string postPlayerUrl = "http://" + ip + ":3000/player";
        string getGameURL = "http://" + ip + ":3000/game";
        string PostPlayerAnswerUrl = "http://" + ip + ":3000/answerRelation";
        string getCurrentQuestionURL;
        CurrentQoestion nextQuestion;

        public httpService()
        {
            getCurrentQuestionURL = "http://" + ip + ":3000/currentQuestion";

            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<Game> GetGame()
        {
            //Object game = null;
            HttpResponseMessage response = await client.GetAsync(getGameURL);
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                var games = JsonConvert.DeserializeObject<List<Game>>(res);
                if (games.Count == 0) return null;
                else { var game = games[0]; return game; }
                //System.Diagnostics.Debug.WriteLine((JsonConvert.SerializeObject(games)).ToString());
            }
            return null;
        }

        public async Task<List<CurrentQoestion>> LoadQuestion()
        {
            HttpResponseMessage response = await client.GetAsync(getCurrentQuestionURL);
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                var currentQuestion = JsonConvert.DeserializeObject<List<CurrentQoestion>>(res);
                System.Diagnostics.Debug.WriteLine("Hi" + (JsonConvert.SerializeObject(currentQuestion)).ToString());

                return currentQuestion;
            }
            return null;
        }

        public CurrentQoestion getQuestion()
        {
            return null;
        }

        public async Task<Player> PostNewPlayer(Object player)
        {
            var json = JsonConvert.SerializeObject(player);
            System.Diagnostics.Debug.WriteLine(json.ToString());
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                HttpResponseMessage response = await client.PostAsync(postPlayerUrl, content);
                System.Diagnostics.Debug.WriteLine("Server response " + response.ToString());
                string dataResult = response.Content.ReadAsStringAsync().Result;

                // var res = JsonConvert.DeserializeObject<List<Player>>(dataResult);
                JObject jPlayer = (JObject)JsonConvert.DeserializeObject(dataResult);

                Player objPlayer = new Player(jPlayer.Property("_id").Value.ToString(), jPlayer.Property("playerNickName").Value.ToString(), 
                                                                                        jPlayer.Property("playerScore").Value.ToString());

                System.Diagnostics.Debug.WriteLine(dataResult);

                return objPlayer;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Alert ", e.ToString());
                return null;
            }
        }

        public async void PostPlayerAnswer(AnswerRelation answerRelation)
        {
            var json = JsonConvert.SerializeObject(answerRelation);
            //System.Diagnostics.Debug.WriteLine(json.ToString());
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                HttpResponseMessage response = await client.PostAsync(PostPlayerAnswerUrl, content);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Alert ", e.ToString());
            }
        }
    }
}
