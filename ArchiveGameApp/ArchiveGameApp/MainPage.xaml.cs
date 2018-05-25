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

        private void Button_Clicked(object sender, EventArgs e)
        {
            Player player = new Player();
            System.Diagnostics.Debug.WriteLine("Hi***********************************");
            this.http.PostNewPlayer(new Player());
        }
    }

    public class Player
    {
        string playerID;
        string playerNickName;

        public Player()
        {
            playerID = "10";
            playerNickName = "Bob";
        }
    }
}
