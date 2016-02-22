using System;

namespace libostk {
	
	public class GeneratingPass
		: ICompilationPass<ICompilationUnit, AssemblyBuilder> {

		public GeneratingPass () {
		}

		public AssemblyBuilder Compile (ICompilationUnit data) {
			var builder = new AssemblyBuilder ();
			data.Compile (builder);
			return builder;
		}
	}
}

