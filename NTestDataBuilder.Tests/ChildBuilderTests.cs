using System;
using Shouldly;
using Xunit;

namespace NTestDataBuilder.Tests
{
    public class ChildBuilderTests
    {
        [Fact]
        public void WhenNotUsingChildBuilder_ThenTheAnonymousValueFixtureIsNotReused()
        {
            var parent = new ParentBuilder().Build();

            parent.ParentEnum.ShouldBe(parent.Child.ChildEnum);
        }

        [Fact]
        public void WhenUsingChildBuilder_ThenTheAnonymousValueFixtureIsReused()
        {
            var parent = new ParentBuilder().WithChildBuilder().Build();

            parent.ParentEnum.ShouldNotBe(parent.Child.ChildEnum);
        }

        [Fact]
        public void WhenUsingChildBuilderIncludingModifier_ThenTheModifierGetsApplied()
        {
            const int number = 2;
            var parent = new ParentBuilder()
                .WithChildBuilder(b => b.WithANumber(number))
                .Build();

            parent.Child.Number.ShouldBe(number);
        }
    }

    public enum AnEnum
    {
        One,
        Two
    }

    public class ParentObject
    {
        public ParentObject(AnEnum parentEnum, ChildObject child)
        {
            ParentEnum = parentEnum;
            Child = child;
        }

        public AnEnum ParentEnum { get; private set; }
        public ChildObject Child { get; private set; }
    }

    public class ChildObject
    {
        public ChildObject(AnEnum childEnum, int number)
        {
            ChildEnum = childEnum;
            Number = number;
        }

        public AnEnum ChildEnum { get; private set; }
        public int Number { get; private set; }
    }

    public class ParentBuilder : TestDataBuilder<ParentObject, ParentBuilder>
    {
        public ParentBuilder()
        {
            Set(x => x.Child, new ChildBuilder().Build());
        }

        public ParentBuilder WithChildBuilder(Func<ChildBuilder, ChildBuilder> modifier = null)
        {
            return Set(x => x.Child, GetChildBuilder<ChildObject, ChildBuilder>(modifier).Build());
        }

        protected override ParentObject BuildObject()
        {
            return new ParentObject(Get(x => x.ParentEnum), Get(x => x.Child));
        }
    }

    public class ChildBuilder : TestDataBuilder<ChildObject, ChildBuilder>
    {
        public ChildBuilder()
        {
            WithANumber(1);
        }

        public ChildBuilder WithANumber(int number)
        {
            return Set(x => x.Number, number);
        }

        protected override ChildObject BuildObject()
        {
            return new ChildObject(Get(x => x.ChildEnum), Get(x => x.Number));
        }
    }
}
