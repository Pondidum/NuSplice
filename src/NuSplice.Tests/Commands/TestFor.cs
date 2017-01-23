namespace NuSplice.Tests.Commands
{
	public abstract class TestFor<TCommand> where TCommand : ICommand, new()
	{
		public TCommand Command { get; private set; }

		protected TestFor()
		{
			Command = new TCommand();
		}
	}
}
