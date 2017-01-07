using Xamarin.Forms;

namespace XForms_text2phone
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			//MainPage = new XForms_text2phonePage();
			MainPage = new NavigationPage(new HomePage());
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
