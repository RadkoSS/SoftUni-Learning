using System;
using System.Text;
using System.Collections.Generic;

namespace P03.GenericSwapMethodString
{
    public class Box<T>
    {
        public Box(List<T> values)
        {
            this.Values = values;
        }

        public List<T> Values { get; }

        public void Swap(List<T> list, int firstIndex, int secondIndex)
        {
            if (!CheckIndices(list, firstIndex, secondIndex))
                throw new ArgumentException($"{firstIndex} and {secondIndex} indexes are not presented in the list!");

            var tempItem = list[firstIndex];

            list[firstIndex] = list[secondIndex];

            list[secondIndex] = tempItem;
        }

        private bool CheckIndices(List<T> list, int firstIndex, int secondIndex)
        {
            return firstIndex >= 0 && firstIndex < list.Count && secondIndex >= 0 && secondIndex < list.Count;
        }

        public override string ToString()
        {
            var programOutput = new StringBuilder();

            this.Values.ForEach(inputLine => programOutput.AppendLine($"{inputLine.GetType()}: {inputLine}"));

            return programOutput.ToString().TrimEnd();
        }
    }
}
