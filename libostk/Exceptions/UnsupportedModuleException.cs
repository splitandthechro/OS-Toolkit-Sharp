using System;
using Mono.Cecil;

namespace libostk {
	public class UnsupportedModuleException : CompilationException {
		
		public UnsupportedModuleException (ModuleDefinition module) {
			var kind = module.Kind.ToString ().ToLowerInvariant ();
			message = string.Format ("Unsupported assembly type: {0} (in {1})", kind, module.Name);
		}
	}
}

