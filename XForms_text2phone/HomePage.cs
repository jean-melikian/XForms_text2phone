using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace XForms_text2phone
{
	public partial class HomePage : ContentPage
	{
		public HomePage()
		{
			InitializeComponent();
		}

		public async void onButtonSubmitClicked(object sender, EventArgs e) 
		{
			var answer = await DisplayAlert("Translated !", "Would you like to call this number ?", "Yes", "No");
			Debug.WriteLine("Answer: " + answer);
		}
	}
}
