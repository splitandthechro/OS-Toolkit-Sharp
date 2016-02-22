using System;

namespace libostk {

	/// <summary>
	/// Multiboot flags.
	/// </summary>
	[Flags]
	public enum MultibootFlags {

		/// <summary>
		/// Align all boot modules on i386 page (4KB) boundaries.
		/// </summary>
		MB_PAGE_ALIGN	= 1 << 0,

		/// <summary>
		/// Pass memory info to OS.
		/// </summary>
		MB_MEMORY_INFO	= 1 << 1,

		/// <summary>
		/// Pass video info to OS.
		/// </summary>
		MB_VIDEO_MODE	= 1 << 2,

		/// <summary>
		/// Use address fields in header.
		/// </summary>
		MB_AOUT_KLUDGE	= 1 << 16,
	}
}

