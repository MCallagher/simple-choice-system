using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace SimpleChoiceSystem.Test
{
    public class ConsequenceTests
    {
        [Test]
        public void Constructor_CreatesValuesAndOptions()
        {
            var parameters = new Dictionary<string, object>
            {
                { "amount", 10 },
                { "reason", "broken" }
            };

            var consequence = new Consequence(
                "Hit",
                ConsequenceType.Damage,
                ConsequenceTime.Immediate,
                parameters);

            Assert.AreEqual("Hit", consequence.Description);
            Assert.AreEqual(ConsequenceType.Damage, consequence.ConsequenceType);
            Assert.AreEqual(ConsequenceTime.Immediate, consequence.ConsequenceTime);
            Assert.IsTrue(consequence.HasOption("amount"));
            Assert.AreEqual(10, consequence.GetOption<int>("amount"));
            Assert.AreEqual("broken", consequence.GetOption<string>("reason"));
            CollectionAssert.AreEquivalent(new[] { "amount", "reason" }, consequence.GetOptionKeys());
        }

        [Test]
        public void GetOption_ThrowsWhenKeyMissing()
        {
            var consequence = new Consequence(
                "Mysterious",
                ConsequenceType.Nothing,
                ConsequenceTime.LongTerm,
                null);

            Assert.Throws<KeyNotFoundException>(() => consequence.GetOption<int>("missing"));
        }
    }

    public class OptionTests
    {
        [Test]
        public void Constructor_WithConsequences_StoresThem()
        {
            var consequences = new List<Consequence>
            {
                new Consequence(
                    "Heal",
                    ConsequenceType.Heal,
                    ConsequenceTime.ShortTerm,
                    new Dictionary<string, object> { { "amount", 5 } })
            };

            var option = new Option("Take the potion", consequences);

            Assert.AreEqual("Take the potion", option.Description);
            Assert.AreSame(consequences, option.Consequences);
            Assert.AreEqual(1, option.Consequences.Count);
            Assert.AreEqual(ConsequenceType.Heal, option.Consequences[0].ConsequenceType);
        }
    }

    public class ChoiceTests
    {
        [Test]
        public void Choose_ReturnsCorrectOption()
        {
            var optionA = new Option("A", new List<Consequence>());
            var optionB = new Option("B", new List<Consequence>());
            var choice = new Choice("Room 1", new List<Option> { optionA, optionB });

            Assert.AreEqual("Room 1", choice.Context);
            Assert.AreEqual(2, choice.Options.Count);
            Assert.AreSame(optionB, choice.Choose(1));
        }

        [Test]
        public void Choose_ThrowsWhenChosenMultipleTimes()
        {
            var optionA = new Option("A", new List<Consequence>());
            var optionB = new Option("B", new List<Consequence>());
            var choice = new Choice("Room 1", new List<Option> { optionA, optionB });

            choice.Choose(0);

            Assert.Throws<InvalidOperationException>(() => choice.Choose(1));
            Assert.AreSame(optionA, choice.Decision);
        }

        [Test]
        public void Choose_ThrowsOnInvalidIndex()
        {
            var choice = new Choice("Room 2", new List<Option>());

            Assert.Throws<IndexOutOfRangeException>(() => choice.Choose(0));
            Assert.Throws<IndexOutOfRangeException>(() => choice.Choose(-1));
        }

        [Test]
        public void GetOptionDescriptions_ReturnsAllOptions()
        {
            var choice = new Choice("Test", new List<Option>
            {
                new Option("First", new List<Consequence>()),
                new Option("Second", new List<Consequence>())
            });

            CollectionAssert.AreEqual(new[] { "First", "Second" }, choice.GetOptionDescriptions());
        }
    }
}
