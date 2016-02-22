using System;
using Mono.Cecil;
using System.Linq;

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
		public void Compile (AssemblyBuilder writer) {

			// Create label
			writer.WriteLabel (Label);

			// Just for convenience
			var def = Label.Definition;

			// Check if the method has custom attributes
			if (def.HasCustomAttributes) {

				// Try to get entry point attribute
				var attrib = def.CustomAttributes
					.FirstOrDefault (a => a.AttributeType.FullName == typeof(EntryPoint).FullName);

				// Set entry point if needed
				if (attrib != default (CustomAttribute))
					writer.SetEntryPoint (this);
			}

			// TODO: Compile IL code
		}
	}
}

