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
            var game = await this.http.GetGame();
            string json = JsonConvert.SerializeObject(game);
            System.Diagnostics.Debug.WriteLine("JSON is " +json.ToString());
            if (json.Length == 2)
            {
                //  hiddenLabel.Text = "No game avalaible";
                await DisplayAlert("Alert", "No games available", "OK");
            }
            else
            {
                //await DisplayAlert("Alert", "Fuck You", "OK");
                Player player = new Player("", nicknameEntry.Text);
                player =  await this.http.PostNewPlayer(player);
                App.player = player;

                await this.Navigation.PushAsync(new LoadingPage());
                ((App)App.Current).StartTask();
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
