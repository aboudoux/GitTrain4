using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GitTrain4
{
	public static class AssemblyExtentions {
		public static IEnumerable<Type> GetAllConcretTypeThatImplementInterface<TInterface>(this Assembly assembly) {
			Type[] allConcretTypes;
			try {
				allConcretTypes = assembly.GetTypes();
			}
			catch (ReflectionTypeLoadException ex) {
				allConcretTypes = ex.Types.Where(a => a != null).ToArray();
			}

			return allConcretTypes.Where(a => a.GetInterface(typeof(TInterface).Name) != null && a.IsClass && !a.IsAbstract);
		}

		public static void RunModules(this Assembly assembly)
		{
			if (assembly == null) throw new ArgumentNullException(nameof(assembly));

			assembly.GetAllConcretTypeThatImplementInterface<IModule>()
				.Select(type => (type, type.GetInterfaces().FirstOrDefault(i => i.GetInterface(typeof(IModule).Name) != null)))
				.Select(t => Activator.CreateInstance(t.type) as IModule)
				.ToList()
				.ForEach(e=>e.Run());
		}
	}
}