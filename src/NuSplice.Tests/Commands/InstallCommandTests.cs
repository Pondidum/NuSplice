using NuSplice.Commands;
using Shouldly;
using Xunit;

namespace NuSplice.Tests.Commands
{
	public class InstallCommandTests : TestFor<InstallCommand>
	{
		private const string PackageName = "Shouldly";
		private const string PackageVersion = "12.5.4";

		[Fact]
		public void When_no_arguments_are_specified()
		{
			Execute();

			Events.ShouldBeEmpty();
		}

		[Fact]
		public void When_only_the_name_is_explicitly_specified()
		{
			Execute("-name", PackageName);

			var e = SingleEvent<InstallArgumentsParsed>();

			e.ShouldSatisfyAllConditions(
				() => e.Options.PackageName.ShouldBe(PackageName),
				() => e.Options.PackageVersion.ShouldBeNull()
			);
		}

		[Fact]
		public void When_only_the_version_is_explicitly_specified()
		{
			Execute("-version", PackageVersion);

			Events.ShouldBeEmpty();
		}

		[Fact]
		public void When_both_arguments_are_explicitly_specified()
		{
			Execute("-name", PackageName, "-version", PackageVersion);

			var e = SingleEvent<InstallArgumentsParsed>();

			e.ShouldSatisfyAllConditions(
				() => e.Options.PackageName.ShouldBe(PackageName),
				() => e.Options.PackageVersion.ShouldBe(PackageVersion)
			);
		}

		[Fact]
		public void When_both_arguments_are_implicitly_specified()
		{
			Execute(PackageName, PackageVersion);

			var e = SingleEvent<InstallArgumentsParsed>();

			e.ShouldSatisfyAllConditions(
				() => e.Options.PackageName.ShouldBe(PackageName),
				() => e.Options.PackageVersion.ShouldBe(PackageVersion)
			);
		}
	}
}
