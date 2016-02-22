using System;
using System.Linq;
using libostk;

namespace osc {
	class MainClass {
		
		public static void Main (string[] args) {

			// Check arguments
			if (args.Length == 0) {
				Console.WriteLine ("Usage: osc <kernel>");
				return;
			}

			// Read filename
			var fileName = args.First ();

			// Create compiler
			var compiler = new Compiler ();
			compiler.LoadAssembly (fileName);
			compiler.Compile ();
		}
	}
}
