using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RiddleOfToday
{
	public partial class MainPage : ContentPage
	{
	    private RiddleOfTodayService.Riddle riddle;
		public MainPage()
		{
			InitializeComponent();
		}

	    //public void OnColorSliderChanged(Object sender, EventArgs e)
	    //{
	    //    var red = sliderRed.Value;
	    //    var green = sliderGreen.Value;
	    //    var blue = sliderBlue.Value;

	    //    boxViewColor.Color = Color.FromRgb(red, green, blue);
	    //}

	    public async void GetRiddleButton_Clicked(Object sender, EventArgs e)
	    {
	        try
	        {
	            InfoLabel.Text = "Hämtar dagens gåta...";
                RiddleQuestionLabel.Text = "";
	            RiddleAnswerLabel.Text = "";
                riddle = await RiddleOfTodayService.GetRiddleOfToday();

	            InfoLabel.Text = "";
                RiddleQuestionLabel.Text = riddle.Question;
	        }
	        catch (Exception exception)
	        {
	            Console.WriteLine(exception);
	            throw;
	        }
	    }

	    public void ShowAnswerButton_Clicked(object sender, EventArgs e)
	    {
	        if (riddle == null)
	            return;

	        if (riddle.Answer != null)
	        {
	            RiddleAnswerLabel.Text = riddle.Answer;
            }
	        BottomInfo.Text = $"{riddle.LastDisplayDateTime:yyyy-MM-dd} Antal visningar: {riddle.Views}";

            //RiddleDate.Text = riddle.LastDisplayDate;
            //RiddleDate.Text = riddle.LastDisplayDateTime.ToString("yyyy-MM-dd");
            //RiddleNoOfDisplays.Text = riddle.Views.ToString();
        }
    }
}
