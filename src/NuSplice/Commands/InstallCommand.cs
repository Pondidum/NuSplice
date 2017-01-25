namespace NuSplice.Commands
{
	public class InstallCommand : Command
	{
		public InstallCommand()
		{
			Register<InstallArgumentsParsed>(Handle);
		}

		public override void Execute(CommandModel model)
		{
			throw new System.NotImplementedException();
		}

		private void Handle(InstallArgumentsParsed e)
		{
			//?
		}
	}

	public class InstallArgumentsParsed : IEvent
	{
		public InstallOptions Options { get; }

		public InstallArgumentsParsed(InstallOptions options)
		{
			Options = options;
		}
	}

	public class InstallOptions
	{
		[Option("name", Required = true)]
		public string PackageName { get; set; }

		[Option("version", Required = true)]
		public string PackageVersion { get; set; }
	}
}
