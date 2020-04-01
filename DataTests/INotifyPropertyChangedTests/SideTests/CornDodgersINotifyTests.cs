using Xunit;
using System.ComponentModel;

using CowboyCafe.Data.Sides;
using Size = CowboyCafe.Data.Enums.Size;

namespace CowboyCafe.DataTests.INotifyPropertyChangedTests.SideTests
{
    public class CornDodgersINotifyTests
    {
        [Fact]
        public void CornDodgersImplementsINotifyPropertyChanged()
        {
            var cd = new CornDodgers();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(cd);
        }

        [Fact]
        public void ChaningSizeNotifiesNameProperty()
        {
            var cd = new CornDodgers();

            Assert.PropertyChanged(cd, "Name", () => {
                cd.Size = Size.Medium;
            });

            Assert.PropertyChanged(cd, "Name", () => {
                cd.Size = Size.Large;
            });

            Assert.PropertyChanged(cd, "Name", () => {
                cd.Size = Size.Small;
            });
        }
    }
}