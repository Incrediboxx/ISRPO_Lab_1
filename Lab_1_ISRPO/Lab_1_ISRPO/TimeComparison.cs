using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_ISRPO
{
    class TimeComparison
    {
        //процедура для сравнения дат
        public static int TimeCompare(DateTime date, DateTime date2)
        {
            if ((date.Year == date2.Year) && (date.Month == date2.Month) && (date.Day == date2.Day))
            {
                return 0; // даты равны
            }

            else if ((date.Year == date2.Year) && (date.Month == date2.Month) && (date.Day != date2.Day))
            {
                if (date.Day > date2.Day)
                    return 1; //первая дата младше
                else
                    return -1; // первая дата старше
            }
            else if ((date.Year == date2.Year) && (date.Month != date2.Month))
            {
                if (date.Month > date2.Month)
                    return 1; //первая дата младше
                else
                    return -1; // первая дата старше
            }
            else if (date.Year != date2.Year)
            {
                if (date.Year > date2.Year)
                    return 1; //первая дата младше
                else
                    return -1; // первая дата старше
            }
            return 10;
        }
    }
}
