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
        private static readonly Font fonts = new Font("Arial", 12);
        private static readonly SolidBrush BlackBrush = new SolidBrush(Color.Black);

        private static Graphics g;
        private static Bitmap b;

        private static readonly int Width = 210 * 5;
        private static readonly int Height = 297 * 5;

        private static readonly PictureBox pb = new PictureBox();

        private static readonly float Y = 125;
        public static int Margin = 50;
        public static float Loc = 50;

        public static string HeadTag = "LankaStocks Sales";
        public static string Tag = "...LankaStocks...";

        public static List<Image> DrawTable(string _Name, List<IM_Data> _data)
        {
            List<Image> OUT = new List<Image>();
            List<IM_Data> temp = new List<IM_Data>();
            int pgCount = _data.Count / 45;
            int thisIn = 0;
            if (_data.Count % 45 > 0)
            {
                pgCount += 1;
            }

            for (int i = 0; i < pgCount; i++)
            {
                int c;
                if (_data.Count - thisIn < 45)
                {
                    c = _data.Count - thisIn;
                }
                else
                {
                    c = 45;
                }
                for (int a = 0; a < c; a++)
                {
                    temp.Add(_data[thisIn + a]);
                }
                OUT.Add(Draw(_Name, temp, i.ToString()));
                thisIn += 45;
            }

            return OUT;
        }

        public static Image Draw(string Name, List<IM_Data> data, string Pno)
        {
            float _Y = Y;
            int _Margin = Margin;
            string Pgno = Pno;
            pb.Image = new Bitmap(Width, Height);
            b = new Bitmap(pb.Image);
            g = Graphics.FromImage(b);

            g.DrawImage(GDI.Properties.Resources.ba, 0, 0, Width, Height);
            float _Loc = _Y;

            int iCount = data.Count; //45
            var percen = new List<uint> { 110, 203, 296, 390, 483, 576, 670, 763 };

            g.DrawString(HeadTag, Fonthead, BlackBrush, (Width - g.MeasureString(HeadTag, Fonthead).Width) / 2, 30); //  Head Tag
            g.DrawString($"Item Name : {Name}", fonts, BlackBrush, 10 + _Margin, 100);  //  In


            g.DrawString($"Date", fonts, BlackBrush, ((110 - g.MeasureString($"Date", fonts).Width) / 2) + _Margin, _Y + ((60 - g.MeasureString($"Date", fonts).Height) / 2)); //  Date
            g.DrawString($"Incoming", fonts, BlackBrush, ((280 - g.MeasureString($"Incoming", fonts).Width) / 2) + _Margin + 110, _Y + 7);  //  In
            g.DrawString($"Outgoing", fonts, BlackBrush, ((280 - g.MeasureString($"Outgoing", fonts).Width) / 2) + _Margin + 390, _Y + 7); //  Out
            g.DrawString($"Balance", fonts, BlackBrush, ((280 - g.MeasureString($"Balance", fonts).Width) / 2) + _Margin + 670, _Y + 7);   //  Balance
            g.DrawLine(new Pen(BlackBrush, 1), _Margin, _Loc, Width - _Margin, _Loc);        //   horizontal
            _Loc += 30;
            g.DrawLine(new Pen(BlackBrush, 1), _Margin + 110, _Loc, Width - _Margin, _Loc);        //   horizontal

            g.DrawString($"Qty.", fonts, BlackBrush, ((93 - g.MeasureString($"Qty.", fonts).Width) / 2) + _Margin + 110, _Loc + 7);    //  Qty    IN
            g.DrawString($"Price", fonts, BlackBrush, ((93 - g.MeasureString($"Price", fonts).Width) / 2) + _Margin + 203, _Loc + 7);  //  Pri    IN
            g.DrawString($"Value", fonts, BlackBrush, ((94 - g.MeasureString($"Value", fonts).Width) / 2) + _Margin + 296, _Loc + 7);  //  Val    IN

            g.DrawString($"Qty.", fonts, BlackBrush, ((93 - g.MeasureString($"Qty.", fonts).Width) / 2) + _Margin + 390, _Loc + 7);    //  Qty    OUT
            g.DrawString($"Price", fonts, BlackBrush, ((93 - g.MeasureString($"Price", fonts).Width) / 2) + _Margin + 483, _Loc + 7);  //  Pri    OUT
            g.DrawString($"Value", fonts, BlackBrush, ((94 - g.MeasureString($"Value", fonts).Width) / 2) + _Margin + 576, _Loc + 7);  //  Val    OUT

            g.DrawString($"Qty.", fonts, BlackBrush, ((93 - g.MeasureString($"Qty.", fonts).Width) / 2) + _Margin + 670, _Loc + 7);    //  Qty    BAL
            g.DrawString($"Value", fonts, BlackBrush, ((187 - g.MeasureString($"Value", fonts).Width) / 2) + _Margin + 763, _Loc + 7); //  Val    BAL

            _Loc += 30;
            g.DrawLine(new Pen(BlackBrush, 1), _Margin, _Y, _Margin, _Loc);                  //   Vertical Left Side
            g.DrawLine(new Pen(BlackBrush, 1), _Margin + 110, _Y, _Margin + 110, _Loc);        //   Vertical
            g.DrawLine(new Pen(BlackBrush, 1), _Margin + 390, _Y, _Margin + 390, _Loc);      //   Vertical
            g.DrawLine(new Pen(BlackBrush, 1), _Margin + 670, _Y, _Margin + 670, _Loc);      //   Vertical
            g.DrawLine(new Pen(BlackBrush, 1), _Margin + 950, _Y, _Margin + 950, _Loc);      //   Vertical
            g.DrawLine(new Pen(BlackBrush, 1), Width - _Margin, _Y, Width - _Margin, _Loc);  //   Vertical Right Side

            g.DrawLine(new Pen(BlackBrush, 1), _Margin + 203, _Y + 30, _Margin + 203, _Loc);      //   Vertical
            g.DrawLine(new Pen(BlackBrush, 1), _Margin + 296, _Y + 30, _Margin + 296, _Loc);      //   Vertical

            g.DrawLine(new Pen(BlackBrush, 1), _Margin + 483, _Y + 30, _Margin + 483, _Loc);      //   Vertical
            g.DrawLine(new Pen(BlackBrush, 1), _Margin + 576, _Y + 30, _Margin + 576, _Loc);      //   Vertical

            g.DrawLine(new Pen(BlackBrush, 1), _Margin + 763, _Y + 30, _Margin + 763, _Loc);      //   Vertical

            _Y = _Loc;
            g.DrawLine(new Pen(BlackBrush, 1), _Margin, _Loc, Width - _Margin, _Loc);        //   horizontal
            for (int rows = 0; rows < iCount; rows++)
            {
                var S = data[rows];

                g.DrawString($"{S.Date}", fonts, BlackBrush, ((110 - g.MeasureString($"{S.Date}", fonts).Width) / 2) + _Margin, _Loc + 4); //  Date

                g.DrawString($"{S.IN_qty}", fonts, BlackBrush, 5 + _Margin + 110, _Loc + 4);                  //  Qty      IN
                g.DrawString($"{S.IN_price}", fonts, BlackBrush, 5 + _Margin + 203, _Loc + 4);                //  Pri      IN
                g.DrawString($"{S.IN_qty * S.IN_price}", fonts, BlackBrush, 5 + _Margin + 296, _Loc + 4);     //  Val      IN

                g.DrawString($"{S.OUT_qty}.", fonts, BlackBrush, 5 + _Margin + 390, _Loc + 4);                //  Qty      OUT
                g.DrawString($"{S.OUT_price}", fonts, BlackBrush, 5 + _Margin + 483, _Loc + 4);               //  Pri      OUT
                g.DrawString($"{S.OUT_qty * S.OUT_price}", fonts, BlackBrush, 2 + _Margin + 576, _Loc + 4);   //  Val      OUT

                g.DrawString($"{S.BAL_qty}", fonts, BlackBrush, 5 + _Margin + 670, _Loc + 4);                 //  Qty      BAL
                g.DrawString($"{S.BAL_qty * S.OUT_price}", fonts, BlackBrush, 5 + _Margin + 763, _Loc + 4);   //  Val      BAL

                _Loc += fonts.Height + 8;

                for (int columns = 0; columns < percen.Count; columns++)
                {
                    g.DrawLine(new Pen(BlackBrush, 1), _Margin + percen[columns], _Y, _Margin + percen[columns], _Loc);  //   Vertival
                }

                g.DrawLine(new Pen(BlackBrush, 1), _Margin, _Y, _Margin, _Loc);                  //   Vertival Left Side
                g.DrawLine(new Pen(BlackBrush, 1), Width - _Margin, _Y, Width - _Margin, _Loc);  //   Vertival Right Side
                g.DrawLine(new Pen(BlackBrush, 1), _Margin, _Loc, Width - _Margin, _Loc);        //   horizontal
            }
            g.DrawLine(new Pen(BlackBrush, 1), _Margin, Height - 65, Width - _Margin, Height - 65);        //   horizontal
            g.DrawString(Pgno, fonts, BlackBrush, Width - _Margin - g.MeasureString(Pgno, fonts).Width, Height - 55); //  Page NO
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
        public decimal IN_qty;
        public decimal IN_price;
        public decimal OUT_qty;
        public decimal OUT_price;
        public decimal BAL_qty;
    }


    public class Drawing
    {
        private static readonly Font Fonthead = new Font("Arial", 26);
        private static readonly Font fonts = new Font("Arial", 12);
        private static readonly SolidBrush BlackBrush = new SolidBrush(Color.Black);

        private static Graphics g;
        private static Bitmap b;

        private static readonly int Width = 210 * 5;
        private static readonly int Height = 297 * 5;

        private static readonly PictureBox pb = new PictureBox();

        private static readonly float Y = 100;
        public static int Margin = 50;
        public static float Loc = 50;

        public static string HeadTag = "LankaStocks Sales";
        public static string Tag = "...LankaStocks...";

        public static List<Image> DrawTable(string _Name, List<IM1_Data> _data)
        {
            List<Image> OUT = new List<Image>();
            List<IM1_Data> temp = new List<IM1_Data>();
            int pgCount = _data.Count / 45;
            int thisIn = 0;
            if (_data.Count % 45 > 0)
            {
                pgCount += 1;
            }

            bool ap = false;
            for (int i = 0; i < pgCount; i++)
            {
                int c;
                if (_data.Count - thisIn < 45)
                {
                    c = _data.Count - thisIn;
                }
                else
                {
                    c = 45;
                }
                for (int a = 0; a < c; a++)
                {
                    temp.Add(_data[thisIn + a]);
                }
                if (pgCount > i) ap = true;
                OUT.Add(Draw(temp, i.ToString(), ap));
                ap = false;
                thisIn += 45;
            }

            return OUT;
        }

        public static Image Draw(List<IM1_Data> data, string Pgno, bool append = false)
        {
            float _Y = Y;
            int _Margin = Margin;
            float _Loc = Loc;
            pb.Image = new Bitmap(Width, Height);
            b = new Bitmap(pb.Image);
            g = Graphics.FromImage(b);

            g.DrawImage(GDI.Properties.Resources.ba, 0, 0, Width, Height);
            _Loc = _Y;

            int iCount = data.Count;
            var percen = new List<uint> { 110, 750 };

            g.DrawString(HeadTag, Fonthead, BlackBrush, (Width - g.MeasureString(HeadTag, Fonthead).Width) / 2, 30); //  Head Tag

            g.DrawString($"Date", fonts, BlackBrush, ((110 - g.MeasureString($"Date", fonts).Width) / 2) + _Margin, _Y + ((60 - g.MeasureString($"Date", fonts).Height) / 2)); //  Date
            g.DrawString($"Item Name", fonts, BlackBrush, ((640 - g.MeasureString($"Item Name", fonts).Width) / 2) + _Margin + 110, _Y + ((60 - g.MeasureString($"Date", fonts).Height) / 2)); //  Name
            g.DrawString($"Value", fonts, BlackBrush, ((200 - g.MeasureString($"Value", fonts).Width) / 2) + _Margin + 750, _Y + ((60 - g.MeasureString($"Date", fonts).Height) / 2)); //  Name
            g.DrawLine(new Pen(BlackBrush, 1), _Margin, _Loc, Width - _Margin, _Loc);        //   horizontal
            _Loc += 60;
            g.DrawLine(new Pen(BlackBrush, 1), _Margin, _Y, _Margin, _Loc);                  //   Vertival Left Side
            g.DrawLine(new Pen(BlackBrush, 1), _Margin + 110, _Y, _Margin + 110, _Loc);        //   Vertical
            g.DrawLine(new Pen(BlackBrush, 1), _Margin + 750, _Y, _Margin + 750, _Loc);        //   Vertical
            g.DrawLine(new Pen(BlackBrush, 1), Width - _Margin, _Y, Width - _Margin, _Loc);  //   Vertival Right Side

            g.DrawLine(new Pen(BlackBrush, 1), _Margin, _Loc, Width - _Margin, _Loc);        //   horizontal
            _Y = _Loc;
            decimal tot = 0;
            for (int rows = 0; rows < iCount; rows++)
            {
                var S = data[rows];
                tot += S.Value;
                g.DrawString($"{S.Date}", fonts, BlackBrush, ((110 - g.MeasureString($"{S.Date}", fonts).Width) / 2) + _Margin, _Loc + 4); //  Date
                g.DrawString($"{S.Name}", fonts, BlackBrush, 110 + _Margin + 4, _Loc + 4); //  Name
                g.DrawString($"{S.Value.ToString("0.00")}", fonts, BlackBrush, 750 + _Margin + 4, _Loc + 4); //  Name

                _Loc += fonts.Height + 8;
                for (int columns = 0; columns < percen.Count; columns++)
                {
                    g.DrawLine(new Pen(BlackBrush, 1), _Margin + percen[columns], _Y, _Margin + percen[columns], _Loc);  //   Vertival
                }
                g.DrawLine(new Pen(BlackBrush, 1), _Margin, _Y, _Margin, _Loc);                  //   Vertival Left Side
                g.DrawLine(new Pen(BlackBrush, 1), Width - _Margin, _Y, Width - _Margin, _Loc);  //   Vertival Right Side
                g.DrawLine(new Pen(BlackBrush, 1), _Margin, _Loc, Width - _Margin, _Loc);        //   horizontal
            }
            if (!append)
            {
                g.DrawString($"Total", fonts, BlackBrush, ((50 - g.MeasureString($"Total", fonts).Width) / 2) + _Margin + 700, _Loc + 4);
                g.DrawString($"{tot.ToString("0.00")}", fonts, BlackBrush, 750 + _Margin + 4, _Loc + 4); //  Name
                _Loc += fonts.Height + 8;
                g.DrawLine(new Pen(BlackBrush, 1), Width - _Margin, _Y, Width - _Margin, _Loc);  //   Vertival Right Side
                g.DrawLine(new Pen(BlackBrush, 1), _Margin + 750, _Y, _Margin + 750, _Loc);        //   Vertical
                g.DrawLine(new Pen(BlackBrush, 1), 800, _Loc, Width - _Margin, _Loc);        //   horizontal
            }

            g.DrawLine(new Pen(BlackBrush, 1), _Margin, Height - 65, Width - _Margin, Height - 65);        //   horizontal
            g.DrawString(Pgno, fonts, BlackBrush, Width - _Margin - g.MeasureString(Pgno, fonts).Width, Height - 55); //  Page NO
            g.DrawString(Tag, fonts, BlackBrush, (Width - g.MeasureString(Tag, fonts).Width) / 2, Height - 55); //  Tag
            Console.WriteLine(_Y);
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

    public struct IM1_Data
    {
        public string Date;
        public string Name;
        public decimal Value;
    }
}
