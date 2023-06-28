// Copyright 2012-2013, 2015 Xamarin Inc. All rights reserved.

using System;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Linker;
using Mono.Linker.Steps;

using Xamarin.Tuner;

namespace Xamarin.Linker {

	// MobileMarkStep process a bit more data and that can be used to sweep
	// more metadata afterward. OTOH sweeping them without the extra marking
	// would produce invalid assemblies
	public class MobileSweepStep : SweepStep {

		public MobileSweepStep (bool sweepSymbols)
			: base (sweepSymbols)
		{
		}

		public AssemblyAction CurrentAction { get; private set; }

		protected override void Process ()
		{
			base.Process ();

			var assemblies = Context.GetAssemblies ();
			foreach (var assembly in assemblies) {
				CurrentAction = Annotations.GetAction (assembly);
				switch (CurrentAction) {
				case AssemblyAction.Link:
				case AssemblyAction.Save:
					SweepAssemblyDefinition (assembly);
					break;
				}
			}
		}

		protected virtual void SweepAssemblyDefinition (AssemblyDefinition assembly)
		{
			var main = assembly.MainModule;
			// only when linking should we remove module references, if we (re)save the assembly then
			// the entrypoints (for p/invokes) will be required later
			// reference: https://bugzilla.xamarin.com/show_bug.cgi?id=35372
			if (main.HasModuleReferences && (CurrentAction == AssemblyAction.Link))
				SweepCollectionMetadata (main.ModuleReferences);
		}
	}
}
