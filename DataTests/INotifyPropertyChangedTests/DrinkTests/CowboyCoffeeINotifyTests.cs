using Xunit;
using System.ComponentModel;

using CowboyCafe.Data.Drinks;
using Size = CowboyCafe.Data.Enums.Size;

namespace CowboyCafe.DataTests.INotifyPropertyChangedTests.DrinkTests
{
    public class CowboyCoffeeINotifyTests
    {
        [Fact]
        public void CowboyCoffeeImplementsINotifyPropertyChanged()
        {
            var cc = new CowboyCoffee();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(cc);
        }

        [Fact]
        public void ChangingIcePropertyShouldInvokePropertyChangedForIce()
        {
            var cc = new CowboyCoffee();

            Assert.PropertyChanged(cc, "Ice", () => {
                cc.Ice = true;
            });
        }

        [Fact]
        public void ChangingDecafPropertyShouldInvokePropertyChangedForDecaf()
        {
            var cc = new CowboyCoffee();

            Assert.PropertyChanged(cc, "Decaf", () => {
                cc.Decaf = true;
            });
        }

        [Fact]
        public void ChangingCreamPropertyShouldInvokePropertyChangedForCream()
        {
            var cc = new CowboyCoffee();

            Assert.PropertyChanged(cc, "RoomForCream", () => {
                cc.RoomForCream = true;
            });
        }



        [Fact]
        public void ChangingIceOrDecafOrCreamPropertyShouldInvokePropertyChangedForSpecialInstructionsOrName()
        {
            var cc = new CowboyCoffee();

            Assert.PropertyChanged(cc, "SpecialInstructions", () => {
                cc.Ice = true;
            });

            Assert.PropertyChanged(cc, "Name", () => {
                cc.Decaf = true;
            });

            Assert.PropertyChanged(cc, "SpecialInstructions", () => {
                cc.RoomForCream = true;
            });
        }

        [Fact]
        public void ChangingSizeNotifiesNameProperty()
        {
            var cc = new CowboyCoffee();

            Assert.PropertyChanged(cc, "Name", () => {
                cc.Size = Size.Medium;
            });

            Assert.PropertyChanged(cc, "Name", () => {
                cc.Size = Size.Large;
            });

            Assert.PropertyChanged(cc, "Name", () => {
                cc.Size = Size.Small;
            });
        }
    }
}
