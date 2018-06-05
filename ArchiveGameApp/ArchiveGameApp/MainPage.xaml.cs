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

        public async void Button_ClickedAsync(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new LoadingPage());

            App.game = await this.http.GetGame();
            //string json = JsonConvert.SerializeObject(game);
            //System.Diagnostics.Debug.WriteLine("JSON is " + json.ToString());
            if (App.game.gameID == null)
            {
                //  hiddenLabel.Text = "No game avalaible";
                await DisplayAlert("Alert", "No games available", "OK");
            }
            else
            {
                //await this.Navigation.PushAsync(new LoadingPage());
                Player player = new Player("", nicknameEntry.Text,"0");
                player = await this.http.PostNewPlayer(player);
                App.player = player;

                ((App)App.Current).StartTask();
            }
        }
    }

    public class Player
    {
        //public string _id;
        public string playerID;
        public string playerNickName;
        public string playerScore;

        public Player(string playerID, string playerNickName, string playerScore)
        {
            this.playerID = playerID;
            this.playerNickName = playerNickName;
            this.playerScore = playerScore;
        }

        [JsonConstructor]
        public Player(string _id, string playerID, string playerNickName, string playerScore)
        {
            //this._id = _id;
            this.playerID = playerID;
            this.playerNickName = playerNickName;
            this.playerScore = playerScore;
        }
    }

    public class Game
    {
        public string gameID;
        public string gameStatus;
        public string gameLength;

        public Game(string gameID, string gameStatus, string gameLength)
        {
            this.gameID = gameID;
            this.gameStatus = gameStatus;
            this.gameLength = gameLength;
        }
    }
}
