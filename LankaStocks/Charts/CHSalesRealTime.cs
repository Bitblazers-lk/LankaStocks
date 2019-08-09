using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;

namespace LankaStocks.Charts
{
    public partial class CHSalesRealTime : UserControl
    {
        public CHSalesRealTime(int Delay, string _Name, bool RefSale = false)
        {
            InitializeComponent();
            _delay = Delay;
            var mapper = Mappers.Xy<CHSalesRealTime_Data>().X(model => model.Time.Ticks).Y(model => model.Sale);

            Charting.For<CHSalesRealTime_Data>(mapper);

            ChartValues = new ChartValues<CHSalesRealTime_Data>();
            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Values = ChartValues,
                    Title =_Name,
                    PointGeometrySize = 18,
                    StrokeThickness = 4
                }
            };
            cartesianChart1.AxisX.Add(new Axis
            {
                DisableAnimations = true,
                LabelFormatter = value => new System.DateTime((long)value).ToString("hh:mm:ss"),
                Separator = new Separator
                {
                    Step = TimeSpan.FromSeconds(Delay / 1000).Ticks
                },
                LabelsRotation = 60
            });

            SetAxisLimits(System.DateTime.Now);
            _refSale = RefSale;
            Timer = new Timer
            {
                Interval = Delay
            };
            Timer.Tick += TimerOnTick;
            Timer.Start();

            cm.MenuItems.Add("Play / Pause", new EventHandler(PP_Click));
            cm.MenuItems.Add("Clear Recode's", new EventHandler(ClearRec_Click));
            cartesianChart1.ContextMenu = cm;
        }

        private void ClearRec_Click(object sender, EventArgs e)
        {
            //PreValSale.Clear();
            //PreValTime.Clear();
            //ScrollBar.Maximum = PreValSale.Count - 1;
            //ScrollBar.Value = PreValSale.Count - 1;
        }

        private void PP_Click(object sender, EventArgs e)
        {
            if (cartesianChart1.UpdaterState == UpdaterState.Running) cartesianChart1.UpdaterState = UpdaterState.Paused;
            else if (cartesianChart1.UpdaterState == UpdaterState.Paused) cartesianChart1.UpdaterState = UpdaterState.Running;
        }

        ContextMenu cm = new ContextMenu();


        private int _delay;
        private double _Sale;
        private bool _refSale = false;

        //public List<double> PreValSale = new List<double>();
        //public List<DateTime> PreValTime = new List<DateTime>();

        private ChartValues<CHSalesRealTime_Data> ChartValues { get; set; }
        private Timer Timer { get; set; }

        private void SetAxisLimits(System.DateTime now)
        {
            cartesianChart1.AxisX[0].MaxValue = now.Ticks + TimeSpan.FromSeconds(_delay / 1000).Ticks; // lets force the axis to be 100ms ahead
            cartesianChart1.AxisX[0].MinValue = now.Ticks - TimeSpan.FromSeconds(10 * (_delay / 1000)).Ticks; //we only care about the last 8 seconds
        }
        private void TimerOnTick(object sender, EventArgs eventArgs)
        {
            var now = System.DateTime.Now;
            //PreValSale.Add(_Sale);
            //PreValTime.Add(now);
            //ScrollBar.Maximum = PreValSale.Count - 1;
            //ScrollBar.Value = PreValSale.Count - 1;

            ChartValues.Add(new CHSalesRealTime_Data
            {
                Time = now,
                Sale = _Sale
            });

            if (_refSale) _Sale = 0;

            SetAxisLimits(now);
            if (ChartValues.Count > 12) ChartValues.RemoveAt(0);
        }

        public void Draw(double sale)
        {
            _Sale = sale;
        }

        private class CHSalesRealTime_Data
        {
            public System.DateTime Time { get; set; }
            public double Sale { get; set; }
        }

        private void ScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            //Timer.Enabled = false;
            //ChartValues.Clear();
            //for (int i = ScrollBar.Value + 11; i > ScrollBar.Value; i--)
            //{
            //    if (i > 0)
            //    {
            //        try
            //        {
            //            ChartValues.Add(new CHSalesRealTime_Data
            //            {
            //                Time = PreValTime[i],
            //                Sale = PreValSale[i]
            //            });
            //        }
            //        catch { }
            //    }
            //}
        }
    }
}
