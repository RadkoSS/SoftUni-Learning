using System;
using System.Text;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class DateModifier
    {
        private string day;

        private string month;

        private int year;

        public string Day 
        {
            get { return day; }
            set { day = value; }
        }

        public string Month
        {
            get { return month; }
            set { month = value; }
        }

        public int Year 
        {
            get { return year; }
            set { year = value; }
        }

    }
}
