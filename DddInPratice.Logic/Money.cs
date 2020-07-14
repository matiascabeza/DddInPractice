using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddInPratice.Logic
{
    public sealed class Money
    {
        public int OneCentCount { get; private set; }
        public int TenCentCount { get; private set; }
        public int QuarterCount { get; private set; }
        public int OneDollarCount { get; private set; }
        public int FiveDollarCount { get; private set; }
        public int TwentyDollarCount { get; private set; }

        public Money(int oneCentCount, int tenCentCount, int quarterCount, int oneDollarCount, int fiveDollarCount, int twentyDollarCount)
        {
            OneCentCount = oneCentCount;
            TenCentCount = tenCentCount;
            QuarterCount = quarterCount;
            OneDollarCount = oneDollarCount;
            FiveDollarCount = fiveDollarCount;
            TwentyDollarCount = twentyDollarCount;
        }

        public static Money operator +(Money money1, Money money2)
        {
            Money sum = new Money(
                money2.OneCentCount + money2.OneCentCount,
                money2.TenCentCount + money2.TenCentCount,
                money2.QuarterCount + money2.QuarterCount,
                money2.OneDollarCount + money2.OneDollarCount,
                money2.FiveDollarCount + money2.FiveDollarCount,
                money2.TwentyDollarCount + money2.TwentyDollarCount
            );
            return sum;
        }


    }
}
