using System.Collections.Generic;
using System.Linq;

namespace NuSplice.Tests.Commands
{
	public abstract class TestFor<TCommand> where TCommand : Command, new()
	{
		public TCommand Command { get; private set; }

		protected TestFor()
		{
			Command = new TCommand();
		}

		protected IEnumerable<IEvent> Events => Command.GetPendingEvents();
		protected IEvent SingleEvent => Command.GetPendingEvents().Single();

		protected void Execute(params string[] args)
		{
			Command.Execute(new CommandModel
			{
				Args = args
			});
		}
	}
}
