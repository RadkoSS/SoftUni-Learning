namespace Formula1.Models
{
    using System;
    using System.Collections.Generic;
    
    using Contracts;

    public class Race : IRace
    {
        public Race()
        {
            
        }

        public string RaceName { get; private set; }

        public int NumberOfLaps { get; private set; }

        public bool TookPlace { get; set; }

        public ICollection<IPilot> Pilots { get; private set; }

        public void AddPilot(IPilot pilot)
        {
            throw new NotImplementedException();
        }

        public string RaceInfo()
        {
            throw new NotImplementedException();
        }
    }
}
