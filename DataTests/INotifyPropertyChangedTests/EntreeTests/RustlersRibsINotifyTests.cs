using Xunit;
using CowboyCafe.Data.Entrees;
using System.ComponentModel;

namespace CowboyCafe.DataTests.INotifyPropertyChangedTests.EntreeTests
{
    public class RustlersRibsINotifyTests
    {
        [Fact]
        public void RustlersRibsImplementsINotifyPropertyChanged()
        {
            var rus = new RustlersRibs();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(rus);
        }
    }
}