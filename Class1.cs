using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ParcMetre
{
    [TestFixture]
    public class TestParcMeter
    {
        [Test]
        public void ParcMeter_InsertCoins_InsertOneEuro_GetTwentyMinutes()
        {
            ParcMeter parcMeter = new ParcMeter();

            parcMeter.InsertCoins(1);

            Assert.AreEqual(20, parcMeter.GetTime());
        }

        [Test]
        public void ParcMeter_InsertCoins_InsertThreeEuro_GetTwoHours()
        {
            ParcMeter parcMeter = new ParcMeter();

            parcMeter.InsertCoins(3);

            Assert.AreEqual(60 * 2, parcMeter.GetTime());
        }

        [Test]
        public void ParcMeter_InsertCoins_InsertTwoEuro_GetOneHour()
        {
            ParcMeter parcMeter = new ParcMeter();

            parcMeter.InsertCoins(2);

            Assert.AreEqual(60, parcMeter.GetTime());
        }

        [Test]
        public void ParcMeter_InsertCoins_InsertFiveEuro_GetHalfDay()
        {
            ParcMeter parcMeter = new ParcMeter();

            parcMeter.InsertCoins(5);

            Assert.AreEqual(12 * 60, parcMeter.GetTime());
        }

        [Test]
        public void ParcMeter_InsertCoins_InsertHeightEuro_GetDay()
        {
            ParcMeter parcMeter = new ParcMeter();

            parcMeter.InsertCoins(8);

            Assert.AreEqual(24 * 60, parcMeter.GetTime());
        }

        [Test]
        public void ParcMeter_InsertCoins_InsertTenEuro_GetOneDayAndOneHour()
        {
            ParcMeter parcMeter = new ParcMeter();

            parcMeter.InsertCoins(10);

            Assert.AreEqual(24 * 60 + 60, parcMeter.GetTime());
        }

        [Test]
        public void ParcMeter_InsertThreeEuroAt8_GetParckingTo10()
        {
            ParcMeter parcMeter = new ParcMeter();

            parcMeter.InsertCoins(3);

            var now = new DateTime(2012, 1, 15, 8, 0, 0);
            Assert.AreEqual(now.AddHours(2), parcMeter.GetEndDate(now));
        }

        [Test]
        public void ParcMeter_InsertThreeEuroAt11_GetParckingTo15()
        {
            ParcMeter parcMeter = new ParcMeter();

            parcMeter.InsertCoins(3);

            var now = new DateTime(2012, 1, 15, 11, 0, 0);
            Assert.AreEqual(now.AddHours(4), parcMeter.GetEndDate(now));
        }
    }
}
