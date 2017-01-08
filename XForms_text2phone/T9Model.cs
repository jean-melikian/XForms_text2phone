using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace XForms_text2phone {
	class T9Model : INotifyPropertyChanged {
		public const int PHONE_NUMBER_LENGTH = 9;
		
		private String text = "";
		private String number = "";
		private bool isValid = false;
		//private String remainingCharsLabel = "Saisissez un texte court(%d caractères max)";

		public event PropertyChangedEventHandler PropertyChanged;

		public T9Model() { }

		public String Text {
			set {
				if (text != value) {
					if(value.Length <= PHONE_NUMBER_LENGTH) {
						text = value;
						TextToNumber();
					}
					if (PropertyChanged != null) {
						PropertyChanged(this, new PropertyChangedEventArgs("Text"));
					}
				}
			}
			get {
				return text;
			}
		}

		public String Number {
			get {
				return number;
			}
		}

		public bool IsValid {
			get {
				return isValid;
			}
		}

		private void TextToNumber() {
			// TODO: Make the conversion and validateNumber
			number = text;
			validateNumber();
			if (PropertyChanged != null) {
				PropertyChanged(this, new PropertyChangedEventArgs("Number"));
			}
		}

		private void validateNumber() {
			// TODO: Make the validation and update isValid
			if (text != "") {
				if (text.Length == T9Model.PHONE_NUMBER_LENGTH) {
					isValid = true;
				}
			}
			isValid = false;
		}
	}
}