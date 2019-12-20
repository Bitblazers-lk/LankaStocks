using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LankaStocks.UIHandle
{
    class PanelMenu
    {
        private readonly int _min = 0;
        private readonly int _max = 0;

        private readonly Control _Parent;
        private readonly Control _Button = null;

        public PanelMenu(Control Parent, Control Button, int Min, int Max)
        {
            _Parent = Parent;
            _Button = Button;
            _min = Min;
            _max = Max;
            Parent.Disposed += Parent_Disposing;
            //foreach (Control s in _Parent.Controls)
            //{
            //    s.MouseMove += Other_Click;
            //    s.MouseLeave += S_MouseLeave;
            //}

            if (_Button != null) _Button.Click += Button_Click;
        }

        private void MouseLeave(object sender, EventArgs e)
        {
            //Point Mp = Cursor.Position;
            //Point Cp = _Parent.PointToScreen(_Parent.Location);

            //Debug.WriteLine($"c{Cp}    m{Mp}");

            //if ((Cp.Y < Mp.Y && Cp.Y + _Parent.Height > Mp.Y) || (Cp.X < Mp.X && Cp.X + _Parent.Width > Mp.X))
            //{

            //}
            //else
            //{
            //    run = true;
            //}
        }

        private void Other_Click(object sender, MouseEventArgs e)
        {
            //Point Mp = Cursor.Position;
            //Point Cp = _Parent.PointToScreen(_Parent.Location);

            //Debug.WriteLine($"c{Cp}    m{Mp}");

            //if ((Cp.Y < Mp.Y && Cp.Y + _Parent.Height > Mp.Y) || (Cp.X < Mp.X && Cp.X + _Parent.Width > Mp.X))
            //{
            //    if (run)
            //    {
            //        if (_Parent.Width == _min) _Parent.Width = _max;
            //    }
            //}
            //else
            //{
            //    if (_Parent.Width == _max)
            //    {
            //        _Parent.Width = _min;
            //        run = true;
            //    }
            //}
        }

        private void Parent_Disposing(object sender, EventArgs e)
        {
            foreach (Control s in _Parent.Controls) s.MouseMove -= Other_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (_Parent.Width == _max) _Parent.Width = _min;
            else if (_Parent.Width == _min) _Parent.Width = _max;
        }
    }
}
