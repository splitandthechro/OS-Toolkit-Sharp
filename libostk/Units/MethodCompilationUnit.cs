using System;
using Mono.Cecil;

namespace libostk {

	/// <summary>
	/// Method compilation unit.
	/// </summary>
	public class MethodCompilationUnit : ICompilationUnit {

		/// <summary>
		/// The label.
		/// </summary>
		readonly public MethodLabel Label;

		/// <summary>
		/// Initializes a new instance of the <see cref="libostk.MethodCompilationUnit"/> class.
		/// </summary>
		/// <param name="def">Def.</param>
		public MethodCompilationUnit (MethodDefinition def) {
			Label = new MethodLabel (def);
		}

		/// <summary>
		/// Compiles this unit using the specified assembly writer.
		/// </summary>
		/// <param name="writer">Writer.</param>
		public void Compile (AssemblyWriter writer) {
		}
	}
}

