using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public struct Pixel
    {
        private double r;
        public double R 
        {
            get => r;
            set  => r = CheckValue(value); 
        }

        private double g;
        public double G
        {
            get => g;
            set => g = CheckValue(value);
        }

        private double b;
        public double B
        {
            get => b;
            set => b = CheckValue(value);
        }
        
        private double[] rgb => new [] {r, g, b};
        private double max => rgb.Max();
        private double min => rgb.Min();

        public double H
        {
            get
            {
                if (max.Equals(min))
                    return 0;
                if (max.Equals(r))
                    if (g >= b)
                        return 60 * (g - b) / (max - min);
                    else
                        return 60 * (g - b) / (max - min) + 360;
                if (max.Equals(g))
                    return 60 * (b - r) / (max - min) + 120;
                return 60 * (r - g) / (max - min) + 240;
            }
        }

        public double S
        {
            get
            {
                if (max.Equals(min) || L.Equals(0))
                    return 0;
                return (max - min) / (1 - Math.Abs(1 - max - min));
            }
        }

        public double L => (max + min) / 2;


        public Pixel(double red, double green, double blue) : this()
        {
            R = Trim(red);
            G = Trim(green);
            B = Trim(blue);
        }

        
        public static Pixel operator *(double k, Pixel p)
        {
            Pixel result = new Pixel();

            result.r = Trim(k * p.r);
            result.g = Trim(k * p.g);
            result.b = Trim(k * p.b);

            return result;
        }

        public static Pixel operator *(Pixel p, double k) => k * p;      

        private double CheckValue(double val)
        {
            if (val < 0 || val > 1)
                throw new ArgumentException($"Неверное значение яркости канала: {val}");

            return val;
        }

        private static double Trim(double lightness)
        {
            if (lightness > 1)
                return 1;
            if (lightness < 0)
                return 0;

            return lightness;
        }
    }
}
