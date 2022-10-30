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
using System.Windows.Shapes;

namespace Session4
{
    /// <summary>
    /// Interaction logic for DetailedResultsWindow.xaml
    /// </summary>
    public partial class DetailedResultsWindow : Window
    {
        private List<Surveys> _SurveyList;

        private List<Surveys> _FilteredSurveyList;

        public DetailedResultsWindow(List<Surveys> surveyList)
        {
            InitializeComponent();
            _SurveyList = surveyList;
           
            List<string> DateList= surveyList.Select(s => s.Date.ToString("Y",CultureInfo.InvariantCulture)).Distinct().ToList();
            DateList.Insert(0, "Any Date");
            DateComboBox.ItemsSource = DateList;
            

        }

        private void DateComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string SelectedDate = e.AddedItems[0].ToString();

            if(SelectedDate == "Any Date")
            {
                _FilteredSurveyList = _SurveyList;
                return;
            }


            _FilteredSurveyList = _SurveyList.Where(s => s.Date.ToString("Y", CultureInfo.InvariantCulture) == SelectedDate).ToList();

        }




        //Try to get all counts with FOR loop

    }
}
