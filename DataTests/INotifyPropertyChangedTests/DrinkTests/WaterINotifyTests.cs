using Xunit;
using System.ComponentModel;

using CowboyCafe.Data.Drinks;
using Size = CowboyCafe.Data.Enums.Size;

namespace CowboyCafe.DataTests.INotifyPropertyChangedTests.DrinkTests
{
    public class WaterINotifyTests
    {
        [Fact]
        public void WaterImplementsINotifyPropertyChanged()
        {
            var w = new Water();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(w);
        }

        [Fact]
        public void ChangingIcePropertyShouldInvokePropertyChangedForIce()
        {
            var w = new Water();
            Assert.PropertyChanged(w, "Ice", () => {
                w.Ice = false;
            });
        }

        [Fact]
        public void ChangingLemonPropertyShouldInvokePropertyChangedForLemon()
        {
            var w = new Water();
            Assert.PropertyChanged(w, "Lemon", () => {
                w.Lemon = true;
            });
        }

        [Fact]
        public void ChangingIceOrLemonPropertyShouldInvokePropertyChangedForSpecialInstructions()
        {
            var w = new Water();
            
            Assert.PropertyChanged(w, "SpecialInstructions", () => {
                w.Ice = false;
            });

            Assert.PropertyChanged(w, "SpecialInstructions", () => {
                w.Lemon = true;
            });
        }

        [Fact]
        public void ChangingSizeNotifiesNameProperty()
        {
            var w = new Water();

            Assert.PropertyChanged(w, "Name", () => {
                w.Size = Size.Medium;
            });

            Assert.PropertyChanged(w, "Name", () => {
                w.Size = Size.Large;
            });

            Assert.PropertyChanged(w, "Name", () => {
                w.Size = Size.Small;
            });
        }
    }
}
