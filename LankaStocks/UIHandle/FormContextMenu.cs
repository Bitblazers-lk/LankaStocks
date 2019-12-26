using System;
using System.Drawing;
using System.Windows.Forms;

namespace LankaStocks.UIHandle
{
    class FormContextMenu
    {
        private readonly Control _ParentC = null;
        public Form _Form = null;
        public bool Alive = false;
        private bool Exit = false;

        readonly MouseHook MouseHook = new MouseHook();

        public FormContextMenu(Control Parent, Form form)
        {
            _ParentC = Parent;
            _Form = form;
            _Form.StartPosition = FormStartPosition.Manual;
            Parent.MouseDown += Form_Click;
            Parent.Disposed += Parent_Disposing;
            MouseHook.SetHook();
            MouseHook.MouseDownEvent += Other_Click;

            foreach (Control s in _ParentC.Parent.Controls)
            {
                SetClick(s);
            }
        }

        private void Parent_Disposing(object sender, EventArgs e)
        {
            MouseHook.UnHook();
        }

        private void Form_Click(object sender, MouseEventArgs e)
        {
            if (_ParentC != null)
            {
                if (e.Button == MouseButtons.Right)
                {
                    Point loc = Cursor.Position;
                    if (loc.Y + _Form.Height > Screen.PrimaryScreen.WorkingArea.Height)
                    {
                        loc.Y = Screen.PrimaryScreen.WorkingArea.Height - _Form.Height;
                    }
                    if (loc.X + _Form.Width > Screen.PrimaryScreen.WorkingArea.Width)
                    {
                        loc.X = Screen.PrimaryScreen.WorkingArea.Width - _Form.Width;
                    }
                    OpenForm(_ParentC, loc);
                    if (!Alive)
                    {
                        _Form.Show();
                        Alive = true;
                    }
                }
                if (e.Button == MouseButtons.Left)
                {
                    if (Alive)
                    {
                        _Form.Hide();
                        Alive = false;
                    }
                }
            }
        }

        public void OpenForm(Control control, Point Location, FormBorderStyle fStyle = FormBorderStyle.None, DockStyle dockStyle = DockStyle.None)
        {
            _Form.Location = Location;
            _Form.FormBorderStyle = fStyle;
            _Form.Dock = dockStyle;
            _Form.BringToFront();
        }

        private void SetClick(Control ctrl)
        {
            //Console.WriteLine(ctrl.Name);
            //try
            //{
            //    ctrl.MouseDown += Other_Click;
            //    foreach (Control s in ctrl.Parent.Controls)
            //    {
            //        SetClick(s);
            //    }
            //}
            //catch
            //{
            //    Console.WriteLine(ctrl.Name);
            //}
        }

        private void Other_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_Form.Location.X > e.X || _Form.Location.X + _Form.Size.Width < e.X || _Form.Location.Y > e.Y || _Form.Location.Y + _Form.Size.Height < e.Y)
                {
                    if (Alive)
                    {
                        _Form.Hide();
                        Alive = false;
                    }
                }
            }
        }
    }
}
