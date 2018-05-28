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

		public AnswerPage (CurrentQoestion qoestion)
		{
			InitializeComponent ();
            answer1.Text = qoestion.QuestionAnswer[0].answerText;
            Answer2.Text = qoestion.QuestionAnswer[1].answerText;
            Answer3.Text = qoestion.QuestionAnswer[2].answerText;
            Answer4.Text = qoestion.QuestionAnswer[3].answerText;

        }
    }
}