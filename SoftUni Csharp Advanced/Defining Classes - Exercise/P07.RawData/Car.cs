using System.Collections.Generic;

namespace RawData
{
    public class Car
    {
        private string model;

        private Engine engine;

        private Cargo cargo;

        private List<Tires> tires;

        public Car()
        {
            this.Engine = new Engine();
            this.Cargo = new Cargo();
            this.Tires = new List<Tires>();
        }

        public Car(string model, Engine engine, Cargo cargo, List<Tires> tires) : this()
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }

        public string Model 
        {
            get { return model; }
            set { model = value; }
        }

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        public Cargo Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }

        public List<Tires> Tires
        {
            get { return tires; }
            set { tires = value; }
        }

        public override string ToString()
        {
            return this.Model;
        }
    }
}
