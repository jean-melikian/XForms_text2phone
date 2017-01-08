using System;
using System.Diagnostics;

using Foundation;
using UIKit;

using XForms_text2phone;

[assembly: Xamarin.Forms.Dependency(typeof(PhoneDialer))]
namespace XForms_text2phone
{
	public class PhoneDialer : IPhoneDialer
	{
		public PhoneDialer() {}

		public void DialNumber(string phoneNumber)
		{
			Debug.WriteLine("PhoneNumber: " + phoneNumber);
			var url = new NSUrl("tel:" + phoneNumber);
			if (!UIApplication.SharedApplication.OpenUrl(url))
			{
				var av = new UIAlertView("Not supported",
										"Scheme 'tel:' is not supported on this device",
										null,
										"OK",
										 null);
				av.Show();
			}
		}
	}
}
