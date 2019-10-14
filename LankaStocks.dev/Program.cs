using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LankaStocks.dev
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Core.IsDebug = true;

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Bitmap mapli = new Bitmap(Properties.Resources.Lion, new Size(237, 100));
            DrawPic(mapli);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Bitmap maplab = new Bitmap(Properties.Resources.Name, new Size(237, 30));
            DrawPic(maplab, true);

            LankaStocks.Program.Main();
        }

        static void DrawPic(Bitmap myBitmap, bool Invert = false)
        {
            bool black = false;
            string s = "";
            for (int y = 0; y < myBitmap.Height; y++)
            {
                for (int x = 0; x < myBitmap.Width; x++)
                {
                    Color pixelColor = myBitmap.GetPixel(x, y);
                    if (pixelColor.R < 100 && pixelColor.G < 100 && pixelColor.B < 100) black = true;
                    else black = false;
                    if (black)
                    {
                        if (!Invert)
                            s += "@";
                        else s += " ";
                    }
                    else
                    {
                        if (!Invert)
                            s += " ";
                        else s += "@";
                    }
                }
                s += "\n";
            }
            myBitmap.Dispose();
            Console.WriteLine(s);
        }
    }
}