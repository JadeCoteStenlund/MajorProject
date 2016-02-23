'TODO: Needs to be converted to VB
Module ModuleHolidays
    Sub GenerateHolidays()
        Debug.Write("TODO: Convert to VB")
    End Sub
End Module

'//Patrick Marcino
'//tested for the dates 2010 - 2030
'//--------------------------------To do--------------------------------
'//Right now all the holidays are coded into this app
'//I've  outlined three different kinds of holidays: Static, Dynamic, Other
'//Static holidays are ones that land on the exact same date every year 
'//like how Christmas lands on December 25th every year
'//Dynamic Holidays are ones that have their dates change every year
'//These Holidays always land on a Monday, or Friday
'//There may be a need to manipulate when the start date is, because Victoria Day is 
'//The first Monday after the 17th of May
'//Then the Other Holidays are pretty much Easter Friday - Currently the app finds Easter Day, not Easter Friday
'//This'll be a quick fix
'using System;
'using System.Collections.Generic;
'using System.Linq;
'using System.Text;
'using System.Threading.Tasks;
'using System.Data.SqlClient;

'Namespace FWHCSchedular
'{
'    Class Program
'    {
'        static void Main(string[] args)
'        {
'            //these variables will add a year to the current year to calculate all of the holidays and weekends for the next year
'            //curretly the applciation will compile completely for 2016. However, for any year other than 2016 it will not compile for the weekends, but it 
'            //will still find all of the holidays for that year
'            DateTime nextYear = DateTime.Today;
'            nextYear = nextYear.AddYears(1);

'            //for testing years that aren't next year, assign the year to int y. For instance if you want to calculate all the holidays/weekends in the year 2033
'            //change make int y = 2033;
'            int y = nextYear.Year;
'            findWeekends(y);
'            findHolidays(y);
'        }
'        public static void findHolidays(int y)
'        {
'            //Find all of the holidays in the year
'            DateTime startValue = new DateTime(y, 1, 1);
'            DateTime endValue = startValue.AddMonths(11);
'            DateTime[] arrayHolidays = new DateTime[8];
'            //Static Holidays are the Holidays that are on the same date each year
'            findStaticHolidays(y, arrayHolidays);
'            //Find Easter   -  Subtract two days from this to find Easter Friday
'            findEaster(y, arrayHolidays, startValue, endValue);
'            //Dynamic Holidays are Holidays that land on a different date each year
'            findDynamicHolidays(arrayHolidays, startValue, endValue);
'            int count = 0;
'            while (count != arrayHolidays.Length - 1)
'            {
'                using (SqlConnection connection = new SqlConnection("Data Source=PAT;Initial Catalog=FWFCScheduler;Integrated Security=True"))
'                {
'                    connection.Open();
'                    SqlCommand myCommand = new SqlCommand("INSERT INTO SpecialDates (Date, DateType) VALUES(@Date, @DateType)");
'                    myCommand.Connection = connection;
'                    myCommand.Parameters.AddWithValue("@Date", arrayHolidays[count]);
'                    myCommand.Parameters.AddWithValue("@DateType", "H");
'                    myCommand.ExecuteNonQuery();
'                    connection.Close();
'                    count++;
'                }
'            }
'        }
'        public static DateTime[] findDynamicHolidays(DateTime[] arrayHolidays, DateTime startValue, DateTime endValue)
'        {
'            int count = 0;
'            while (startValue <= endValue)
'            {
'                switch(startValue.ToString("MMMM"))
'                {
'                    case "February":
'                        findFamilyDay(arrayHolidays, startValue, count);
'                        startValue = startValue.AddDays(28);
'                        break;
'                    case "May":
'                        findVictoriaDay(arrayHolidays, startValue, count);
'                        startValue = startValue.AddDays(30);
'                        break;
'                    case "August":
'                        findCivicHolidays(arrayHolidays, startValue, count);
'                        startValue = startValue.AddDays(30);
'                        break;
'                    case "September":
'                        findLabourDay(arrayHolidays, startValue, count);
'                        startValue = startValue.AddDays(29);
'                        break;
'                    case "October":
'                        findThanksGiving(arrayHolidays, startValue, count);
'                        startValue = startValue.AddDays(31);
'                        break;
'                    default:
'                        break;
'                }
'                startValue = startValue.AddDays(1);
'            }
'            return arrayHolidays;
'        }
'        public static DateTime[] findFamilyDay(DateTime[] arrayHolidays, DateTime startValue, int count)
'         {
'            while(count != 3)
'            {
'                if(startValue.ToString("dddd") == "Monday")
'                { 
'                    count++;
'                }
'                if(count == 3)
'                { 
'                    arrayHolidays[3] = startValue;
'                }
'                startValue = startValue.AddDays(1);

'            }
'             return arrayHolidays;
'         }
'        public static DateTime[] findVictoriaDay(DateTime[] arrayHolidays, DateTime startValue, int count)
'         {
'             startValue = startValue.AddDays(17);
'             while (startValue.ToString("dddd") != "Monday")
'             {
'                 startValue = startValue.AddDays(1);
'             }
'             arrayHolidays[4] = startValue;
'             return arrayHolidays;
'         }
'        public static DateTime[] findCivicHolidays(DateTime[] arrayHolidays, DateTime startValue, int count)
'         {
'             while (count != 1)
'             {
'                 if (startValue.ToString("dddd") == "Monday")
'                 {
'                     count++;
'                 }
'                 if (count == 1)
'                 {
'                     arrayHolidays[5] = startValue;
'                 }
'                 startValue = startValue.AddDays(1);

'             }
'             return arrayHolidays;
'         }
'        public static DateTime[] findLabourDay(DateTime[] arrayHolidays, DateTime startValue, int count)
'         {
'             while (count != 1)
'             {
'                 if (startValue.ToString("dddd") == "Monday")
'                 {
'                     count++;
'                 }
'                 if (count == 1)
'                 {
'                     arrayHolidays[6] = startValue;
'                 }
'                 startValue = startValue.AddDays(1);

'             }
'             return arrayHolidays;
'         }
'        public static DateTime[] findThanksGiving(DateTime[] arrayHolidays, DateTime startValue, int count)
'         {
'             while (count != 2)
'             {
'                 if (startValue.ToString("dddd") == "Monday")
'                 {
'                     count++;
'                 }
'                 if (count == 2)
'                 {
'                     arrayHolidays[7] = startValue;
'                     break;
'                 }
'                 startValue = startValue.AddDays(1);

'             }
'             return arrayHolidays;
'         }

'        public static DateTime[] findEaster(int y, DateTime[] arrayHolidays, DateTime startValue, DateTime endValue)
'        {
'            //Algorithm found at http://aa.usno.navy.mil/faq/docs/easter.php
'            int c, n, k, i, j, l, m, d;
'            c = y / 100;
'            n = y - 19 * (y / 19);
'            k = (c - 17) / 25;
'            i = c -c / 4 - (c - k) / 3 + 19 * n + 15;
'            i = i - 30 * (i / 30);
'            i = i - (i / 28) * (1 - (i / 28) * (29 / (i + 1)) *((21 - n) / 11)); 
'            j = y + y /4 + i + 2 - c + c / 4;
'            j = j - 7 * (j / 7); 
'            l = i - j;
'            m = 3 + (l + 40) / 44;
'            d = l + 28 - 31 * (m / 4);
'            Console.WriteLine("Easter" + m + " " + d);
'            return arrayHolidays;
'        }
'        public static DateTime[] findStaticHolidays(int y, DateTime[] arrayHolidays)
'        {
'            //add Canada day to the list
'            DateTime staticHolidays = new DateTime(y,7,1);
'            arrayHolidays[0] = staticHolidays;

'            //add Christmas eve
'            staticHolidays = staticHolidays.AddMonths(5);
'            staticHolidays = staticHolidays.AddDays(23);
'            arrayHolidays[1] = staticHolidays;

'            //add christmas day
'            staticHolidays = staticHolidays.AddDays(1);
'            arrayHolidays[2] = staticHolidays;
'            return arrayHolidays;
'        }
'        public static void findWeekends(int y) 
'        {
'            DateTime startValue = new DateTime(y, 1, 1);
'            DateTime endValue = startValue.AddMonths(12);
'            DateTime[] arrayWeekends = new DateTime[159];
'            int count = 0;
'            while(startValue < endValue)
'            {
'                switch (startValue.ToString("dddd"))
'                {
'                    case "Friday":
'                        arrayWeekends[count] = startValue;
'                        count++;
'                        break;
'                    case "Saturday":
'                        arrayWeekends[count] = startValue;
'                        count++;
'                        break;
'                    case "Sunday":
'                        arrayWeekends[count] = startValue;
'                        count++;
'                        break;
'                    default:
'                        break;
'                }
'                startValue = startValue.AddDays(1);
'            }
'            count = 0;
'            while(count != arrayWeekends.Length-1)
'            {
'                using (SqlConnection connection = new SqlConnection("Data Source=PAT;Initial Catalog=FWFCScheduler;Integrated Security=True"))
'                {
'                    SqlCommand myCommand = new SqlCommand("INSERT INTO SpecialDates (Date, DateType) VALUES(@Date, @DateType)");
'                    myCommand.Connection = connection;
'                    myCommand.Parameters.AddWithValue("@Date", arrayWeekends[count]);
'                    myCommand.Parameters.AddWithValue("@DateType", "W");
'                    myCommand.ExecuteNonQuery();
'                    connection.Close();
'                    count++;
'                }
'            }
'        }
'    }
'}
