using Xunit;
using System.ComponentModel;

using CowboyCafe.Data.Drinks;
using Size = CowboyCafe.Data.Enums.Size;
using SodaFlavor = CowboyCafe.Data.Enums.SodaFlavor;

namespace CowboyCafe.DataTests.INotifyPropertyChangedTests.DrinkTests
{
    public class JerkedSodaINotifyTests
    {
        [Fact]
        public void JerkedSodaImplementsINotifyPropertyChanged()
        {
            var js = new JerkedSoda();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(js);
        }

        [Fact]
        public void ChangingIcePropertyShouldInvokePropertyChangedForIceAndSpecialInstructions()
        {
            var js = new JerkedSoda();
            Assert.PropertyChanged(js, "Ice", () => {
                js.Ice = false;
            });

            var js2 = new JerkedSoda();
            Assert.PropertyChanged(js2, "SpecialInstructions", () => {
                js2.Ice = false;
            });
        }

        [Fact]
        public void ChangingSizeNotifiesNameProperty()
        {
            var js = new JerkedSoda();

            Assert.PropertyChanged(js, "Name", () => {
                js.Size = Size.Medium;
            });

            Assert.PropertyChanged(js, "Name", () => {
                js.Size = Size.Large;
            });

            Assert.PropertyChanged(js, "Name", () => {
                js.Size = Size.Small;
            });
        }

        [Fact]
        public void ChangingFlavorNotifiesNameProperty()
        {
            var js = new JerkedSoda();

            Assert.PropertyChanged(js, "Name", () => {
                js.Flavor = SodaFlavor.OrangeSoda;
            });

            Assert.PropertyChanged(js, "Name", () => {
                js.Flavor = SodaFlavor.Sarsparilla;
            });

            Assert.PropertyChanged(js, "Name", () => {
                js.Flavor = SodaFlavor.BirchBeer;
            });
            
            Assert.PropertyChanged(js, "Name", () => {
                js.Flavor = SodaFlavor.RootBeer;
            });
            
            Assert.PropertyChanged(js, "Name", () => {
                js.Flavor = SodaFlavor.CreamSoda;
            });
        }
    }
}
