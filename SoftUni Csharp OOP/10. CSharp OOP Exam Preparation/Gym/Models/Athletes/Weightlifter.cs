﻿namespace Gym.Models.Athletes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Weightlifter : Athlete
    {
        private const int DefaultStamina = 50;

        public Weightlifter(string fullName, string motivation, int numberOfMedals) : base(fullName, motivation, numberOfMedals, DefaultStamina)
        {
        }

        public override void Exercise()
        {
            throw new NotImplementedException();
        }
    }
}
