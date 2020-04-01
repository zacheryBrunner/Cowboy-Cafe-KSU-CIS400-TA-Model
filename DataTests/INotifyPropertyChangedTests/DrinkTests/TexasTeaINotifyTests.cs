using Xunit;
using System.ComponentModel;

using CowboyCafe.Data.Drinks;
using Size = CowboyCafe.Data.Enums.Size;

namespace CowboyCafe.DataTests.INotifyPropertyChangedTests.DrinkTests
{
    public class TexasTeaINotifyTests
    {
        [Fact]
        public void TexasTeaImplementsINotifyPropertyChanged()
        {
            var tt = new TexasTea();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(tt);
        }

        [Fact]
        public void ChangingIcePropertyShouldInvokePropertyChangedForIce()
        {
            var tt = new TexasTea();

            Assert.PropertyChanged(tt, "Ice", () => {
                tt.Ice = false;
            });
        }

        [Fact]
        public void ChangingSweetPropertyShouldInvokePropertyChangedForSweet()
        {
            var tt = new TexasTea();

            Assert.PropertyChanged(tt, "Sweet", () => {
                tt.Sweet = false;
            });
        }

        [Fact]
        public void ChangingLemonPropertyShouldInvokePropertyChangedForLemon()
        {
            var tt = new TexasTea();

            Assert.PropertyChanged(tt, "Lemon", () => {
                tt.Lemon = true;
            });
        }

        [Fact]
        public void ChangingIceOrLemonPropertyShouldInvokePropertyChangedForSpecialInstructions()
        {
            var tt = new TexasTea();

            Assert.PropertyChanged(tt, "SpecialInstructions", () => {
                tt.Ice = false;
            });

            Assert.PropertyChanged(tt, "SpecialInstructions", () => {
                tt.Lemon = true;
            });
        }

        [Fact]
        public void ChangingSweetPropertyShouldInvokePropertyChangedForName()
        {
            var tt = new TexasTea();

            Assert.PropertyChanged(tt, "Sweet", () => {
                tt.Sweet = false;
            });
        }

        [Fact]
        public void ChangingSizeNotifiesNameProperty()
        {
            var tt = new TexasTea();

            Assert.PropertyChanged(tt, "Name", () => {
                tt.Size = Size.Medium;
            });

            Assert.PropertyChanged(tt, "Name", () => {
                tt.Size = Size.Large;
            });

            Assert.PropertyChanged(tt, "Name", () => {
                tt.Size = Size.Small;
            });
        }
    }
}
