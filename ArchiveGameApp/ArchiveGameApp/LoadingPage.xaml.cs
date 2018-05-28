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
    public partial class LoadingPage : ContentPage
    {
        public List<CurrentQoestion> currentQuestions;
        public List<CurrentQoestion> nextQuestions;

        private httpService httpServices;
        public CurrentQoestion currentQuestion;

        public LoadingPage()
        {
            httpServices = new httpService();
            InitializeComponent();
            RotateElement();
            LoadQuestion();
        }
        private async Task RotateElement()
        {
            while (true)
            {
                await loadingImage.RotateTo(360, 2000, Easing.Linear);
                await loadingImage.RotateTo(0, 0);
            }
        }

        private async Task LoadQuestion()
        {
            //currentQuestions = new List<CurrentQoestion>(await httpServices.LoadQuestion());
            //CurrentQoestion currentQuestion = currentQuestions[0];

            currentQuestion = new CurrentQoestion("0", "", new QuestionAnswer[] { }, "");
            await DisplayAlert("Alert", "CurrentQuestion is: " + currentQuestion.QuestionID, "OK");


            nextQuestions = new List<CurrentQoestion>(await httpServices.LoadQuestion());
            CurrentQoestion nextQuestion = nextQuestions[0];

            await DisplayAlert("Alert", "CurrentQuestion is: " + currentQuestion.QuestionID, "OK");
            await DisplayAlert("Alert", "Next Question is: " + nextQuestion.QuestionID, "OK");

            while (currentQuestion.QuestionID == nextQuestion.QuestionID)
            {
                nextQuestions = new List<CurrentQoestion>(await httpServices.LoadQuestion());
                nextQuestion = nextQuestions[0];
                await Task.Delay(1000);            
            }

            currentQuestion = nextQuestion;
            await Navigation.PushAsync(new AnswerPage(null), true);
        }
        async void GoToQuestionsPageButtonClicked(object sender, EventArgs e)
        {
            //  await Navigation.PushModalAsync(new AnswerPage(), true);
        }

    }





}

