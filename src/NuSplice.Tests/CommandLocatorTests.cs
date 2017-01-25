using System;
using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace NuSplice.Tests
{
	public class CommandLocatorTests
	{
		private IEnumerable<Type> ForTypes(params Type[] types) => new CommandLocator(types).Execute();

		[Fact]
		public void When_scanning_against_no_types()
		{
			ForTypes().ShouldBeEmpty();
		}

		[Fact]
		public void When_scanning_types_and_none_implement_the_interface()
		{
			ForTypes(typeof(object)).ShouldBeEmpty();
		}

		[Fact]
		public void When_scanning_and_one_type_implements_the_interface()
		{
			ForTypes(typeof(ImplementsConstructable)).ShouldBe(new[] { typeof(ImplementsConstructable) });
		}

		[Fact]
		public void When_one_type_implements_the_interface_but_has_no_ctor()
		{
			ForTypes(typeof(ImplementsNonConstructable)).ShouldBeEmpty();
		}

		[Fact]
		public void When_one_type_implements_the_interface_but_is_abstract()
		{
			ForTypes(typeof(ImplementsAbstract)).ShouldBeEmpty();
		}

		private class ImplementsConstructable : Command
		{
			public override void Execute(CommandModel model)
			{
				throw new NotImplementedException();
			}
		}

		private class ImplementsNonConstructable : Command
		{
			private ImplementsNonConstructable()
			{
			}

			public override void Execute(CommandModel model)
			{
				throw new NotImplementedException();
			}
		}

		private abstract class ImplementsAbstract : Command
		{
			public override void Execute(CommandModel model)
			{
				throw new NotImplementedException();
			}
		}
	}
}
