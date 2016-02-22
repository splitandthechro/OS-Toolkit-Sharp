using System;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace libostk {
	
	public class StructuringPass
		: ICompilationPass<SourceAssembly, ICompilationUnit> {

		readonly MassCompilationUnit MassUnit;

		public StructuringPass () {
			MassUnit = new MassCompilationUnit ();
		}

		public ICompilationUnit Compile (SourceAssembly data) {

			// Read the assembly
			ReadAssembly (data);

			// Return the mass compilation unit
			return MassUnit;
		}

		void ReadAssembly (SourceAssembly unit) {
			
			// Read all modules
			foreach (var module in unit.Modules)
				ReadModule (module);
		}

		void ReadModule (ModuleDefinition module) {
			
			var name = module.Name.Split ('.').First ();
			Console.WriteLine ("Reading library: {0}", name);

			// Check if the module is a library
			if (module.Kind != ModuleKind.Dll)
				throw new UnsupportedModuleException (module);

			// Check if the module is a x86 (i386) library
			if (module.Architecture != TargetArchitecture.I386)
				throw new UnsupportedArchitectureException (module);

			// Read all types (classes, structs, etc)
			foreach (var type in module.GetTypes ())
				ReadType (type);
		}

		void ReadType (TypeDefinition typedef) {

			// Check if the type makes use of generic parameters
			if (typedef.ContainsGenericParameter || typedef.HasGenericParameters)
				throw new UnsupportedFeatureException ("Generics", typedef.FullName);

			// No need to read <Module>
			if (typedef.Name == "<Module>")
				return;

			// Read the type if it is a class
			if (typedef.IsClass)
				ReadClass (typedef);
		}

		void ReadClass (TypeDefinition typedef) {

			Console.WriteLine ("Reading class: {0}", typedef.Name);

			// Add the class to the mass compilation unit
			var unit = new ClassCompilationUnit (typedef);
			MassUnit.AddUnit (unit);
		}
	}
}

