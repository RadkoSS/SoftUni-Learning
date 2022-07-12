namespace CollectionHierarchy.IO.Interfaces
{
    using System;

    public interface IWriter
    {
        void Write(string text);

        void WriteLine(string text);

        void WriteLine();
    }
}
