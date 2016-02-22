using System;
using System.Text;

namespace libostk {
	
	public partial class AssemblyBuilder {

		readonly StringBuilder Code;
		string EntryPoint;

		public AssemblyBuilder () {
			Code = new StringBuilder ();
		}

		public void SetEntryPoint (MethodCompilationUnit method) {
			var parent = method.Label.Definition.DeclaringType.FullName.ToLabel ();
			var node = method.Label.Definition.Name.ToLabel ();
			EntryPoint = string.Format ("{0}.{1}", parent, node);
		}

		public void WriteLabel (Label label) {
			WriteComment (label.InternalFullName);
			WriteLine ("{0}:", label.InternalLabelName);
		}

		public void WriteComment (string format, params object[] args) {
			WriteLine ("; {0}", string.Format (format, args));
		}

		public void WriteLine (string format, params object[] args) {
			Code.AppendFormat ("{0}\n", string.Format (format, args));
		}

		public string GetFinalCode () {

			// Check if the entry point was set
			if (string.IsNullOrEmpty (EntryPoint))
				throw new EntryPointNotFoundException ();
			
			var accum = new StringBuilder ();
			accum.AppendLine (FormatConstant (MULTIBOOT_CONSTANTS));
			accum.AppendLine (FormatConstant (MULTIBOOT_SECTION));
			accum.AppendLine (FormatConstant (STACK_SECTION));
			var text = FormatConstant (TEXT_SECTION_TEMPLATE);
			text = string.Format (text, string.Format ("call {0}", EntryPoint));
			accum.AppendLine (FormatConstant (text));
			accum.AppendLine (FormatConstant (Code.ToString ()));
			return accum.ToString ().Replace ("\t", "".PadLeft (4, ' ')).Trim ();
		}

		static string FormatConstant (string constant) {
			var parts = constant.Replace ("\r", "").Split ('\n');
			for (var i = 0; i < parts.Length; i++)
				parts [i] = parts [i].TrimStart ('\t');
			var joined = string.Join ("\n", parts).Trim ('\n', ' ');
			return string.Format ("{0}\n", joined);
		}
	}
}

