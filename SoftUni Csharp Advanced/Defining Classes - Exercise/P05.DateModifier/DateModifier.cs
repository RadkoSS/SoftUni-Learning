using System;
using System.Text;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class DateModifier
    {
        private string day;

        private string month;

        private string year;

        public DateModifier(string day, string month, string year)
        {
            this.Day = day;
            this.Month = month;
            this.Year = year;
        }
    
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

        public string Year 
        {
            get { return year; }
            set { year = value; }
        }

        public int CalculateDifference(DateModifier firstDate, DateModifier secondDate)
        {
            
        }
    }
}
