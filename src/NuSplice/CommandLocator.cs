using System;
using System.Collections.Generic;
using System.Linq;

namespace NuSplice
{
	public class CommandLocator
	{
		private readonly Type[] _types;

		public CommandLocator()
			: this(typeof(Command).Assembly.GetTypes())
		{
		}

		public CommandLocator(Type[] types)
		{
			_types = types;
		}

		public IEnumerable<Type> Execute()
		{
			var commandBase = typeof(Command);

			return _types
				.Where(t => t.IsClass && t.IsAbstract == false && commandBase.IsAssignableFrom(t))
				.Where(t => t.GetConstructor(Type.EmptyTypes) != null);
		}
	}
}
