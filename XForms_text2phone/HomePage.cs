using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace XForms_text2phone {
	public partial class HomePage : ContentPage {
		
		public HomePage() {
			InitializeComponent();
		}

		//private static IPhoneDialer PhoneDialer { get; set; }

		public async void onButtonSubmitClicked(object sender, EventArgs e) {
			if (!String.IsNullOrEmpty(inputString.Text)) {
				var input = inputString.Text;

				var answer = await DisplayAlert("Translated !", "Would you like to call this number ?", "Yes", "No");
				Debug.WriteLine("Answer: " + answer);

				if (answer)
					DependencyService.Get<IPhoneDialer>().DialNumber(input);
				
			} else
				Debug.WriteLine("Field entry is null or empty !");
		}
	}
}
