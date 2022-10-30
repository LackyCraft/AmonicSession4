using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Session4
{
    /// <summary>
    /// Interaction logic for BulletGraph.xaml
    /// </summary>
    public partial class BulletGraph : UserControl
    {

        public BulletGraph()
        {
            InitializeComponent();
        }

        public void UpdateGraph(List<double> widths)
        {
            

            Column1.Width = new GridLength(widths[0],GridUnitType.Star);
            Column2.Width = new GridLength(widths[1], GridUnitType.Star);
            Column3.Width = new GridLength(widths[2], GridUnitType.Star);
            Column4.Width = new GridLength(widths[3], GridUnitType.Star);
            Column5.Width = new GridLength(widths[4], GridUnitType.Star);
            Column6.Width = new GridLength(widths[5], GridUnitType.Star);
            Column7.Width = new GridLength(widths[6], GridUnitType.Star);

            InitializeComponent();
        }
    }
}
