namespace RawData
{
    public class Cargo
    {
        private string type;

        private int weight;

        public Cargo(string type, int weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public Cargo()
        {
            this.Type = string.Empty;
            this.Weight = 0;
        }

        public string Type
        { 
            get { return type; } 
            set { type = value; }
        }

        public int Weight 
        { 
            get { return weight; } 
            set { weight = value; }
        }
    }
}
