using System;

namespace libostk {
	public class UnsupportedFeatureException : CompilationException {
		
		public UnsupportedFeatureException (string feature) {
			base.message = string.Format ("Unsupported feature: {0}", feature);
		}

		public UnsupportedFeatureException (string feature, string context) {
			message = string.Format ("Unsupported feature: {0} (in '{1}')", feature, context);
		}
	}
}

