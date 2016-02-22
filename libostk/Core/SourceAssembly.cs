using System;
using System.Collections.Generic;
using Mono.Cecil;

namespace libostk {
	
	public class SourceAssembly {

		public AssemblyDefinition Assembly;

		public string FriendlyName {
			get { return Assembly.Name.Name; }
		}

		public IList<ModuleDefinition> Modules {
			get { return Assembly.Modules; }
		}
		
		public SourceAssembly (AssemblyDefinition assembly) {
			Assembly = assembly;
		}

		public static SourceAssembly ReadFrom (string fileName) {
			var assembly = AssemblyDefinition.ReadAssembly (fileName);
			return new SourceAssembly (assembly);
		}
	}
}

