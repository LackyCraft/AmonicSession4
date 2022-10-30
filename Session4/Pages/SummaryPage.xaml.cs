using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for SummaryPage.xaml
    /// </summary>
    public partial class SummaryPage : Page
    {

        List<Surveys> SurveyList;

        public SurveySummary Summary { get; set; }

        public SummaryPage(SurveySummary summary, List<Surveys> surveyList)
        {
            InitializeComponent();

            SurveyList = surveyList;
            Summary = summary;

            string FirstMonth = SurveyList.First().Date.ToString("Y", CultureInfo.InvariantCulture);
            string LastMonth = SurveyList.Last().Date.ToString("Y", CultureInfo.InvariantCulture);
            FieldworkTextBlock.Text = $"Fieldword: {FirstMonth} - {LastMonth}";

            

            DataContext = Summary;


        }


       


    }
}
