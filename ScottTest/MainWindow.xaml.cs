using ScottPlot;
using ScottPlot.Plottable;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScottTest
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        HLineVector hlines = new ScottPlot.Plottable.HLineVector();
        public MainWindow()
        {
            InitializeComponent();
            scottSetting();
        }

        private void scottSetting()
        {

            Random rand = new Random(0);
            double[] xs = DataGen.Random(rand, 50);
            double[] ys = DataGen.Random(rand, 50);

            var scatter = wScott.Plot.AddScatterPoints(xs, ys, Color.Blue, 10);

            
            hlines.Ys = new double[] { ys[1], ys[12], ys[35] };
            hlines.Color = Color.DarkCyan;
            hlines.PositionLabel = true;
            hlines.PositionLabelBackground = hlines.Color;
            hlines.DragEnabled = true;
            hlines.Dragged += Hlines_Dragged;

            double hlinePosition = hlines.Ys[0];

            wScott.Plot.Add(scatter);
            wScott.Plot.Add(hlines);


            wScott.Refresh();

        }

        private void Hlines_Dragged(object sender, EventArgs e)
        {
            double hlinePosition = hlines.Ys[0];
            mainT.Text = hlinePosition.ToString();
        }
    }
}
