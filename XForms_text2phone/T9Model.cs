using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace XForms_text2phone {
	class T9Model : INotifyPropertyChanged {
		public const int PHONE_NUMBER_LENGTH = 9;

		private String text = "";
		private String number = "";
		private bool isValid = false;
		private int remainingChars = PHONE_NUMBER_LENGTH;
		private const String remainingCharsLabel = "Saisissez un texte court\n{0:d} caractère(s) restant(s)";

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
					UpdateRemainingChars();
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


		public int RemainingChars {
			get {
				return remainingChars;
			}
		}

		public String RemainingCharsLabel {
			get {
				return String.Format(remainingCharsLabel, remainingChars);
			}
		}

		private void UpdateRemainingChars() {
			remainingChars = PHONE_NUMBER_LENGTH - text.Length;
			if (PropertyChanged != null) {
				PropertyChanged(this, new PropertyChangedEventArgs("RemainingCharsLabel"));
			}
		}

		private void TextToNumber() {
			// TODO: Make the conversion and validateNumber
			number = text;
			ValidateNumber();
			if (PropertyChanged != null) {
				PropertyChanged(this, new PropertyChangedEventArgs("Number"));
			}
		}

		private void ValidateNumber() {
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