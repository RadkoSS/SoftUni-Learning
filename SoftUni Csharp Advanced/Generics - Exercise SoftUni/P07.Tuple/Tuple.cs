namespace P07.Tuple
{
    public class Tuple<TFirst, TSecond>
    {
        public Tuple(TFirst first, TSecond second)
        {
            this.First = first;
            this.Second = second;
        }

        public TFirst First { get; private set; }

        public TSecond Second { get; private set; }


        public override string ToString()
        {
            return $"{this.First} -> {this.Second}";
        }

    }
}
