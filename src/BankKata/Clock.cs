using System;

namespace BankKata
{
    public class Clock : IClock
    {
        public string TodayAsString()
        {
            return Today().ToString("dd/MM/yyyy");
        }

        protected virtual DateTime Today()
        {
            return DateTime.Now;
        }
    }
}