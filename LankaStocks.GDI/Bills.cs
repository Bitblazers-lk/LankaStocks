using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LankaStocks.GDI
{
    class Bills
    {
        private static string Line1 = null;
        private static string Line2 = null;
        private static string Line3 = null;

        private static string LLine1 = null;
        private static string LLine2 = null;
        private static string LLine3 = null;

        public static string RowL = "--------------------------------------------------------------------------------------------";

        private static Font Font;
        private static Font FontHeader;
        private static readonly Font fonts = new Font("Arial", 7);
        private static readonly SolidBrush BlackBrush = new SolidBrush(Color.Black);

        private static Graphics g;
        private static Bitmap b;

        private static PictureBox pb = new PictureBox();

        //private static float X = 20;
        private static float Y = 0;

        public static void SetFont(Font My_Font)
        {
            Font = My_Font;
        }
        public static void SetHeaderBeginFont(Font My_HeaderBeginFont)
        {
            FontHeader = My_HeaderBeginFont;
        }

        public static void SetHeaderBegin(string Line_1, string Line_2, string Line_3)
        {
            Line1 = Line_1;
            Line2 = Line_2;
            Line3 = Line_3;
        }

        public static void SetHeaderEnd(string Line_1, string Line_2, string Line_3)
        {
            LLine1 = Line_1;
            LLine2 = Line_2;
            LLine3 = Line_3;
        }

        public static Image Draw(List<BillItem> Items, string Invoice_NO, string User_Name)
        {
            var h = 236.5937 + (18.21875 * Items.Count * 2) + (454.7812 - 273.0312) + 70;

            pb.Image = new Bitmap(500, (int)h);
            b = new Bitmap(pb.Image);
            g = Graphics.FromImage(b);

            g.DrawImage(GDI.Properties.Resources.ba, 0, 0, 500, (int)h);

            Y = 50;

            if (Line1 != null)
            {
                g.DrawString(Line1, FontHeader, BlackBrush, (500 - g.MeasureString(Line1, FontHeader).Width) / 2, Y);
                Y += g.MeasureString(Line1, FontHeader).Height + 2;
            }

            if (Line2 != null)
            {
                g.DrawString(Line2, Font, BlackBrush, (500 - g.MeasureString(Line2, Font).Width) / 2, Y);
                Y += g.MeasureString(Line2, Font).Height + 2;
            }

            if (Line3 != null)
            {
                g.DrawString(Line3, Font, BlackBrush, (500 - g.MeasureString(Line3, Font).Width) / 2, Y);
                Y += g.MeasureString(Line3, Font).Height + 2;
            }

            Y += 10;

            g.DrawString(RowL, Font, BlackBrush, (500 - g.MeasureString(RowL, Font).Width) / 2, Y);
            Y += g.MeasureString(RowL, Font).Height;

            g.DrawString($"Date : {DateTime.Now.ToString()}", Font, BlackBrush, (500 - g.MeasureString(RowL, Font).Width) / 2, Y);
            g.DrawString($"CS : {User_Name}", Font, BlackBrush, 290, Y);
            Y += g.MeasureString(DateTime.Now.ToString(), Font).Height;

            g.DrawString($"Invoice NO. : {Invoice_NO}", Font, BlackBrush, (500 - g.MeasureString(RowL, Font).Width) / 2, Y);
            Y += g.MeasureString("Invoice NO. :", Font).Height;

            g.DrawString(RowL, Font, BlackBrush, (500 - g.MeasureString(RowL, Font).Width) / 2, Y);
            Y += g.MeasureString(RowL, Font).Height;

            g.DrawString("NO", Font, BlackBrush, (500 - g.MeasureString(RowL, Font).Width) / 2, Y);
            g.DrawString("ITEM", Font, BlackBrush, ((500 - g.MeasureString(RowL, Font).Width) / 2) + 50, Y);
            g.DrawString("QTY", Font, BlackBrush, ((500 - g.MeasureString(RowL, Font).Width) / 2) + 150, Y);
            g.DrawString("PRICE", Font, BlackBrush, ((500 - g.MeasureString(RowL, Font).Width) / 2) + 240, Y);
            g.DrawString("AMOUNT", Font, BlackBrush, 500 - ((500 - g.MeasureString(RowL, Font).Width) / 2) - g.MeasureString("AMOUNT", Font).Width - 5, Y);
            Y += g.MeasureString("Item", Font).Height;

            g.DrawString(RowL, Font, BlackBrush, (500 - g.MeasureString(RowL, Font).Width) / 2, Y);
            Y += g.MeasureString(RowL, Font).Height;
            //Console.WriteLine(Y);
            //Console.WriteLine(g.MeasureString(RowL, Font).Height);
            //Console.WriteLine(g.MeasureString("Invoice NO. :", Font).Height);
            int NO = 0;
            decimal Total = 0;
            foreach (var s in Items)
            {
                decimal amount = s.Price * s.Qty;
                Total += amount;
                NO++;
                g.DrawString(NO.ToString(), Font, BlackBrush, (500 - g.MeasureString(RowL, Font).Width) / 2, Y);
                g.DrawString(s.Name, Font, BlackBrush, ((500 - g.MeasureString(RowL, Font).Width) / 2) + 50, Y);
                Y += g.MeasureString(RowL, Font).Height;

                g.DrawString(s.Code.ToString("00"), Font, BlackBrush, ((500 - g.MeasureString(RowL, Font).Width) / 2) + 50, Y);
                g.DrawString(s.Qty.ToString("00.00"), Font, BlackBrush, ((500 - g.MeasureString(RowL, Font).Width) / 2) + 150, Y);
                g.DrawString(s.Price.ToString("0.00"), Font, BlackBrush, ((500 - g.MeasureString(RowL, Font).Width) / 2) + 240, Y);
                g.DrawString(amount.ToString("0.00"), Font, BlackBrush, 500 - ((500 - g.MeasureString(RowL, Font).Width) / 2) - g.MeasureString(amount.ToString("0.00"), Font).Width - 5, Y);
                Y += g.MeasureString(RowL, Font).Height;
            }
           // Console.WriteLine(Y);
            g.DrawString(RowL, Font, BlackBrush, (500 - g.MeasureString(RowL, Font).Width) / 2, Y);
            Y += g.MeasureString(RowL, Font).Height + 5;

            g.DrawString("Gross Total", Font, BlackBrush, (500 - g.MeasureString(RowL, Font).Width) / 2, Y);
            g.DrawString(Total.ToString("0.00"), Font, BlackBrush, 500 - ((500 - g.MeasureString(RowL, Font).Width) / 2) - g.MeasureString(Total.ToString("0.00"), Font).Width - 5, Y);
            Y += g.MeasureString(RowL, Font).Height + 5;

            g.DrawString("Discount", Font, BlackBrush, (500 - g.MeasureString(RowL, Font).Width) / 2, Y);
            g.DrawString("00.00", Font, BlackBrush, 500 - ((500 - g.MeasureString(RowL, Font).Width) / 2) - g.MeasureString("00.00", Font).Width - 5, Y);
            Y += g.MeasureString(RowL, Font).Height + 5;

            g.DrawString("Net Total", Font, BlackBrush, (500 - g.MeasureString(RowL, Font).Width) / 2, Y);
            g.DrawString(Total.ToString("0.00"), Font, BlackBrush, 500 - ((500 - g.MeasureString(RowL, Font).Width) / 2) - g.MeasureString(Total.ToString("0.00"), Font).Width - 5, Y);
            Y += g.MeasureString(RowL, Font).Height + 5;

            g.DrawString(RowL, Font, BlackBrush, (500 - g.MeasureString(RowL, Font).Width) / 2, Y);
            Y += g.MeasureString(RowL, Font).Height + 10;

            if (LLine1 != null)
            {
                g.DrawString(LLine1, Font, BlackBrush, (500 - g.MeasureString(LLine1, Font).Width) / 2, Y);
                Y += g.MeasureString(LLine1, Font).Height + 2;
            }

            if (LLine2 != null)
            {
                g.DrawString(LLine2, Font, BlackBrush, (500 - g.MeasureString(LLine2, Font).Width) / 2, Y);
                Y += g.MeasureString(LLine2, Font).Height + 2;
            }

            if (LLine3 != null)
            {
                g.DrawString(LLine3, Font, BlackBrush, (500 - g.MeasureString(LLine3, Font).Width) / 2, Y);
                Y += g.MeasureString(LLine3, Font).Height + 2;
            }
            Y += 7;
            g.DrawString("Software By Harindu Wijesinghe & Hasindu Lanka.", fonts, BlackBrush, (500 - g.MeasureString("Software By Harindu Wijesinghe & Hasindu Lanka.", fonts).Width) / 2, Y);

            //Console.WriteLine(Y);
            pb.Image = b;
            return b;
        }
    }

    class BillItem
    {
        public uint Code = 0;
        public string Name = "Bill";
        public decimal Price = 0M;
        public decimal Qty = 0M;
    }
}
