using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ArchiveGameApp
{
    public partial class MainPage : ContentPage
    {
        httpService http;
        public MainPage()
        {
            InitializeComponent();
            http = new httpService();
        }

        private async void Button_ClickedAsync(object sender, EventArgs e)
        {
            //Player player = new Player("10", "Bob");
            //this.http.PostNewPlayer(player);
            var game = await this.http.GetGame();
            string json = JsonConvert.SerializeObject(game);
            System.Diagnostics.Debug.WriteLine("JSON is " +json.ToString());
            if (json.Length == 2)
            {
                hiddenLabel.Text = "No game avalaible";
            }
            else
            {
                this.Navigation.PushAsync(new AnswerPage());
            }
        }
    }

    public class Player
    {
        public string playerID;
        public string playerNickName;

        public Player(string playerID, string playerNickName)
        {
            this.playerID = playerID;
            this.playerNickName = playerNickName;
        }
    }

    public class Game
    {
        public string gameID;

        public Game(string gameID)
        {
            this.gameID = gameID;
        }
    }
}
