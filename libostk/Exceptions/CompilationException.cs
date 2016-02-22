using System;

namespace libostk {
	
	public class CompilationException : Exception {

		protected string message;
		public new string Message { get { return message; } }

		public CompilationException () {
		}

		public CompilationException (string message) {
			this.message = message;
		}
	}
}

