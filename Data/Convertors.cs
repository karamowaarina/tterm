using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public static class Convertors
    {
        public static Photo BitmapToPhoto(Bitmap bmp)
        {
            var photo = new Photo(bmp.Width, bmp.Height);

            for(var x = 0; x < bmp.Width; x++)
                for(var y = 0; y < bmp.Height; y++)
                {
                    var p = bmp.GetPixel(x, y);
                    photo[x, y] = new Pixel(p.R / 255.0, p.G / 255.0, p.B / 255.0);
                }

            return photo;
        }

        public static Bitmap PhotoToBitmap(Photo photo)
        {
            var bmp = new Bitmap(photo.Width, photo.Height);

            for (var x = 0; x < photo.Width; x++)
                for (var y = 0; y < photo.Height; y++)
                    bmp.SetPixel(x, y, 
                        Color.FromArgb(
                        (int)Math.Round(photo[x, y].R * 255),
                        (int)Math.Round(photo[x, y].G * 255),
                        (int)Math.Round(photo[x, y].B * 255)
                        ));
            return bmp;
        }

        public static Pixel HSLToPixel(double hue, double saturation, double lightness)
        {
            var q = lightness < 0.5
                ? lightness * (1 + saturation)
                : lightness + saturation - lightness * saturation;
            var p = 2 * lightness - q;
            var hk = hue / 360;
            var tr = hk + 1.0 / 3;
            var tg = hk;
            var tb = hk - 1.0 / 3;
            return new Pixel(
                HSLToColor(p, q, tr),
                HSLToColor(p, q, tg),
                HSLToColor(p, q, tb));
        }

        private static double HSLToColor(double p, double q, double t)
        {
            if (t < 0)
                t++;
            if (t > 1)
                t--;
            if (t < 1.0 / 6)
                return p + (q - p) * 6 * t;
            if (t < 0.5)
                return q;
            if (t < 2.0 / 3)
                return p + (q - p) * 6 * (2.0 / 3 - t);
            return p;
        }
    }
}
