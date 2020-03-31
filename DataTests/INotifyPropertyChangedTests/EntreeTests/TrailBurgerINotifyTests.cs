using Xunit;
using CowboyCafe.Data.Entrees;
using System.ComponentModel;

namespace CowboyCafe.DataTests.INotifyPropertyChangedTests.EntreeTests
{
    public class TrailBurgerINotifyTests
    {
        [Fact]
        public void TrailBurgerImplementsINotifyPropertyChanged()
        {
            var tra = new TrailBurger();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(tra);
        }

        [Fact]
        public void ChangingBunPropertyShouldInvokePropertyChangedForBread()
        {
            var tra = new TrailBurger();
            Assert.PropertyChanged(tra, "Bun", () =>
            {
                tra.Bun = false;
            });
        }

        [Fact]
        public void ChangingKetchupPropertyShouldInvokePropertyChangedForBread()
        {
            var tra = new TrailBurger();
            Assert.PropertyChanged(tra, "Ketchup", () =>
            {
                tra.Ketchup = false;
            });
        }

        [Fact]
        public void ChangingMustardPropertyShouldInvokePropertyChangedForBread()
        {
            var tra = new TrailBurger();
            Assert.PropertyChanged(tra, "Mustard", () =>
            {
                tra.Mustard = false;
            });
        }

        [Fact]
        public void ChangingPicklePropertyShouldInvokePropertyChangedForBread()
        {
            var tra = new TrailBurger();
            Assert.PropertyChanged(tra, "Pickle", () =>
            {
                tra.Pickle = false;
            });
        }

        [Fact]
        public void ChangingCheesePropertyShouldInvokePropertyChangedForBread()
        {
            var tra = new TrailBurger();
            Assert.PropertyChanged(tra, "Cheese", () =>
            {
                tra.Cheese = false;
            });
        }

        [Fact]
        public void ChangingPickleOrBreadPropertyShouldInvokePropertyChangedForSpecialInstructions()
        {
            var tra = new TrailBurger();

            Assert.PropertyChanged(tra, "Bun", () =>
            {
                tra.Bun = false;
            });
            Assert.PropertyChanged(tra, "Ketchup", () =>
            {
                tra.Ketchup = false;
            });
            Assert.PropertyChanged(tra, "Mustard", () =>
            {
                tra.Mustard = false;
            });
            Assert.PropertyChanged(tra, "Pickle", () =>
            {
                tra.Pickle = false;
            });
            Assert.PropertyChanged(tra, "Cheese", () =>
            {
                tra.Cheese = false;
            });
        }
    }
}
