﻿namespace RawData
{
    public class Tires
    {
        private int age;

        private double pressure;

        public Tires(int age, double pressure)
        {
            this.Age = age;
            this.Pressure = pressure;
        }

        public int Age 
        { 
            get { return age; } 
            set { age = value; }
        }

        public double Pressure 
        { 
            get { return pressure; } 
            set { pressure = value; }
        }
    }
}
