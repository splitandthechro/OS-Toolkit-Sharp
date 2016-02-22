using System;
using Mono.Cecil;

namespace libostk {
	
	public class MethodLabel : Label<MethodDefinition> {
		
		public MethodLabel (MethodDefinition def) : base (def) {
			Local = true;
			Name = def.FullName;
			InternalFullName = def.FullName;
		}
	}
}

