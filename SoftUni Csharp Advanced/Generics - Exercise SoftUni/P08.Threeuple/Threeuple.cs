namespace P08.Threeuple
{
    public class Threeuple<TFirst, TSecond, TThird>
    {

        public Threeuple(TFirst firstParam, TSecond secondParam, TThird thirdParam)
        {
            this.First = firstParam;
            this.Second = secondParam;
            this.Third = thirdParam;
        }

        public TFirst First { get; private set; }


        public TSecond Second { get; private set; }


        public TThird Third { get; private set; }


        public override string ToString()
        {
            return $"{this.First} -> {this.Second} -> {this.Third}";
        }

    }
}
