using System;

namespace BankKata.Tests
{
    public class TestableClock : IClock
    {
        public string TodayAsString()
        {
            return new DateTime(2014, 04, 01).ToString("dd/MM/yyyy");
        }
    }
}