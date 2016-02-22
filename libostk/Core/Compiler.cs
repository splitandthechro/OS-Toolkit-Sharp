using System;

namespace libostk {
	
	public class Compiler {

		AssemblyWriter Writer;
		SourceAssembly Source;

		// Compilation passes
		readonly StructuringPass Pass1;

		/// <summary>
		/// Initializes a new instance of the <see cref="libostk.Compiler"/> class.
		/// </summary>
		public Compiler () {
			Writer = new AssemblyWriter ();
			Pass1 = new StructuringPass ();
		}

		/// <summary>
		/// Adds an assembly as a <see cref="SourceAssembly"/>.
		/// </summary>
		/// <param name="fileName">File name.</param>
		public void LoadAssembly (string fileName) {
			var unit = SourceAssembly.ReadFrom (fileName);
			Source = unit;
		}

		/// <summary>
		/// Compiles all source units.
		/// </summary>
		public void Compile () {

			// Check if a source assembly was provided
			if (Source == null) {
				Console.WriteLine ("Please load a source assembly");
				return;
			}

			// Run the compiler passes
			var structure = Pass1.Compile (data: Source);
		}
	}
}

