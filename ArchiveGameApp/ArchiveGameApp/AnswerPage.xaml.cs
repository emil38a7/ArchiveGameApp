using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArchiveGameApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AnswerPage : ContentPage
	{
        string answerOne;
        string answerTwo;
        string answerThree;
        string answerFour;
        httpService httpService;

		public AnswerPage (CurrentQoestion nextQuestion)
		{
			InitializeComponent ();
            httpService = new httpService();
            answer1Button.Text = nextQuestion.questionAnswers[0].answerText;
            answer2Button.Text = nextQuestion.questionAnswers[1].answerText;
            answer3Button.Text = nextQuestion.questionAnswers[2].answerText;
            answer4Button.Text = nextQuestion.questionAnswers[3].answerText;
        }



        public async void AnswerButtonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;

            answer1Button.BackgroundColor = Color.FromHex("#8A3033");
            answer1Button.TextColor = Color.FromHex("#EAE7DC");

            answer1Button.IsEnabled = false;
            answer2Button.IsEnabled = false;
            answer3Button.IsEnabled = false;
            answer4Button.IsEnabled = false;

            //httpService.PostPlayerAnswer
        }
        public async void Answer2ButtonClicked(object sender, EventArgs e)
        {
            answer2Button.BackgroundColor = Color.FromHex("#8A3033");
            answer2Button.TextColor = Color.FromHex("#EAE7DC");
            answer1Button.IsEnabled = false;
            answer2Button.IsEnabled = false;
            answer3Button.IsEnabled = false;
            answer4Button.IsEnabled = false;
        }
        public async void Answer3ButtonClicked(object sender, EventArgs e)
        {
            answer3Button.BackgroundColor = Color.FromHex("#8A3033");
            answer3Button.TextColor = Color.FromHex("#EAE7DC");
            answer1Button.IsEnabled = false;
            answer2Button.IsEnabled = false;
            answer3Button.IsEnabled = false;
            answer4Button.IsEnabled = false;
        }
        public async void Answer4ButtonClicked(object sender, EventArgs e)
        {
            answer4Button.BackgroundColor = Color.FromHex("#8A3033");
            answer4Button.TextColor = Color.FromHex("#EAE7DC");
            answer1Button.IsEnabled = false;
            answer2Button.IsEnabled = false;
            answer3Button.IsEnabled = false;
            answer4Button.IsEnabled = false;
        }

        private void answer1Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}