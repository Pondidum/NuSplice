namespace NuSplice
{
	public interface ICommand
	{
		void Execute(CommandModel model);
	}

	public class CommandModel
	{
		public string[] Args { get; set; }
	}
}
