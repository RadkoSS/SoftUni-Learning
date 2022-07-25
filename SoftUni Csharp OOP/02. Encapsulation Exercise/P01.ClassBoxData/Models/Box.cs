namespace ClassBoxData.Models
{
    using System;

    public class Box
    {
        private double _length;

        private double _width;

        private double _height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this._length;
            private set
            {
                ValidateValue(value, nameof(this.Length));

                this._length = value;
            }
        }

        public double Width
        {
            get => this._width;
            private set
            {
                ValidateValue(value, nameof(this.Width));

                this._width = value;
            }
        }

        public double Height
        {
            get => this._height;
            private set
            {
                ValidateValue(value, nameof(this.Height));

                this._height = value;
            }
        }

        private void ValidateValue(double value, string propertyName)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{propertyName} cannot be zero or negative.");
            }
        }

        public double SurfaceArea() => (2 * this.Length * this.Width) +  (2 * this.Length * this.Height) + (2 * this.Height * this.Width);

        public double LateralSurfaceArea() => 2 * this.Height * (this.Length + this.Width);

        public double Volume() => this.Length * this.Width * this.Height;

    }
}
