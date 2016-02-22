using System;
using System.Linq;
using System.Text;
using Mono.Cecil;

namespace libostk {
	
	public static class StringExtensions {

		const string LOWERCASE	= "abcdefghijklmnopqrstuvwxyz";
		const string UPPERCASE	= "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		const string NUMBERS	= "0123456789";
		const string ALLOWED	= LOWERCASE + UPPERCASE + NUMBERS;

		public static string ToLabel (this string str) {
			var accum = new StringBuilder ();
			foreach (var chr in str)
				accum.Append (ALLOWED.Contains (chr) ? chr : '_');
			return accum.ToString ();
		}
	}
}

