using System;
using Mono.Cecil;

namespace libostk {

	public abstract class Label {

		internal string InternalFullName;
		internal string InternalFriendlyName;
		internal string InternalLabelName;
	}
	
	public class Label<TDefinition> : Label
		where TDefinition : IMetadataTokenProvider {
	
		public bool Local { get; protected set; }

		protected string name;
		public string Name {
			get { return name; }
			protected set {
				name = value;
				InternalFriendlyName = value;
				InternalLabelName = GetRealLabel (value);
			}
		}

		readonly public TDefinition Definition;

		public Label (TDefinition def) {
			InternalFullName = string.Empty;
			Definition = def;
			Name = string.Empty;
			Local = false;
		}

		string GetRealLabel (string str) {
			return !Local ? str.ToLabel () : string.Format (".{0}", str.ToLabel ());
		}

		public override string ToString () {
			return InternalLabelName;
		}
	}
}

