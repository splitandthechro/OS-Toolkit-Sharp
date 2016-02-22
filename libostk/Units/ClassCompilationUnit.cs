using System;
using System.Collections.Generic;
using Mono.Cecil;

namespace libostk {

	/// <summary>
	/// Class compilation unit.
	/// </summary>
	public class ClassCompilationUnit : ICompilationUnit {

		/// <summary>
		/// The label.
		/// </summary>
		readonly public ClassLabel Label;

		/// <summary>
		/// The methods.
		/// </summary>
		public List<MethodCompilationUnit> Methods;

		/// <summary>
		/// Initializes a new instance of the <see cref="libostk.ClassCompilationUnit"/> class.
		/// </summary>
		ClassCompilationUnit () {
			Methods = new List<MethodCompilationUnit> ();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="libostk.ClassCompilationUnit"/> class.
		/// </summary>
		/// <param name="def">Def.</param>
		public ClassCompilationUnit (TypeDefinition def) : this () {

			// Create label
			Label = new ClassLabel (def);

			// Add class methods
			if (def.HasMethods)
				foreach (var method in def.Methods)
					AddMethod (method);
		}

		/// <summary>
		/// Adds a class method.
		/// </summary>
		/// <param name="method">Method.</param>
		public void AddMethod (MethodDefinition method) {
			var unit = new MethodCompilationUnit (method);
			AddMethod (unit);
		}

		/// <summary>
		/// Adds a class method.
		/// </summary>
		/// <param name="method">Method.</param>
		public void AddMethod (MethodCompilationUnit method) {
			if (!Methods.Contains (method))
				Methods.Add (method);
		}

		/// <summary>
		/// Compiles this unit using the specified assembly writer.
		/// </summary>
		/// <param name="writer">Writer.</param>
		public void Compile (AssemblyBuilder writer) {

			// Create label
			writer.WriteLabel (Label);

			// TODO: Create constants
			// TODO: Create string constants

			// Compile the methods
			foreach (var method in Methods)
				method.Compile (writer);
		}
	}
}

