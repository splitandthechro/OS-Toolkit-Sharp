using System;
using Mono.Cecil;

namespace libostk {
	
	public class ClassLabel : Label<TypeDefinition> {
		
		public ClassLabel (TypeDefinition def) : base (def) {
			Name = def.FullName;
			InternalFullName = def.FullName;
		}
	}
}

