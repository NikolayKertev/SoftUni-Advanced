using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get => length; 
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.EXCEPTION_MESSAGE, nameof(this.Length)));
                }

                length = value;
            }
        }
        public double Width
        {
            get => width;
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.EXCEPTION_MESSAGE, nameof(this.Width)));
                }

                width = value;
            }
        }
        public double Height
        {
            get => height;
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.EXCEPTION_MESSAGE, nameof(this.Height)));
                }

                height = value;
            }
        }

        private double SurfaceArea() => 2 * length * width + LateralSurfaceArea();
        private double LateralSurfaceArea() => 2 * length * height + 2 * width * height;
        private double Volume() => length * width * height;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Surface Area - {SurfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {LateralSurfaceArea():f2}");
            sb.AppendLine($"Volume - {Volume():f2}");

            return sb.ToString();
        }
    }
}
