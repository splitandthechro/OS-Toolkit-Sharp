using System;
using Mono.Cecil;

namespace libostk {
	public class UnsupportedArchitectureException : CompilationException {
		
		public UnsupportedArchitectureException (ModuleDefinition module) {
			var arch = module.Architecture.ToString ().ToLowerInvariant ();
			message = string.Format ("Unsupported architecture: {0} (in {1})", module.Architecture, module.Name);
		}
	}
}

