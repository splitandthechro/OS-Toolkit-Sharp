using System;

namespace libostk {
	
	public interface ICompilationPass<in TData, out TResult> {

		TResult Compile (TData data);
	}
}

