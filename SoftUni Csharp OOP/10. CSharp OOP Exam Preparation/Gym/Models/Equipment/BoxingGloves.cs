namespace Gym.Models.Equipment
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BoxingGloves : Equipment
    {
        private const double DefaultWeight = 227;

        private const decimal DefaultPrice = 120;

        public BoxingGloves() : base(DefaultWeight, DefaultPrice)
        {
        }
    }
}
