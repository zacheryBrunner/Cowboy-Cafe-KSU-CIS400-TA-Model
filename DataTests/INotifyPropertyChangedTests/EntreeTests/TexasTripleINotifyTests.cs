using Xunit;
using CowboyCafe.Data.Entrees;
using System.ComponentModel;

namespace CowboyCafe.DataTests.INotifyPropertyChangedTests.EntreeTests
{
    public class TexasTripleINotifyTests
    {
        [Fact]
        public void TexasTripleImplementsINotifyPropertyChanged()
        {
            var tex = new TexasTripleBurger();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(tex);
        }

        [Fact]
        public void ChangingBunPropertyShouldInvokePropertyChangedForBread()
        {
            var tex = new TexasTripleBurger();
            Assert.PropertyChanged(tex, "Bun", () => {
                tex.Bun = false;
            });
        }

        [Fact]
        public void ChangingKetchupPropertyShouldInvokePropertyChangedForBread()
        {
            var tex = new TexasTripleBurger();
            Assert.PropertyChanged(tex, "Ketchup", () => {
                tex.Ketchup = false;
            });
        }

        [Fact]
        public void ChangingMustardPropertyShouldInvokePropertyChangedForBread()
        {
            var tex = new TexasTripleBurger();
            Assert.PropertyChanged(tex, "Mustard", () => {
                tex.Mustard = false;
            });
        }

        [Fact]
        public void ChangingPicklePropertyShouldInvokePropertyChangedForBread()
        {
            var tex = new TexasTripleBurger();
            Assert.PropertyChanged(tex, "Pickle", () => {
                tex.Pickle = false;
            });
        }

        [Fact]
        public void ChangingCheesePropertyShouldInvokePropertyChangedForBread()
        {
            var tex = new TexasTripleBurger();
            Assert.PropertyChanged(tex, "Cheese", () => {
                tex.Cheese = false;
            });
        }

        [Fact]
        public void ChangingTomatoPropertyShouldInvokePropertyChangedForBread()
        {
            var tex = new TexasTripleBurger();
            Assert.PropertyChanged(tex, "Tomato", () => {
                tex.Tomato = false;
            });
        }

        [Fact]
        public void ChangingLettucePropertyShouldInvokePropertyChangedForBread()
        {
            var tex = new TexasTripleBurger();
            Assert.PropertyChanged(tex, "Lettuce", () => {
                tex.Lettuce = false;
            });
        }

        [Fact]
        public void ChangingMayoPropertyShouldInvokePropertyChangedForBread()
        {
            var tex = new TexasTripleBurger();
            Assert.PropertyChanged(tex, "Mayo", () => {
                tex.Mayo = false;
            });
        }

        [Fact]
        public void ChangingBaconPropertyShouldInvokePropertyChangedForBread()
        {
            var tex = new TexasTripleBurger();
            Assert.PropertyChanged(tex, "Bacon", () => {
                tex.Bacon= false;
            });
        }

        [Fact]
        public void ChangingEggPropertyShouldInvokePropertyChangedForBread()
        {
            var tex = new TexasTripleBurger();
            Assert.PropertyChanged(tex, "Egg", () => {
                tex.Egg = false;
            });
        }

        [Fact]
        public void ChangingPickleOrBreadPropertyShouldInvokePropertyChangedForSpecialInstructions()
        {
            var tex = new TexasTripleBurger();

            Assert.PropertyChanged(tex, "SpecialInstructions", () => {
                tex.Bun = false;
            });

            Assert.PropertyChanged(tex, "SpecialInstructions", () => {
                tex.Mayo = false;
            });

            Assert.PropertyChanged(tex, "SpecialInstructions", () => {
                tex.Lettuce = false;
            });

            Assert.PropertyChanged(tex, "SpecialInstructions", () => {
                tex.Tomato = false;
            });

            Assert.PropertyChanged(tex, "SpecialInstructions", () => {
                tex.Cheese = false;
            });

            Assert.PropertyChanged(tex, "SpecialInstructions", () => {
                tex.Pickle = false;
            });

            Assert.PropertyChanged(tex, "SpecialInstructions", () => {
                tex.Mustard = false;
            });

            Assert.PropertyChanged(tex, "SpecialInstructions", () => {
                tex.Ketchup = false;
            });

            Assert.PropertyChanged(tex, "SpecialInstructions", () => {
                tex.Bacon = false;
            });

            Assert.PropertyChanged(tex, "SpecialInstructions", () => {
                tex.Egg = false;
            });
        }
    }
}