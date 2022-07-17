namespace Raiding.IO.Interfaces
{
    public interface IWriter
    {
        public void Write(string text);

        public void WriteLine();

        public void WriteLine(string text);
    }
}
