using System;
using System.Linq;

namespace NuSplice
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			var commandInterface = typeof(ICommand);
			var commands = commandInterface
				.Assembly
				.GetTypes()
				.Where(t => t.IsClass && t.IsAbstract == false && commandInterface.IsAssignableFrom(t))
				.Where(t => t.GetConstructor(Type.EmptyTypes) != null);

			var type = commands.First(t => t.Name.StartsWith(args[0]));

			var command = (ICommand)type.GetConstructor(Type.EmptyTypes).Invoke(new object[0]);

			command.Execute(new CommandModel
			{
				Args = args
			});
		}
	}
}