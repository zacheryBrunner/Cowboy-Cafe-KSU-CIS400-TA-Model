using Xunit;
using System.ComponentModel;

using CowboyCafe.Data.Sides;
using Size = CowboyCafe.Data.Enums.Size;

namespace CowboyCafe.DataTests.INotifyPropertyChangedTests.SideTests
{
    public class BakedBeansINotifyTests
    {
        [Fact]
        public void BakedBeansImplementsINotifyPropertyChanged()
        {
            var bak = new BakedBeans();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(bak);
        }

        [Fact]
        public void ChaningSizeNotifiesNameProperty()
        {
            var bak = new BakedBeans();

            Assert.PropertyChanged(bak, "Name", () => {
                bak.Size = Size.Medium;
            });

            Assert.PropertyChanged(bak, "Name", () => {
                bak.Size = Size.Large;
            });

            Assert.PropertyChanged(bak, "Name", () => {
                bak.Size = Size.Small;
            });
        }
    }
}