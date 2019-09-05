using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LankaStocks.GDI
{
    public class Drawings
    {
        private static readonly Font Fonthead = new Font("Arial", 26);
        private static readonly Font fonts = new Font("Arial", 10);
        private static readonly SolidBrush BlackBrush = new SolidBrush(Color.Black);

        private static Graphics g;
        private static Bitmap b;

        private static readonly int Width = 210 * 5;
        private static readonly int Height = 297 * 5;

        private static PictureBox pb = new PictureBox();

        private static float Y = 100;
        public static int Margin = 30;
        public static float Loc = 50;

        public static string Pgno = "1";
        public static string HeadTag = "LankaStocks Sales";
        public static string Tag = "...LankaStocks...";

        public static Image Draw(List<IM_Data> data)
        {
            pb.Image = new Bitmap(Width, Height);
            b = new Bitmap(pb.Image);
            g = Graphics.FromImage(b);

            g.DrawImage(GDI.Properties.Resources.ba, 0, 0, Width, Height);
            Loc = Y;

            int iCount = data.Count;
            uint[] a = { 3, 10, 10, 35, 25, 17 };
            var percen = new List<uint> { 90, 440, 485, 560, 635, 680, 755, 830, 880 };

            g.DrawString(HeadTag, Fonthead, BlackBrush, (Width - g.MeasureString(HeadTag, Fonthead).Width) / 2, 30); //  Head Tag

            g.DrawString($"Date", fonts, BlackBrush, ((90 - g.MeasureString($"Date", fonts).Width) / 2) + Margin, Y + ((60 - g.MeasureString($"Date", fonts).Height) / 2)); //  Date
            g.DrawString($"Item Name", fonts, BlackBrush, ((350 - g.MeasureString($"Item Name", fonts).Width) / 2) + Margin + 90, Y + ((60 - g.MeasureString($"Item Name", fonts).Height) / 2));  //  Name
            g.DrawString($"Incoming", fonts, BlackBrush, ((195 - g.MeasureString($"Incoming", fonts).Width) / 2) + Margin + 440, Y + 7);  //  In
            g.DrawString($"Outgoing", fonts, BlackBrush, ((195 - g.MeasureString($"Outgoing", fonts).Width) / 2) + Margin + 635, Y + 7); //  Out
            g.DrawString($"Balance", fonts, BlackBrush, ((170 - g.MeasureString($"Balance", fonts).Width) / 2) + Margin + 830, Y + 7);   //  Balance
            g.DrawLine(new Pen(BlackBrush, 1), Margin, Loc, Width - Margin, Loc);        //   horizontal
            Loc += 30;
            g.DrawLine(new Pen(BlackBrush, 1), Margin + 440, Loc, Width - Margin, Loc);        //   horizontal

            g.DrawString($"Qty.", fonts, BlackBrush, ((45 - g.MeasureString($"Qty.", fonts).Width) / 2) + Margin + 440, Loc + 7);    //  Qty    IN
            g.DrawString($"Price", fonts, BlackBrush, ((75 - g.MeasureString($"Price", fonts).Width) / 2) + Margin + 485, Loc + 7);  //  Pri    IN
            g.DrawString($"Value", fonts, BlackBrush, ((75 - g.MeasureString($"Value", fonts).Width) / 2) + Margin + 560, Loc + 7);  //  Val    IN

            g.DrawString($"Qty.", fonts, BlackBrush, ((45 - g.MeasureString($"Qty.", fonts).Width) / 2) + Margin + 635, Loc + 7);    //  Qty    OUT
            g.DrawString($"Price", fonts, BlackBrush, ((75 - g.MeasureString($"Price", fonts).Width) / 2) + Margin + 680, Loc + 7);  //  Pri    OUT
            g.DrawString($"Value", fonts, BlackBrush, ((75 - g.MeasureString($"Value", fonts).Width) / 2) + Margin + 755, Loc + 7);  //  Val    OUT

            g.DrawString($"Qty.", fonts, BlackBrush, ((50 - g.MeasureString($"Qty.", fonts).Width) / 2) + Margin + 830, Loc + 7);    //  Qty    BAL
            g.DrawString($"Value", fonts, BlackBrush, ((100 - g.MeasureString($"Value", fonts).Width) / 2) + Margin + 880, Loc + 7); //  Val    BAL

            Loc += 30;
            g.DrawLine(new Pen(BlackBrush, 1), Margin, Y, Margin, Loc);                  //   Vertical Left Side
            g.DrawLine(new Pen(BlackBrush, 1), Margin + 90, Y, Margin + 90, Loc);        //   Vertical
            g.DrawLine(new Pen(BlackBrush, 1), Margin + 440, Y, Margin + 440, Loc);      //   Vertical
            g.DrawLine(new Pen(BlackBrush, 1), Margin + 635, Y, Margin + 635, Loc);      //   Vertical
            g.DrawLine(new Pen(BlackBrush, 1), Margin + 830, Y, Margin + 830, Loc);      //   Vertical
            g.DrawLine(new Pen(BlackBrush, 1), Width - Margin, Y, Width - Margin, Loc);  //   Vertical Right Side

            g.DrawLine(new Pen(BlackBrush, 1), Margin + 485, Y + 30, Margin + 485, Loc);      //   Vertical
            g.DrawLine(new Pen(BlackBrush, 1), Margin + 560, Y + 30, Margin + 560, Loc);      //   Vertical

            g.DrawLine(new Pen(BlackBrush, 1), Margin + 680, Y + 30, Margin + 680, Loc);      //   Vertical
            g.DrawLine(new Pen(BlackBrush, 1), Margin + 755, Y + 30, Margin + 755, Loc);      //   Vertical

            g.DrawLine(new Pen(BlackBrush, 1), Margin + 880, Y + 30, Margin + 880, Loc);      //   Vertical

            Y = Loc;
            g.DrawLine(new Pen(BlackBrush, 1), Margin, Loc, Width - Margin, Loc);        //   horizontal
            for (int rows = 0; rows < iCount; rows++)
            {
                var S = data[rows];

                g.DrawString($"{S.Date}", fonts, BlackBrush, 2 + Margin, Loc + 4); //  Date
                g.DrawString($"{S.Name}", fonts, BlackBrush, 2 + Margin + 90, Loc + 4);  //  Name

                g.DrawString($"{S.IN_qty}", fonts, BlackBrush, 2 + Margin + 440, Loc + 4);                  //  Qty      IN
                g.DrawString($"{S.IN_price}", fonts, BlackBrush, 2 + Margin + 485, Loc + 4);                //  Pri      IN
                g.DrawString($"{S.IN_qty * S.IN_price}", fonts, BlackBrush, 2 + Margin + 560, Loc + 4);     //  Val      IN

                g.DrawString($"{S.OUT_qty}.", fonts, BlackBrush, 2 + Margin + 635, Loc + 4);                //  Qty      OUT
                g.DrawString($"{S.OUT_price}", fonts, BlackBrush, 2 + Margin + 680, Loc + 4);               //  Pri      OUT
                g.DrawString($"{S.OUT_qty * S.OUT_price}", fonts, BlackBrush, 2 + Margin + 755, Loc + 4);   //  Val      OUT

                g.DrawString($"{S.BAL_qty}", fonts, BlackBrush, 2 + Margin + 830, Loc + 4);                 //  Qty      BAL
                g.DrawString($"{S.BAL_qty * S.OUT_price}", fonts, BlackBrush, 2 + Margin + 880, Loc + 4);   //  Val      BAL

                Loc += fonts.Height + 8;

                for (int columns = 0; columns < percen.Count; columns++)
                {
                    g.DrawLine(new Pen(BlackBrush, 1), Margin + percen[columns], Y, Margin + percen[columns], Loc);  //   Vertival
                }

                g.DrawLine(new Pen(BlackBrush, 1), Margin, Y, Margin, Loc);                  //   Vertival Left Side
                g.DrawLine(new Pen(BlackBrush, 1), Width - Margin, Y, Width - Margin, Loc);  //   Vertival Right Side
                g.DrawLine(new Pen(BlackBrush, 1), Margin, Loc, Width - Margin, Loc);        //   horizontal
            }
            g.DrawLine(new Pen(BlackBrush, 1), Margin, Height - 65, Width - Margin, Height - 65);        //   horizontal
            g.DrawString(Pgno, fonts, BlackBrush, Width - Margin - g.MeasureString(Pgno, fonts).Width, Height - 55); //  Page NO
            g.DrawString(Tag, fonts, BlackBrush, (Width - g.MeasureString(Tag, fonts).Width) / 2, Height - 55); //  Tag
            Console.WriteLine(Width);
            pb.Image = b;
            return b;
        }

        public static List<uint> GetColSize(uint[] percent)
        {
            List<uint> OUT = new List<uint>();
            uint t = 0;
            for (int i = 0; i < percent.Count(); i++)
            {
                t += percent[i];
                if (percent[i] == 0) throw new Exception("Column Size Cannot Be Zero!");
            }
            if (t > 100 || t < 100) throw new Exception("Percentage != 100%");
            else
            {
                int v = ((Width - (Margin * 2)) / 100);
                uint prev = 0;
                for (int i = 0; i < percent.Count(); i++)
                {
                    uint val = uint.Parse((v * percent[i]).ToString());
                    OUT.Add(prev + val);
                    prev += val;
                }
            }
            return OUT;
        }
    }

    public struct IM_Data
    {
        public string Date;
        public string Name;
        public decimal IN_qty;
        public decimal IN_price;
        public decimal OUT_qty;
        public decimal OUT_price;
        public decimal BAL_qty;
    }


    //public class Drawing
    //{
    //    private static readonly Font Fonthead = new Font("Arial", 26);
    //    private static readonly Font fonts = new Font("Arial", 12);
    //    private static readonly SolidBrush BlackBrush = new SolidBrush(Color.Black);

    //    private static Graphics g;
    //    private static Bitmap b;

    //    private static readonly int Width = 210 * 5;
    //    private static readonly int Height = 297 * 5;

    //    private static PictureBox pb = new PictureBox();

    //    private static readonly float Y = 150;
    //    public static int Margin = 50;
    //    public static float Loc = 50;

    //    public static string Pgno = "1";
    //    public static string HeadTag = "LankaStocks Sales";
    //    public static string Tag = "...LankaStocks...";

    //    public static Image Draw()
    //    {
    //        pb.Image = new Bitmap(Width, Height);
    //        b = new Bitmap(pb.Image);
    //        g = Graphics.FromImage(b);

    //        g.DrawImage(GDI.Properties.Resources.ba, 0, 0, Width, Height);
    //        Loc = Y;

    //        int iCount = 47;
    //        uint[] a = { 3, 10, 10, 35, 25, 17 };
    //        var percen = GetColSize(a);

    //        g.DrawString(HeadTag, Fonthead, BlackBrush, (Width - g.MeasureString(HeadTag, Fonthead).Width) / 2, 30); //  Head Tag
    //        g.DrawString($"Date : {DateTime.Now.ToShortDateString()}", fonts, BlackBrush, Margin, Y - 25); //  Date

    //        for (int rows = 0; rows < iCount; rows++)
    //        {
    //            for (int columns = 0; columns < percen.Count; columns++)
    //            {
    //                g.DrawLine(new Pen(BlackBrush, 1), Margin + percen[columns], Y, Margin + percen[columns], Loc);  //   Vertival
    //            }
    //            g.DrawLine(new Pen(BlackBrush, 1), Margin, Y, Margin, Loc);                  //   Vertival Left Side
    //            g.DrawLine(new Pen(BlackBrush, 1), Width - Margin, Y, Width - Margin, Loc);  //   Vertival Right Side
    //            g.DrawLine(new Pen(BlackBrush, 1), Margin, Loc, Width - Margin, Loc);        //   horizontal
    //            if (rows != iCount - 1)
    //                g.DrawString((rows + 1).ToString("00"), fonts, BlackBrush, Margin + 2, Loc + 4); //  No
    //            Loc += fonts.Height + 8;
    //        }
    //        g.DrawLine(new Pen(BlackBrush, 1), Margin, Height - 65, Width - Margin, Height - 65);        //   horizontal
    //        g.DrawString(Pgno, fonts, BlackBrush, Width - Margin - g.MeasureString(Pgno, fonts).Width, Height - 55); //  Page NO
    //        g.DrawString(Tag, fonts, BlackBrush, (Width - g.MeasureString(Tag, fonts).Width) / 2, Height - 55); //  Tag
    //        Console.WriteLine(Y);
    //        pb.Image = b;
    //        return b;
    //    }

    //    public static List<uint> GetColSize(uint[] percent)
    //    {
    //        List<uint> OUT = new List<uint>();
    //        uint t = 0;
    //        for (int i = 0; i < percent.Count(); i++)
    //        {
    //            t += percent[i];
    //            if (percent[i] == 0) throw new Exception("Column Size Cannot Be Zero!");
    //        }
    //        if (t > 100 || t < 100) throw new Exception("Percentage != 100%");
    //        else
    //        {
    //            int v = ((Width - (Margin * 2)) / 100);
    //            uint prev = 0;
    //            for (int i = 0; i < percent.Count(); i++)
    //            {
    //                uint val = uint.Parse((v * percent[i]).ToString());
    //                OUT.Add(prev + val);
    //                prev += val;
    //            }
    //        }
    //        return OUT;
    //    }
    //}
}
