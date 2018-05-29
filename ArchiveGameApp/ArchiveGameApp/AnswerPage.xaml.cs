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

		public AnswerPage (CurrentQoestion nextQuestion)
		{
			InitializeComponent ();
            answer1.Text = nextQuestion.questionAnswers[0].answerText;
            Answer2.Text = nextQuestion.questionAnswers[1].answerText;
            Answer3.Text = nextQuestion.questionAnswers[2].answerText;
            Answer4.Text = nextQuestion.questionAnswers[3].answerText;

        }
    }
}