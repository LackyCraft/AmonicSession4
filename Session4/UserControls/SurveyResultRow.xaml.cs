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
    /// Interaction logic for SurveyResultRow.xaml
    /// </summary>
    public partial class SurveyResultRow : UserControl
    {
        public SurveyResultRow()
        {
            InitializeComponent();
        }

        public SurveyResultRow(Brush background, string rowDescription, int total, int male, int female, int agegroup1 , int agegroup2, int agegroup3, int agegroup4 , 
            int economy, int business,int first, int auh,int bah,int doh, int ruh, int cai)
        {
            InitializeComponent();

            MainGrid.Background = background;
            //GradeDescription.Text = rowDescription;

            Column1.Text = total.ToString();
            Column2.Text = male.ToString();
            Column3.Text = female.ToString();
            Column4.Text = agegroup1.ToString();
            Column5.Text = agegroup2.ToString();
            Column6.Text = agegroup3.ToString();
            Column7.Text = agegroup4.ToString();
            Column8.Text = economy.ToString();
            Column9.Text = business.ToString();
            Column10.Text = first.ToString();
            Column11.Text = auh.ToString();
            Column12.Text = bah.ToString();
            Column13.Text = doh.ToString();
            Column14.Text = ruh.ToString();
            Column15.Text = cai.ToString();



            
        }
        


    }
}
