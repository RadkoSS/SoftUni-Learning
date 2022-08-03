namespace Gym.Models.Equipment
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Kettlebell : Equipment
    {
        private const double DefaultWeight = 10000;

        private const decimal DefaultPrice = 80;

        public Kettlebell() : base(DefaultWeight, DefaultPrice)
        {
        }
    }
}
