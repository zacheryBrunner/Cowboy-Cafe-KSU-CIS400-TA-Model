using Xunit;
using System.ComponentModel;

using CowboyCafe.Data.Sides;
using Size = CowboyCafe.Data.Enums.Size;

namespace CowboyCafe.DataTests.INotifyPropertyChangedTests.SideTests
{
    public class PandeCampoINotifyTests
    {
        [Fact]
        public void PandeCampoImplementsINotifyPropertyChanged()
        {
            var pdc = new PanDeCampo();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(pdc);
        }

        [Fact]
        public void ChaningSizeNotifiesNameProperty()
        {
            var pdc = new PanDeCampo();

            Assert.PropertyChanged(pdc, "Name", () => {
                pdc.Size = Size.Medium;
            });

            Assert.PropertyChanged(pdc, "Name", () => {
                pdc.Size = Size.Large;
            });

            Assert.PropertyChanged(pdc, "Name", () => {
                pdc.Size = Size.Small;
            });
        }
    }
}
