using System;
using System.Collections.Generic;

namespace libostk {
	
	public class MassCompilationUnit : ICompilationUnit {

		readonly public List<ICompilationUnit> Units;

		public MassCompilationUnit () {
			Units = new List<ICompilationUnit> ();
		}

		public void AddUnit (ICompilationUnit unit) {
			if (!Units.Contains (unit))
				Units.Add (unit);
		}

		#region ICompilationUnit implementation

		public void Compile (AssemblyBuilder writer) {
			foreach (var unit in Units)
				unit.Compile (writer);
		}

		#endregion
	}
}

