namespace WildFarm.Core
{
    using System;
    using System.Collections.Generic;

    using IO.Interfaces;
    using Interfaces;

    public class AppEngine : IEngine
    {
        private readonly IWriter writer;

        private readonly IReader reader;


        private AppEngine()
        {
            //TO-DO: Initialize collections in the private constructor...
        }

        public AppEngine(IWriter writer, IReader reader) : this()
        {
            this.writer = writer;
            this.reader = reader;
        }

        public void RunAplication()
        {
            
        }
    }
}
