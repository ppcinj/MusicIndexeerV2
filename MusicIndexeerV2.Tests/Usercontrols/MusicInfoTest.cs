using MusicIndexeerV2.Usercontrols;
using NUnit.Framework;

namespace MusicIndexeerV2.Tests.Usercontrols
{
    [TestFixture]
    public class MusicInfoTest
    {
        [Test]
        public void MusicInfo_CreateConstructor_DoesntThrow()
        {
            // Act + // Assert
            Assert.DoesNotThrow(() =>
            {
                new MusicInfo("1.mp3", "C:/1.mp3", "3:40", "11.1 MB");
            });
        }

        [Test]
        public void MusicInfo_CreateFluent_DoesntThrow()
        {
            // Act + // Assert
            Assert.DoesNotThrow(() =>
            {
                new MusicInfo()
                    .WithTitle("1.mp3")
                    .WithPath("C:/1.mp3")
                    .WithLength("3:40")
                    .WithSize("11.1 MB");
            });
        }
    }
}
