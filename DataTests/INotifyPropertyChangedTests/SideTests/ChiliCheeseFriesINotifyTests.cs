using Xunit;
using System.ComponentModel;

using CowboyCafe.Data.Sides;
using Size = CowboyCafe.Data.Enums.Size;

namespace CowboyCafe.DataTests.INotifyPropertyChangedTests.SideTests
{
    public class ChiliCheeseFriesINotifyTests
    { 
        [Fact]
        public void ChiliCheeseFriesImplementsINotifyPropertyChanged()
        {
            var ccf = new ChiliCheeseFries();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(ccf);
        }

        [Fact]
        public void ChaningSizeNotifiesNameProperty()
        {
            var ccf = new ChiliCheeseFries();

            Assert.PropertyChanged(ccf, "Name", () => {
                ccf.Size = Size.Medium;
            });

            Assert.PropertyChanged(ccf, "Name", () => {
                ccf.Size = Size.Large;
            });

            Assert.PropertyChanged(ccf, "Name", () => {
                ccf.Size = Size.Small;
            });
        }
    }
}
