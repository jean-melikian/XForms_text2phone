using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace XForms_text2phone {
	public partial class HomePage : ContentPage {

		T9Model myDial;

		public HomePage() {
			InitializeComponent();
			// DataBinding T9Model <=> HomePage UI
			myDial = new T9Model();
			BindingContext = myDial;
		}

		void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e) {
			// This is preventing the use from dialing an invalid phone number
			if (myDial.IsNumberValid)
				dialButton.IsEnabled = true;
			else 
				dialButton.IsEnabled = false;
		}

		public async void onDialButtonClicked(object sender, EventArgs e) {
			if (myDial.IsNumberValid) {
				var answer = await DisplayAlert(myDial.Number, "Would you like to call " + myDial.Number + " ?", "Yes", "No");
				Debug.WriteLine("Dialing " + myDial.Number + ": " + answer);

				if (answer)
					DependencyService.Get<IPhoneDialer>().DialNumber(myDial.Number);
				
			} else {
				Debug.WriteLine("This phone number is invalid:" + myDial.Number);
				Debug.WriteLine("Text from model: " + myDial.Text);
			}
		}
	}
}
