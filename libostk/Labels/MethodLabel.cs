using System;
using Mono.Cecil;

namespace libostk {
	
	public class MethodLabel : Label<MethodDefinition> {
		
		public MethodLabel (MethodDefinition def) : base (def) {
			name = def.Name;
			local = true;
		}
	}
}

