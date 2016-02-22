using System;

namespace libostk {
	
	public partial class AssemblyBuilder {

		// TODO: Add video mode
		const string MULTIBOOT_CONSTANTS = @"
		; Multiboot constants
		MB_ALIGN	equ 1<<0
		MB_MEMINFO	equ 1<<1
		MB_FLAGS	equ MB_ALIGN | MB_MEMINFO
		MB_MAGIC	equ 0x1BADB002
		MB_CHECKSUM	equ -(MB_MAGIC + MB_FLAGS)
		";

		// TODO: Add video mode
		const string MULTIBOOT_SECTION = @"
		; Multiboot section
		section .multiboot
		align 4
		    dd MB_MAGIC
		    dd MB_FLAGS
		    dd MB_CHECKSUM
		";

		const string STACK_SECTION = @"
		; Bootstrap stack section
		section .bootstrap_stack, nobits
		align 4
		    stack_bottom:
		    resb 16384
		    stack_top:
		";

		const string TEXT_SECTION_TEMPLATE = @"
		; Text section
		section .text
		global _start
		_start:
		    mov esp, stack_top
		    {0}
		    cli
		.hang:
		    hlt
		    jmp .hang
		";
	}
}

