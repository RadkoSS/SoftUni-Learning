namespace Shapes
{
    using System;

    public class Rectangle : IDrawable
    {
        private int height;

        private int width;

        public Rectangle(int height, int width)
        {
            this.Height = height;
            this.Width = width;
        }

        public int Height
        {
            get
            {
                return height;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new Exception("Height of a rectangle cannot be 0 or a negative number!");
                }
                height = value;
            }
        }

        public int Width
        {
            get
            {
                return width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new Exception("Width of a rectangle cannot be 0 or a negative number!");
                }
                width = value;
            }
        }

        public void Draw()
        {
            DrawLine(this.width, '*', '*');

            for (int i = 1; i < this.height - 1; ++i)
            {
                DrawLine(this.width, '*', ' ');
            }

            DrawLine(this.width, '*', '*');
        }

        public void DrawLine(int width, char end, char mid)
        {
            Console.Write(end);
            for (int i = 1; i < width - 1; ++i)
            {
                Console.Write(mid);
            }   
            Console.WriteLine(end);
        }
    }
}
