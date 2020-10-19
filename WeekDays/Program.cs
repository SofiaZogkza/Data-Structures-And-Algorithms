using System;
using System.Collections.Generic;
using System.Globalization;

namespace WeekDays
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string today = WhatDayOfTheWeekIsToday();
            int todayKey = FindTodaysKey(today);

            Console.WriteLine("Today is: <<" + today + ">> and the key is: <<" + todayKey + ">>");
            Console.WriteLine("\nLet's see what day will be after a number of days you will choose!\n");
            int validDayKey = CheckIfEnteredNumberIsValid();

            FindDayAfterNumberOfDays(todayKey, validDayKey);
        }        

        private static string WhatDayOfTheWeekIsToday()
        {
            // Translate to English so that for example you see "Friday" instead of "Παρασκευη".
            CultureInfo ci = new CultureInfo("en-US");
            // Friday, October 16, 2020
            string today = DateTime.Today.ToString("D", ci);
            // Position of the first ,
            int index = today.IndexOf(",");
            string todayDay = today.Substring(0, index);
            /*
                Console.WriteLine("Before: " + today);
                Console.WriteLine("After : " + todayDay);
            */                       
            return todayDay;
        }

        private static int FindTodaysKey(string today)
        {
            int todayKey = 0;
            foreach (var weekDay in WeekDaysDict)
            {
                if (today == weekDay.Value)
                {
                    todayKey = weekDay.Key;
                }
            }
            return todayKey;
        }

        private static int CheckIfEnteredNumberIsValid()
        {
            int validDay = 0;
            int correctDay = 0;
            Console.WriteLine("Enter a positive number.");
            string enteredDay = Console.ReadLine();
            bool isNumber = Int32.TryParse(enteredDay, out validDay);
            correctDay = CheckIfItIsPositiveNumber(validDay);

            while (!isNumber)
            {
                Console.WriteLine("FAILED! Please try entering a valid Number");
                isNumber = Int32.TryParse(Console.ReadLine(), out validDay);

                correctDay = CheckIfItIsPositiveNumber(validDay);
            };
            //Console.WriteLine(validDay.ToString());
            return correctDay;
        }

        private static int CheckIfItIsPositiveNumber(int validDay)
        {
            while (validDay < 0)
            {
                Console.WriteLine("FAILED! Please try entering a positive Number");
                try
                {
                    validDay = Int32.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("FAILED! exception");
                }
            }
            return validDay;
        }

        private static void FindDayAfterNumberOfDays(int todayKey, int validDayKey)
        {
            int KeyOfTheDayYouWantToFind = todayKey + validDayKey;
            foreach (var weekDay in WeekDaysDict)
            {
                if (KeyOfTheDayYouWantToFind >= 7)
                {
                    if ((KeyOfTheDayYouWantToFind % 7) == weekDay.Key)
                    {
                        Console.WriteLine("The week day after " + validDayKey + " days , will be " + weekDay.Value + "!");
                    }
                }

                else
                {
                    if (KeyOfTheDayYouWantToFind == weekDay.Key)
                    {
                        Console.WriteLine("The week day after " + validDayKey + " days , will be " + weekDay.Value + "!");
                    }
                }
            }
        }

        private static Dictionary<int, string> WeekDaysDict = new Dictionary<int, string>()
        {
            {1,"Monday"},
            {2,"Tuesday"},
            {3,"Wednesday"},
            {4,"Thursday"},
            {5,"Friday"},
            {6,"Saturday"},
            {7,"Sunday"}
        };
    }
}