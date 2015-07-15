using NUnit.Framework;

namespace BankKata.Tests
{
    [TestFixture]
    public class ClockShould
    {
        private IClock _clock;

        [SetUp]
        public void Initialise_Test()
        {
            _clock = new TestableClock();
        }

        [Test]
        public void Return_The_Current_System_Date_As_String()
        {
            var today = _clock.TodayAsString();

            Assert.That(today, Is.EqualTo("01/04/2014"));
        }
    }
}
