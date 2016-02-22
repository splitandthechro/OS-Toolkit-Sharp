using System;

namespace libostk {

	/// <summary>
	/// Compilation unit interface.
	/// </summary>
	public interface ICompilationUnit {

		/// <summary>
		/// Compiles this unit using the specified assembly writer.
		/// </summary>
		/// <param name="writer">Writer.</param>
		void Compile (AssemblyWriter writer);
	}
}

