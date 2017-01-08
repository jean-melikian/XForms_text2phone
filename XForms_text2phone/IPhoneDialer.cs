// Documentation: https://developer.xamarin.com/guides/xamarin-forms/dependency-service/introduction/

using System;
namespace XForms_text2phone
{
	public interface IPhoneDialer
	{
		void DialNumber(string phoneNumber);
	}
}
