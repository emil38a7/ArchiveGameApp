using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ArchiveGameApp
{
    public partial class App : Application
    {
        public List<CurrentQoestion> nextQuestions;
        httpService httpServices;

        Game game;
        CurrentQoestion curerrentQuestion;
        CurrentQoestion nextQuestion;

        public App()
        {
            InitializeComponent();
            curerrentQuestion = new CurrentQoestion("0", "", new QuestionAnswer[] { }, "");
            httpServices = new httpService();
            TimeSpan ts = new TimeSpan(0, 0, 5);

            MainPage page = new MainPage();
            MainPage = new NavigationPage(page);
        }

        protected override void OnStart()
        {
        }

        public async void StartTask() // call when loggin btn succed
        {
            /*
            await Task.Run(() =>
                updateQuestionAsync());
            */

            Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            {
                Task.Run(async () =>
                {
                    //var time = await RequestTimeAsync();
                    // do something with time...
                    System.Diagnostics.Debug.WriteLine("test: ");

                    nextQuestions = new List<CurrentQoestion>(await httpServices.LoadQuestion());
                    nextQuestion = nextQuestions[0];

                    if (curerrentQuestion.questionID != nextQuestion.questionID)
                    {
                        await MainPage.Navigation.PushAsync(new AnswerPage(nextQuestion), true);
                        curerrentQuestion = nextQuestion;

                    }
                });
                return true;
            });
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public async void updateQuestionAsync()
        {

            nextQuestions = new List<CurrentQoestion>(await httpServices.LoadQuestion());
            nextQuestion = nextQuestions[0];
            if (curerrentQuestion.questionID != nextQuestion.questionID)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await MainPage.Navigation.PushAsync(new AnswerPage(nextQuestion), true);
                });

                curerrentQuestion = nextQuestion;
            };

            await Task.Delay(1000);
        }
    }
}
/*
           MainPage = new NavigationPage(new MainPage());

           TimeSpan ts = new TimeSpan(0, 0, 5);

           Device.StartTimer(ts, async () => 
            {
                System.Diagnostics.Debug.WriteLine("test: ");

                nextQuestions = new List<CurrentQoestion>(await httpServices.LoadQuestion());
                nextQuestion = nextQuestions[0];

                if (curerrentQuestion.QuestionID != nextQuestion.QuestionID)
                {
                    await MainPage.Navigation.PushAsync(new AnswerPage(nextQuestion), true);
                }

               //await Navigation.PushAsync(new AnswerPage(null), true);
               //MainPage.DisplayAlert("Alert", "Next Question is: " , "OK");
               return true;

    public async void updateQuestionAsync()
        {
            nextQuestions = new List<CurrentQoestion>(await httpServices.LoadQuestion());
            nextQuestion = nextQuestions[0];

            if (curerrentQuestion.QuestionID != nextQuestion.QuestionID)
            {
                await MainPage.Navigation.PushAsync(new AnswerPage(nextQuestion), true);
                curerrentQuestion = nextQuestion;
            };
            await Task.Delay(1000);
        }

            });*/
