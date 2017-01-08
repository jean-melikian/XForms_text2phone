using System;
using System.Diagnostics;

using Android.App;
using Android.Content;

using XForms_text2phone;

[assembly: Xamarin.Forms.Dependency(typeof(PhoneDialer))]
namespace XForms_text2phone
{
	public class PhoneDialer : IPhoneDialer
	{
		private Context context;
		public PhoneDialer() {
			context = Android.App.Application.Context;
		}

		public void DialNumber(string phoneNumber)
		{
			Debug.WriteLine("PhoneNumber: " + phoneNumber);
			var uri = Android.Net.Uri.Parse("tel:" + phoneNumber);
			var intent = new Intent(Intent.ActionDial, uri);
			intent.AddFlags(ActivityFlags.NewTask);
			context.StartActivity(intent);
		}
	}
}
