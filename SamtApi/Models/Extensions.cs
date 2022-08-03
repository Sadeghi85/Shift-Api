using System.Globalization;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace SamtApi.Models {
	public static class Extensions {



		public static string CalculateMD5(this string strToEncript) {
			var md5 = MD5.Create();
			var byteuser = System.Text.Encoding.UTF8.GetBytes(strToEncript);
			var hashedvalue = md5.ComputeHash(byteuser);
			return Convert.ToBase64String(hashedvalue);
		}

		public static string CalculateMD5String(this string strToEncript) {
			var md5 = MD5.Create();
			var byteuser = System.Text.Encoding.UTF8.GetBytes(strToEncript);
			var hashedvalue = md5.ComputeHash(byteuser);
			return BitConverter.ToString(hashedvalue).Replace("-", "");
		}


		public static string RandomStringNumber() {
			var r = new Random((int) DateTime.Now.Ticks);
			var pr1 = r.Next(1000, 9999).ToString();
			var pr2 = r.Next(1000, 9999).ToString();
			var prLast = r.Next(1000, 9999).ToString();
			var pr3 = Convert.ToChar(r.Next(65, 90)).ToString();
			var pr4 = Convert.ToChar(r.Next(97, 122)).ToString();
			var pr5 = Convert.ToChar(r.Next(97, 122)).ToString();
			var pr6 = Convert.ToChar(r.Next(65, 90)).ToString();
			return pr4 + pr1 + pr3 + pr6 + pr2 + pr5 + prLast;
		}

		public static int RandomNumber() {
			var rand = new Random((int) DateTime.Now.Ticks);
			return rand.Next(10000000, 999999999);
		}







		public static string GetFriendlyURL(this string instance) {
			var t = instance.Replace("\t", "-").Replace(" ", "-")
				//&zwnj; یا همون نیم فاصله
				.Replace("‌", "-")
				.Replace("(", "").Replace(")", "").Replace("`", "")
				.Replace("/", "").Replace("\\", "").Replace("|", "").Replace("}", "").Replace("'", "")
				.Replace("*", "").Replace("&", "").Replace(")", "").Replace("{", "")
				.Replace("#", "").Replace("!", "").Replace("~", "").Replace("[", "").Replace("]", "")
				.Replace("%", "").Replace("$", "").Replace(".", "").Replace(",", "").Replace("،", "")
				.Replace("»", "").Replace("«", "").Replace("(", "").Replace(")", "")
				.Replace("؟", "").Replace("?", "").Replace(":", "").Replace(";", "").Replace("؛", "")
				.Replace("\"", "").Replace("ء", "").Replace("ئ", "ی").Replace("ؤ", "و")
				.Replace("----", "-").Replace("---", "-").Replace("--", "-").Replace("--", "-")
				.Trim().Trim('-');

			t = t.ReplaceInvalidChars();

			return t.Length <= 200 ? t : t.Substring(0, 199);
		}


		public static Regex invalidCharsFinal = new Regex(@"[^\-\p{Ll}\p{Lu}\p{Lo}\p{Lt}\p{Nd}]", RegexOptions.Compiled | RegexOptions.IgnoreCase);
		public static string ReplaceInvalidChars(this string input) {
			var step1 = invalidCharsFinal.Replace(input, "-");
			return step1.Replace("----", "-").Replace("---", "-").Replace("--", "-").Replace("--", "-").Replace("--", "-").Replace("--", "-");
		}






		public static string GetFarsiText(this string instance) {
			return instance.Replace("ي", "ی").Replace("ك", "ک").Replace("ي", "ی");
		}

		public static string InputEncode(this string st) {
			string temp = st;
			string temp2 = st.ToLower();
			temp2 = temp2.Replace("'", "").Replace("`", "");
			temp2 = temp2.Replace(";", "");
			temp2 = temp2.Replace("#", "");
			temp2 = temp2.Replace("\"", "");
			temp2 = temp2.Replace("%", "");
			temp2 = temp2.Replace("--", "");
			temp2 = temp2.Replace("=", "");
			temp2 = temp2.Replace(" ", "");
			temp2 = temp2.Replace("+", "");
			temp2 = temp2.Replace("(", "");
			temp2 = temp2.Replace(")", "");
			temp2 = temp2.Replace("update ", "");
			temp2 = temp2.Replace("delete ", "");
			temp2 = temp2.Replace("drop ", "");
			temp2 = temp2.Replace("alter ", "");
			temp2 = temp2.Replace("dbo ", " ");
			//st = st.Replace("go", " ");
			//temp2 = temp2.Replace("select", "");
			temp2 = temp2.Replace("update", "");
			temp2 = temp2.Replace("insert", "");
			temp2 = temp2.Replace("delete", "");
			temp2 = temp2.Replace("drop", "");
			//temp2 = temp2.Replace("xp", " ");
			temp2 = temp2.Replace("dbo.", "");
			//st = st.Replace("sa", " ");
			temp2 = temp2.Replace("schema", "");

			if (temp2 == st.ToLower()) {
				return temp;
			}
			return temp2;
		}

		private static bool ObjectIsNumeric(object Obj) {
			bool isNum;
			double retNum;
			isNum = Double.TryParse(Convert.ToString(Obj), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
			return isNum;
		}

		public static bool IsGuid(this string str) {
			bool isGuid = false;
			if (str.IsEmpty() == false) {
				Guid guid = Guid.Empty;
				isGuid = Guid.TryParse(str.Trim(), out guid);
			}
			return isGuid;
		}

		public static bool IsNumeric(this object str) {
			return ObjectIsNumeric(str);
		}

		public static bool IsNumeric(this string str) {
			if (str.IsEmpty()) {
				return false;
			}
			return ObjectIsNumeric(str.Trim());
		}

		public static bool IsInteger(this string str) {
			if (str.IsEmpty()) {
				return false;
			}
			bool isNum;
			int retNum;
			isNum = int.TryParse(Convert.ToString(str), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
			return isNum;
		}

		public static int GetPositiveInteger(this string str) {
			if (str.IsEmpty()) {
				return -1;
			}
			int retNum = -1;
			int.TryParse(Convert.ToString(str), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
			return retNum;
		}

		public static bool IsEmpty(this string str) {
			if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str)) {
				return true;
			}
			return false;
		}

		public static int ToInt32(this string str) {
			if (str.IsEmpty()) {
				throw new ArgumentNullException();
			}
			if (!str.IsNumeric()) {
				throw new InvalidCastException();
			}
			return Convert.ToInt32(str.Trim());
		}


		public static string FixVirtualSpace(this string str) {
			return str.Replace("می ش", "می‌ش").Replace("ی ها", "ی‌ها").Replace("می ک", "می‌ک").Replace("ن ها", "ن‌ها")
				.Replace("می ب", "می‌ب").Replace("می پ", "می‌پ").Replace("می گ", "می‌گ").Replace("ه ها", "ه‌ها");
		}

		public static string ToPersianNumeric(this string str) {
			if (null == str) {
				return "";
			}
			var loopCount = str.Length;
			var result = "";
			for (int i = 0; i < loopCount; i++) {
				if (str[i] >= 48 && str[i] <= 57) {
					if (str[i] == 48) {
						result += "۰";
					} else if (str[i] == 49) {
						result += "۱";
					} else if (str[i] == 50) {
						result += "۲";
					} else if (str[i] == 51) {
						result += "۳";
					} else if (str[i] == 52) {
						result += "۴";
					} else if (str[i] == 53) {
						result += "۵";
					} else if (str[i] == 54) {
						result += "۶";
					} else if (str[i] == 55) {
						result += "۷";
					} else if (str[i] == 56) {
						result += "۸";
					} else if (str[i] == 57) {
						result += "۹";
					}
				} else {
					result += str[i];
				}
			}

			return result;
		}


		public static string ToPersianNumeric(this int str) {
			return str.ToString().ToPersianNumeric();
		}


		public static string ToPersianNumeric(this long str) {
			return str.ToString().ToPersianNumeric();
		}



		public static int HexToInt32(this string str) {
			if (str.IsEmpty()) {
				throw new ArgumentNullException();
			}

			bool isNum;
			int retNum;
			isNum = int.TryParse(str, NumberStyles.HexNumber, NumberFormatInfo.InvariantInfo, out retNum);
			if (!isNum)
				throw new ArgumentNullException();

			return retNum;
		}

		public static string ScrubHtml(this string value) {
			if (null == value) {
				return null;
			}
			value = value.Replace("<p>", "[PPP]").Replace("</p>", "[NNN]").Replace("<br />", "[BR]");
			var step1 = Regex.Replace(value, @"<[^>]+>|&nbsp;", "").Trim();
			var step2 = Regex.Replace(step1, @"\s{2,}", " ");
			return step2.Replace("[PPP]", "<p>").Replace("[NNN]", "</p>").Replace("[BR]", "<br />");
		}

		public static string ScrubHtml(this string value, int maxLength) {
			var result = value.ScrubHtml();
			if (result.Length > maxLength) {
				result = result.Substring(0, maxLength - 1);
			}
			return result;
		}

		public static bool IsValidEmail(this string emailaddress) {
			try {
				var m = new MailAddress(emailaddress);
				return true;
			} catch {
				return false;
			}
		}


		public static bool StringIsNumber(this string checkStr) {
			return Regex.IsMatch(checkStr.Trim(), @"^\d+$");
		}

		public static bool StringContainNumber(this string checkStr) {
			return Regex.IsMatch(checkStr.Trim(), @"^\d+$");
		}

		public static int ToInteger(this TimeSpan time) {
			return int.Parse(time.Hours.ToString() + time.Minutes.ToString().PadLeft(2, '0') + time.Seconds.ToString().PadLeft(2, '0'));
		}

		public static short ToShort(this TimeSpan time) {
			return short.Parse(time.Hours.ToString() + time.Minutes.ToString().PadLeft(2, '0'));
		}

		public static string ToHHMM(this TimeSpan time) {
			return time.ToString("hh\\:mm");
		}

		public static string ToHHMMSS(this TimeSpan time) {
			return time.ToString("hh\\:mm\\:ss");
		}

		public static T ParseEnum<T>(this string value) {
			return (T) Enum.Parse(typeof(T), value, true);
		}

		public static bool StringIsEnglish(this string checkStr, bool space = false) {
			if (space) {
				return Regex.IsMatch(checkStr.Trim(), @"^[a-zA-Z0-9 ]*$");
			} else {
				return Regex.IsMatch(checkStr.Trim(), @"^[a-zA-Z0-9]*$");
			}
		}


		public static string GetFullNameSpace(this Type type) {
			var classFullName = type.FullName;
			var assemblyName = type.Module.Name;
			return classFullName + "," + assemblyName.Replace(".dll", "");
		}

		public static object GetPropValue(this object src, string propName) {
			return src.GetType().GetProperty(propName).GetValue(src);
		}

		public static bool HasProperty(this object src, string propertyName) {
			return src.GetType().GetProperty(propertyName) != null;
		}

		public static void SetPropValue(this object src, string propertyName, object value) {
			var pInfo = src.GetType().GetProperty(propertyName);
			pInfo.SetValue(src, Convert.ChangeType(value, pInfo.PropertyType), null);
		}

		public static Tuple<int, bool> ParseandGetint(this string inputparam) {
			var temp = -1;
			var parseResult = false;
			parseResult = int.TryParse(inputparam, out temp);
			return new Tuple<int, bool>(temp, parseResult);
		}

		public static bool CheckFormatDateFrom(string inDate) {
			var dateshow = inDate.Split('/');
			if (3 != dateshow.Count()) {
				return false;
			} else {
				var testnumber1 = ParseandGetint(dateshow[0]);
				var testnumber2 = ParseandGetint(dateshow[1]);
				var testnumber3 = ParseandGetint(dateshow[2]);
				if (!testnumber1.Item2 || !testnumber2.Item2 || !testnumber3.Item2) {
					return false;
				}
				if (testnumber1.Item1 <= 1000 || testnumber1.Item1 >= 9999) {
					return false;
				}
				if (testnumber2.Item1 < 1 || testnumber2.Item1 > 12) {
					return false;
				}
				if (testnumber3.Item1 < 1 || testnumber3.Item1 > 31) {
					return false;
				}
				return true;
			}
		}

		public static Tuple<long, bool> ParseandGetLong(this string inputparam) {
			long temp = -1;
			var parseResult = false;
			parseResult = long.TryParse(inputparam, out temp);
			return new Tuple<long, bool>(temp, parseResult);
		}

		public static string GetDate10Digit(this DateTime dateTimeVar) {
			var pcal = new PersianCalendar();
			var year = pcal.GetYear(dateTimeVar).ToString(CultureInfo.InvariantCulture);
			var month = pcal.GetMonth(dateTimeVar).ToString(CultureInfo.InvariantCulture);
			var day = pcal.GetDayOfMonth(dateTimeVar).ToString(CultureInfo.InvariantCulture);
			day = day.PadLeft(2, '0');
			month = month.PadLeft(2, '0');
			return year + "/" + month + "/" + day;
		}

		//public static bool IsPersianDateTime(this string str) {
		//	PersianDateTime dt;
		//	return PersianDateTime.TryParse(str, out dt);
		//}

		public static bool IsValidIranianNationalCode(this string input) {
			try {
				input = input.PadLeft(10, '0');

				if (!Regex.IsMatch(input, @"^(?!(\d)\1{9})\d{10}$"))
					return false;

				var check = Convert.ToInt32(input.Substring(9, 1));
				var sum = Enumerable.Range(0, 9)
					.Select(x => Convert.ToInt32(input.Substring(x, 1)) * (10 - x))
					.Sum() % 11;

				return sum < 2 && check == sum || sum >= 2 && check + sum == 11;
			} catch {
				return false;
			}
		}


		public static bool IsValidIranianLegalCode(this string input) {
			try {
				//input has 11 digits that all of them are not equal
				if (!Regex.IsMatch(input, @"^(?!(\d)\1{10})\d{11}$"))
					return false;

				var check = Convert.ToInt32(input.Substring(10, 1));
				int dec = Convert.ToInt32(input.Substring(9, 1)) + 2;
				int[] Coef = new int[10] { 29, 27, 23, 19, 17, 29, 27, 23, 19, 17 };

				var sum = Enumerable.Range(0, 10)
							  .Select(x => (Convert.ToInt32(input.Substring(x, 1)) + dec) * Coef[x])
							  .Sum() % 11;

				return sum == check;


			} catch {
				return false;
			}
		}


		public static bool IsValidUrlAddress(this string urladdress) {
			try {
				var m = new Uri(urladdress);
				return true;
			} catch {
				return false;
			}
		}



	}
}

