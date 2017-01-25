using System;
using System.Linq;

namespace NuSplice
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			var locator = new CommandLocator();
			var commands = locator.Execute();

			var type = commands.First(t => t.Name.StartsWith(args[0]));
			var command = (Command)type.GetConstructor(Type.EmptyTypes).Invoke(new object[0]);

			command.Execute(new CommandModel
			{
				Args = args.Skip(1).ToArray()
			});
		}
	}
}
