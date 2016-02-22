using System;
using Mono.Cecil;

namespace libostk {
	
	public class Label<TDefinition>
		where TDefinition: IMetadataTokenProvider {

		protected bool local;
		public bool Local { get { return local; } }

		protected string name;
		public string Name { get { return name; } }

		readonly public TDefinition Definition;

		public Label (TDefinition def) {
			Definition = def;
			name = string.Empty;
			local = false;
		}

		public override string ToString () {
			return !Local ? Name.ToLabel () : string.Format (".{0}", Name.ToLabel ());
		}
	}
}

