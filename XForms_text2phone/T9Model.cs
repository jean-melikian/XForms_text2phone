using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace XForms_text2phone {
	class T9Model : INotifyPropertyChanged {
		public const int PHONE_NUMBER_LENGTH = 9;

		// See this regex thread: http://stackoverflow.com/questions/7351031/regex-replace-multiple-groups
		public IDictionary<string, string> regexMap = new Dictionary<string, string>()
		{
			{"a", "2"},{"b", "2"},{"c", "2"},{"d", "3"},{"e", "3"},{"f", "3"},{"g", "4"},{"h", "4"},{"i", "4"},
			{"j", "5"},{"k", "5"},{"l", "5"},{"m", "6"},{"n", "6"},{"o", "6"},{"p", "7"},{"q", "7"},{"r", "7"},
			{"s", "7"},{"t", "8"},{"u", "8"},{"v", "8"},{"w", "9"},{"x", "9"},{"y", "9"},{"z", "9"},{" ", "0"},

			//{"^[1,;:=^\\()-_#'\"<>$€çéèùà]$", "1"},
			//{"^[2abc]$", "2"},
			//{"^[3defDEF]$", "3"},
			//{"^[4ghiGHI]$", "4"},
			//{"^[5jklJKL]$", "5"},
			//{"^[6mnoMNO]$", "6"},
			//{"^[7pqrsPQRS]$", "7"},
			//{"^[8tuvTUV]$", "8"},
			//{"^[9wxyzWXYZ]$", "9"},
			//{"^[0 ]$", "0"}
		};

		private String text = "";
		private String number = "";
		private bool isTextValid = false;
		private bool isNumberValid = false;
		private int remainingChars = PHONE_NUMBER_LENGTH;
		private const String remainingCharsLabel = "Saisissez un texte court\n{0:d} caractère(s) restant(s)";
		private Regex regex;

		public event PropertyChangedEventHandler PropertyChanged;

		public T9Model() {
			regex = new Regex(String.Join("|", regexMap.Keys));
			Debug.WriteLine("Regex: " + regex);
		}

		public String Text {
			set {
				if (text != value) {
					if(value.Length <= PHONE_NUMBER_LENGTH) {
						text = value;
						toNumber();
						Debug.WriteLine("Text changed: " + text + "; number: " + number);
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
				return "+33" + number;
			}
		}

		public bool IsTextValid
		{
			get
			{
				ValidateText();
				return isTextValid;
			}
		}

		public bool IsNumberValid
		{
			get
			{
				ValidateNumber();
				return isNumberValid;
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

		private void toNumber() {
			// TODO: Make the conversion and validateNumber
			if (ValidateText()) {
				//Debug.WriteLine("Entering toNumber(). text: " + text + "; number: " + number);
				//number = Regex.Replace(text, @"[a]", "1")
				//              .Replace("[2abcABC]", "2")
				//			  .Replace("[3defDEF]", "3")
				//			  .Replace("[4ghiGHI]", "4")
				//			  .Replace("[5jklJKL]", "5")
				//			  .Replace("[6mnoMNO]", "6")
				//			  .Replace("[7pqrsPQRS]", "7")
				//			  .Replace("[8tuvTUV]", "8")
				//			  .Replace("[9wxyzWXYZ]", "9")
				//			  .Replace("[0 ]", "0");


				number = regex.Replace(text.ToLower(), delegate (Match m) {
					Debug.WriteLine("Match: " +m.Value);
					return regexMap[m.Value];
				});

				//foreach (KeyValuePair<Regex, string> item in regexMap) {
				//	number = item.Key.Replace(text, item.Value);
				//}

				ValidateNumber();

				if (PropertyChanged != null) {
					PropertyChanged(this, new PropertyChangedEventArgs("Number"));
				}
			}

		}

		private bool ValidateText() {
			// TODO: Make the validation and update isTextValid
			return isTextValid = true;
		}

		private bool ValidateNumber() {
			// TODO: Make the validation and update isNumberValid
			isNumberValid = false;

			if (number.Length == PHONE_NUMBER_LENGTH) {
				if (Regex.IsMatch(number, @"^\d{"+PHONE_NUMBER_LENGTH+"}"))
					isNumberValid = true;
			}
			return isNumberValid;
		}
	}
}