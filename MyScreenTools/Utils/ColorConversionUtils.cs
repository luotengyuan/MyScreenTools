using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 屏幕工具
{
    class ColorConversionUtils
    {

        public static void RGB2HSB(int red, int green, int blue, out double hue, out double sat, out double bri)
        {
            double r = ((double)red / 255.0);
            double g = ((double)green / 255.0);
            double b = ((double)blue / 255.0);

            double max = Math.Max(r, Math.Max(g, b));
            double min = Math.Min(r, Math.Min(g, b));

            hue = 0.0;
            if (max == r && g >= b)
            {
                if (max - min == 0) hue = 0.0;
                else hue = 60 * (g - b) / (max - min);
            }
            else if (max == r && g < b)
            {
                hue = 60 * (g - b) / (max - min) + 360;
            }
            else if (max == g)
            {
                hue = 60 * (b - r) / (max - min) + 120;
            }
            else if (max == b)
            {
                hue = 60 * (r - g) / (max - min) + 240;
            }

            sat = (max == 0) ? 0.0 : (1.0 - ((double)min / (double)max));
            bri = max;
        }

        public static void HSB2RGB(double hue, double sat, double bri, out int red, out int green, out int blue)
        {
            double r = 0;
            double g = 0;
            double b = 0;

            if (sat == 0)
            {
                r = g = b = bri;
            }
            else
            {
                // the color wheel consists of 6 sectors. Figure out which sector you're in.
                double sectorPos = hue / 60.0;
                int sectorNumber = (int)(Math.Floor(sectorPos));
                // get the fractional part of the sector
                double fractionalSector = sectorPos - sectorNumber;

                // calculate values for the three axes of the color. 
                double p = bri * (1.0 - sat);
                double q = bri * (1.0 - (sat * fractionalSector));
                double t = bri * (1.0 - (sat * (1 - fractionalSector)));

                // assign the fractional colors to r, g, and b based on the sector the angle is in.
                switch (sectorNumber)
                {
                    case 0:
                        r = bri;
                        g = t;
                        b = p;
                        break;
                    case 1:
                        r = q;
                        g = bri;
                        b = p;
                        break;
                    case 2:
                        r = p;
                        g = bri;
                        b = t;
                        break;
                    case 3:
                        r = p;
                        g = q;
                        b = bri;
                        break;
                    case 4:
                        r = t;
                        g = p;
                        b = bri;
                        break;
                    case 5:
                        r = bri;
                        g = p;
                        b = q;
                        break;
                }
            }
            red = Convert.ToInt32(r * 255);
            green = Convert.ToInt32(g * 255);
            blue = Convert.ToInt32(b * 255); ;
        }

        /// <summary>
        /// RGB转换HSL
        /// </summary>
        /// <param name="rgb"></param>
        /// <returns></returns>
        public static void RGB2HSL(int r, int g, int b, out double h, out double s, out double l)
        {
            float min, max, tmp, H, S, L;
            float R = r * 1.0f / 255, G = g * 1.0f / 255, B = b * 1.0f / 255;
            tmp = Math.Min(R, G);
            min = Math.Min(tmp, B);
            tmp = Math.Max(R, G);
            max = Math.Max(tmp, B);
            // H
            H = 0;
            if (max == min)
            {
                H = 0;  // 此时H应为未定义，通常写为0
            }
            else if (max == R && G > B)
            {
                H = 60 * (G - B) * 1.0f / (max - min) + 0;
            }
            else if (max == R && G < B)
            {
                H = 60 * (G - B) * 1.0f / (max - min) + 360;
            }
            else if (max == G)
            {
                H = H = 60 * (B - R) * 1.0f / (max - min) + 120;
            }
            else if (max == B)
            {
                H = H = 60 * (R - G) * 1.0f / (max - min) + 240;
            }
            // L 
            L = 0.5f * (max + min);
            // S
            S = 0;
            if (L == 0 || max == min)
            {
                S = 0;
            }
            else if (0 < L && L < 0.5)
            {
                S = (max - min) / (L * 2);
            }
            else if (L > 0.5)
            {
                S = (max - min) / (2 - 2 * L);
            }
            h = H;
            s = S;
            l = L;
        }

        /// <summary>
        /// HSL转换RGB
        /// </summary>
        /// <param name="hsl"></param>
        /// <returns></returns>
        public static void HSL2RGB(double h, double s, double l, out int r, out int g, out int b)
        {
            float R = 0f, G = 0f, B = 0f;
            float S = (float)s, L = (float)l;
            float temp1, temp2, temp3;
            if (S == 0f) // 灰色
            {
                R = L;
                G = L;
                B = L;
            }
            else
            {
                if (L < 0.5f)
                {
                    temp2 = L * (1.0f + S);
                }
                else
                {
                    temp2 = L + S - L * S;
                }
                temp1 = 2.0f * L - temp2;
                float H = (float)h * 1.0f / 360;
                // R
                temp3 = H + 1.0f / 3.0f;
                if (temp3 < 0) temp3 += 1.0f;
                if (temp3 > 1) temp3 -= 1.0f;
                R = temp3;
                // G
                temp3 = H;
                if (temp3 < 0) temp3 += 1.0f;
                if (temp3 > 1) temp3 -= 1.0f;
                G = temp3;
                // B
                temp3 = H - 1.0f / 3.0f;
                if (temp3 < 0) temp3 += 1.0f;
                if (temp3 > 1) temp3 -= 1.0f;
                B = temp3;
            }
            R = R * 255;
            G = G * 255;
            B = B * 255;
            r = (int)R;
            g = (int)G;
            b = (int)B;
        }
      
        /// <summary>
        /// RGB转换HSV
        /// </summary>
        /// <param name="rgb"></param>
        /// <returns></returns>
        public static void RGB2HSV(int r, int g, int b, out double h, out double s, out double v)
        {
            float min, max, tmp, H, S, V;
            float R = r * 1.0f / 255, G = g * 1.0f / 255, B = b * 1.0f / 255;
            tmp = Math.Min(R, G);
            min = Math.Min(tmp, B);
            tmp = Math.Max(R, G);
            max = Math.Max(tmp, B);
            // H
            H = 0;
            if (max == min)
            {
                H = 0;
            }
            else if (max == R && G > B)
            {
                H = 60 * (G - B) * 1.0f / (max - min) + 0;
            }
            else if (max == R && G < B)
            {
                H = 60 * (G - B) * 1.0f / (max - min) + 360;
            }
            else if (max == G)
            {
                H = H = 60 * (B - R) * 1.0f / (max - min) + 120;
            }
            else if (max == B)
            {
                H = H = 60 * (R - G) * 1.0f / (max - min) + 240;
            }
            // S
            if (max == 0)
            {
                S = 0;
            }
            else
            {
                S = (max - min) * 1.0f / max;
            }
            // V
            V = max;
            h = H;
            s = S;
            v = V;
        }
 
        /// <summary>
        /// HSV转换RGB
        /// </summary>
        /// <param name="hsv"></param>
        /// <returns></returns>
        public static void HSV2RGB(double h, double s, double v, out int r, out int g, out int b)
        {
            if (h == 360) h = 359; // 360为全黑，原因不明
            float R = 0f, G = 0f, B = 0f;
            if (s == 0)
            {
                r = (int)(v * 255);
                g = (int)(v * 255);
                b = (int)(v * 255);
                return;
            }
            float S = (float)s, V = (float)v;
            int H1 = (int)(h * 1.0f / 60), H = (int)h;
            float F = H * 1.0f / 60 - H1;
            float P = V * (1.0f - S);
            float Q = V * (1.0f - F * S);
            float T = V * (1.0f - (1.0f - F) * S);
            switch (H1)
            {
                case 0: R = V; G = T; B = P; break;
                case 1: R = Q; G = V; B = P; break;
                case 2: R = P; G = V; B = T; break;
                case 3: R = P; G = Q; B = V; break;
                case 4: R = T; G = P; B = V; break;
                case 5: R = V; G = P; B = Q; break;
            }
            R = R * 255;
            G = G * 255;
            B = B * 255;
            while (R > 255) R -= 255;
            while (R < 0) R += 255;
            while (G > 255) G -= 255;
            while (G < 0) G += 255;
            while (B > 255) B -= 255;
            while (B < 0) B += 255;
            r = (int)R;
            g = (int)G;
            b = (int)B;
        }

        public static void RGB2CMYK(int red, int green, int blue, out double c, out double m, out double y, out double k)
        {
            c = (double)(255 - red) / 255;
            m = (double)(255 - green) / 255;
            y = (double)(255 - blue) / 255;

            k = (double)Math.Min(c, Math.Min(m, y));
            if (k == 1.0)
            {
                c = m = y = 0;
            }
            else
            {
                c = (c - k) / (1 - k);
                m = (m - k) / (1 - k);
                y = (y - k) / (1 - k);
            }
        }
        public static void CMYK2RGB(double c, double m, double y, double k, out int r, out int g, out int b)
        {
            r = Convert.ToInt32((1.0 - c) * (1.0 - k) * 255.0);
            g = Convert.ToInt32((1.0 - m) * (1.0 - k) * 255.0);
            b = Convert.ToInt32((1.0 - y) * (1.0 - k) * 255.0);
        }

        public static string RGB2Hex(int r, int g, int b)
        {
            return String.Format("#{0:x2}{1:x2}{2:x2}", (int)r, (int)g, (int)b);
        }
        public static Color Hex2Color(string hexColor)
        {
            string r, g, b;

            if (hexColor != String.Empty)
            {
                hexColor = hexColor.Trim();
                if (hexColor[0] == '#') hexColor = hexColor.Substring(1, hexColor.Length - 1);

                r = hexColor.Substring(0, 2);
                g = hexColor.Substring(2, 2);
                b = hexColor.Substring(4, 2);

                r = Convert.ToString(16 * GetIntFromHex(r.Substring(0, 1)) + GetIntFromHex(r.Substring(1, 1)));
                g = Convert.ToString(16 * GetIntFromHex(g.Substring(0, 1)) + GetIntFromHex(g.Substring(1, 1)));
                b = Convert.ToString(16 * GetIntFromHex(b.Substring(0, 1)) + GetIntFromHex(b.Substring(1, 1)));

                return Color.FromArgb(Convert.ToInt32(r), Convert.ToInt32(g), Convert.ToInt32(b));
            }

            return Color.Empty;
        }
        private static int GetIntFromHex(string strHex)
        {
            switch (strHex)
            {
                case ("A"):
                    {
                        return 10;
                    }
                case ("B"):
                    {
                        return 11;
                    }
                case ("C"):
                    {
                        return 12;
                    }
                case ("D"):
                    {
                        return 13;
                    }
                case ("E"):
                    {
                        return 14;
                    }
                case ("F"):
                    {
                        return 15;
                    }
                default:
                    {
                        return int.Parse(strHex);
                    }
            }
        }


    }
}
