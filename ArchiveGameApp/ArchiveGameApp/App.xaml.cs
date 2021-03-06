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

        public static Game game;
        public static Player player;
        CurrentQoestion curerrentQuestion;
        CurrentQoestion nextQuestion;
        CancellationTokenSource tokenSource;
        CancellationToken token;
       

        public App()
        {
            InitializeComponent();

            curerrentQuestion = new CurrentQoestion("0", "", new QuestionAnswer[] { }, "", "");
            httpServices = new httpService();
            TimeSpan ts = new TimeSpan(0, 0, 5);

            MainPage page = new MainPage();
            MainPage = new NavigationPage(page);
            //   MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }


        //CancellationTokenSource tokenSource = new CancellationTokenSource();
        public async void StartTask() // call when loggin btn succed
        {
             tokenSource = new CancellationTokenSource();
             token = tokenSource.Token;
           
            await Task.Run(async () =>
            {
                while (!token.IsCancellationRequested)
                {
                    updateQuestionAsync();
                    await Task.Delay(2000);
                }
            }, token);
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
            System.Diagnostics.Debug.WriteLine("Task is invoked");

            nextQuestions = new List<CurrentQoestion>(await httpServices.LoadQuestion());
            nextQuestion = nextQuestions[0]; //add somethimg
            if (curerrentQuestion.questionID != nextQuestion.questionID)
            {
                if (nextQuestion.questionIndex == App.game.gameLength)
                {
                    
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        App.game = await httpServices.GetGame();
                        if (App.game.gameStatus == "open")
                        {
                            //Task.
                            
                            await MainPage.Navigation.PushAsync(new ResultPage(), true);
                            tokenSource.Cancel();
                        }
                    });
                }
                else
                {
                    Device.BeginInvokeOnMainThread(async () =>
                   {
                       await MainPage.Navigation.PushAsync(new AnswerPage(nextQuestion), true);
                       curerrentQuestion = nextQuestion;
                   });
                }
            }
        }
    }
}
/*
 * 
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
