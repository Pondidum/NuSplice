namespace NuSplice.Tests.Commands
{
	public abstract class TestFor<TCommand> where TCommand : Command, new()
	{
		public TCommand Command { get; private set; }

		protected TestFor()
		{
			Command = new TCommand();
		}
	}
}
