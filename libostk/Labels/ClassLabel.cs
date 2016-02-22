using System;
using Mono.Cecil;

namespace libostk {
	
	public class ClassLabel : Label<TypeDefinition> {
		
		public ClassLabel (TypeDefinition def) : base (def) {
			name = def.FullName;
			local = false;
		}
	}
}

