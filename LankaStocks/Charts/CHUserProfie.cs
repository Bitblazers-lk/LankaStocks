using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;


namespace LankaStocks.Charts
{
    public partial class CHUserProfie : UserControl
    {
        public CHUserProfie()
        {
            InitializeComponent();
            cartesianChart1.Series = new SeriesCollection();
        }
        public List<LineSeries> lineSeries = new List<LineSeries>();

        public void Draw(Dictionary<string, List<double>> data, List<string> dates)
        {
            cartesianChart1.AxisX.Add(new Axis
            {
                Labels = dates,
                Separator = new Separator // force the separator step to 1, so it always display all labels
                {
                    Step = 1,
                    IsEnabled = true //disable it to make it invisible.
                },
                LabelsRotation = 89
            });

            cartesianChart1.Series.Clear();
            foreach (var s in data)
            {
                CheckBox cb = new CheckBox
                {
                    Dock = DockStyle.Left,
                    Text = s.Key,
                    Name = s.Key
                };
                cb.CheckStateChanged += CB_Change;
                var d = new ChartValues<double>();
                d.AddRange(s.Value);
                var LineS = new LineSeries { Values = d, Name = s.Key, Title = s.Key, PointGeometrySize = 20, StrokeThickness = 3 };
                if (LineS.Visibility == Visibility.Visible)
                    cb.Checked = true;
                else if (LineS.Visibility == Visibility.Hidden)
                    cb.Checked = false;
                cartesianChart1.Series.Add(LineS);
                panel1.Controls.Add(cb);
            }
        }

        private void CB_Change(object sender, EventArgs e)
        {
            foreach (var s in cartesianChart1.Series)
            {
                if (s is LineSeries L)
                {
                    foreach (Control c in panel1.Controls)
                    {
                        if (c is CheckBox cb)
                        {
                            if (cb.Name == L.Name)
                            {
                                if (cb.Checked) L.Visibility = Visibility.Visible;
                                else L.Visibility = Visibility.Hidden;
                            }
                        }
                    }
                }
            }
        }
    }
}
