using Xunit;
using CowboyCafe.Data.Entrees;
using System.ComponentModel;

namespace CowboyCafe.DataTests.INotifyPropertyChangedTests.EntreeTests
{
    public class CowpokeChiliINotifyTests
    {
        [Fact]
        public void CowpokeChiliImplementsINotifyPropertyChanged()
        {
            var cow = new CowpokeChili();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(cow);
        }

        [Fact]
        public void ChangingCheesePropertyShouldInvokePropertyChangedForBread()
        {
            var cow = new CowpokeChili();
            Assert.PropertyChanged(cow, "Cheese", () => {
                cow.Cheese = false;
            });
        }

        [Fact]
        public void ChangingSourCreamPropertyShouldInvokePropertyChangedForBread()
        {
            var cow = new CowpokeChili();
            Assert.PropertyChanged(cow, "SourCream", () => {
                cow.SourCream = false;
            });
        }

        [Fact]
        public void ChangingGreenOnionsPropertyShouldInvokePropertyChangedForBread()
        {
            var cow = new CowpokeChili();
            Assert.PropertyChanged(cow, "GreenOnions", () => {
                cow.GreenOnions = false;
            });
        }

        [Fact]
        public void ChangingBreadPropertyShouldInvokePropertyChangedForBread()
        {
            var cow = new CowpokeChili();
            Assert.PropertyChanged(cow, "TortillaStrips", () => {
                cow.TortillaStrips = false;
            });
        }

        [Fact]
        public void ChangingAnyPropertyShouldInvokePropertyChangedForSpecialInstructions()
        {
            var cow = new CowpokeChili();

            Assert.PropertyChanged(cow, "SpecialInstructions", () => {
                cow.Cheese = false;
            });

            Assert.PropertyChanged(cow, "SpecialInstructions", () =>
            {
                cow.SourCream = false;
            });

            Assert.PropertyChanged(cow, "SpecialInstructions", () => {
                cow.GreenOnions = false;
            });

            Assert.PropertyChanged(cow, "SpecialInstructions", () =>
            {
                cow.TortillaStrips = false;
            });
        }
    }
}
