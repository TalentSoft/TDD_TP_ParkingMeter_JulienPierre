using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParcMetre
{
    class ParcMeter
    {
        int ValeurCourante { get; set; }

        internal void InsertCoins(int p)
        {
            ValeurCourante = p;
        }

        internal int GetTime()
        {
            int timeForOneEuro = 20;
            int timeForTwoEuro = 60;
            int timeForThreeEuro = 60 * 2;
            int timeForFiveEuro = 60 * 12;
            int timeForEightEuro = 60 * 24;

            int restOfMoney = ValeurCourante;

            int timeEightEuro = (int)Math.Floor(restOfMoney / 8d);
            restOfMoney = restOfMoney - timeEightEuro * 8;
            int timeFiveEuro = (int)Math.Floor(restOfMoney / 5d);
            restOfMoney = restOfMoney - timeFiveEuro * 5;
            int timeThreeEuro = (int)Math.Floor(restOfMoney / 3d);
            restOfMoney = restOfMoney - timeThreeEuro * 3;
            int timeTwoEuro = (int)Math.Floor(restOfMoney / 2d);
            restOfMoney = restOfMoney - timeTwoEuro * 2;
            int timeOneEuro = (int)Math.Floor(restOfMoney / 1d);

            return timeEightEuro*timeForEightEuro + timeFiveEuro*timeForFiveEuro + timeThreeEuro*timeForThreeEuro +
                   timeTwoEuro*timeForTwoEuro + timeOneEuro*timeForOneEuro;
        }

        internal DateTime GetEndDate(DateTime lastInsertedCoinDate)
        {
            int startfreeTimeMidi = 12;
            int endfreeTimeMidi = 14;

            if (lastInsertedCoinDate.Hour < startfreeTimeMidi)
            {
                var calculatedDate = lastInsertedCoinDate.AddMinutes(GetTime());

                if (calculatedDate.Hour < startfreeTimeMidi)
                    return calculatedDate;
                else
                {
                    return calculatedDate.AddHours(endfreeTimeMidi - startfreeTimeMidi);
                }
            }
            
            return lastInsertedCoinDate.AddMinutes(GetTime());
        }
    }
}
