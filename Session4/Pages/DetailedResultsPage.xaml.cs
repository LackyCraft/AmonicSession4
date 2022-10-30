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
    /// Interaction logic for DetailedResultsPage.xaml
    /// </summary>
    public partial class DetailedResultsPage : Page
    {
        private List<Surveys> _SurveyList;

        private List<Surveys> _FilteredSurveyList;

        private Func<Surveys, bool> GenderFilter = s => true;

        private Func<Surveys, bool> AgeFilter = s => true;

        private Func<Surveys, bool> DateFilter = s => true;


        public DetailedResultsPage(List<Surveys> surveyList)
        {
            InitializeComponent();

            _SurveyList = surveyList;
            _FilteredSurveyList = _SurveyList;

            List<string> DateList = surveyList.Select(s => s.Date.ToString("Y", CultureInfo.InvariantCulture)).Distinct().ToList();
            DateList.Insert(0, "Any Date");
            DateComboBox.ItemsSource = DateList;

            List<string> GenderList = new List<string> { "M","F" };
            GenderList.Insert(0, "Any Gender");
            GenderComboBox.ItemsSource = GenderList;
            

            List<string> AgeList = new List<string> { "All ages", "18-24", "25-39", "40-59", "60+" };
            AgeComboBox.ItemsSource = AgeList;

            UpdateGraphs();
            SelectResults();


        }


        private void UpdateGraphs()
        {
            int TotalAnswers = _FilteredSurveyList.Where(s => s.q1 != 0).Count();
            List<double> Widths = new List<double>();
            for (int i = 0; i < 7; i++)
            {
                Widths.Add((double)((double)_FilteredSurveyList.Where(s => s.q1 == (i + 1)).Count() / (double)TotalAnswers));
            }
            Widths.Reverse();
            Q1Graph.UpdateGraph(Widths);

            //????
            TotalAnswers = _FilteredSurveyList.Where(s => s.q2 != 0).Count();
            Widths.Clear();
            for (int i = 0; i < 7; i++)
            {
                Widths.Add((double)((double)_FilteredSurveyList.Where(s => s.q2 == (i + 1)).Count() / (double)TotalAnswers));
            }
            Widths.Reverse();
            Q2Graph.UpdateGraph(Widths);

            TotalAnswers = _FilteredSurveyList.Where(s => s.q3 != 0).Count();
            Widths.Clear();
            for (int i = 0; i < 7; i++)
            {
                Widths.Add((double)((double)_FilteredSurveyList.Where(s => s.q3 == (i + 1)).Count() / (double)TotalAnswers));
            }
            Widths.Reverse();
            Q3Graph.UpdateGraph(Widths);

            TotalAnswers = _FilteredSurveyList.Where(s => s.q4 != 0).Count();
            Widths.Clear();
            for (int i = 0; i < 7; i++)
            {
                Widths.Add((double)((double)_FilteredSurveyList.Where(s => s.q4 == (i + 1)).Count() / (double)TotalAnswers));
            }
            Widths.Reverse();
            Q4Graph.UpdateGraph(Widths);

        }

        private void SelectResults()
        {
            Q1StackPanel.Children.Clear();
            Q2StackPanel.Children.Clear();
            Q3StackPanel.Children.Clear();
            Q4StackPanel.Children.Clear();


            for (int i = 0; i < 7; i++)
            {

                SolidColorBrush RowBackground;

                RowBackground = i % 2 == 0 ? Brushes.LightBlue : Brushes.LightGray;


                Q1StackPanel.Children.Add(new SurveyResultRow(RowBackground, "", _FilteredSurveyList.Where(s => s.q1 == (i + 1)).Count(),
                    _FilteredSurveyList.Where(s => s.q1 == (i + 1) && s.gender == "M").Count(),
                    _FilteredSurveyList.Where(s => s.q1 == (i + 1) && s.gender == "F").Count(),
                    _FilteredSurveyList.Where(s => s.q1 == (i + 1) && s.age >= 18 && s.age <= 24).Count(),
                    _FilteredSurveyList.Where(s => s.q1 == (i + 1) && s.age >= 25 && s.age <= 39).Count(),
                    _FilteredSurveyList.Where(s => s.q1 == (i + 1) && s.age >= 40 && s.age <= 59).Count(),
                    _FilteredSurveyList.Where(s => s.q1 == (i + 1) && s.age >= 60).Count(),
                    _FilteredSurveyList.Where(s => s.q1 == (i + 1) && s.cabin_type == "Economy").Count(),
                    _FilteredSurveyList.Where(s => s.q1 == (i + 1) && s.cabin_type == "Business").Count(),
                    _FilteredSurveyList.Where(s => s.q1 == (i + 1) && s.cabin_type == "First").Count(),
                    _FilteredSurveyList.Where(s => s.q1 == (i + 1) && s.arrival == "AUH").Count(),
                    _FilteredSurveyList.Where(s => s.q1 == (i + 1) && s.arrival == "BAH").Count(),
                    _FilteredSurveyList.Where(s => s.q1 == (i + 1) && s.arrival == "DOH").Count(),
                    _FilteredSurveyList.Where(s => s.q1 == (i + 1) && s.arrival == "RUH").Count(),
                    _FilteredSurveyList.Where(s => s.q1 == (i + 1) && s.arrival == "CAI").Count()));
            }


            //??????
            for (int i = 0; i < 7; i++)
            {

                SolidColorBrush RowBackground;

                RowBackground = i % 2 == 0 ? Brushes.LightBlue : Brushes.LightGray;


                Q2StackPanel.Children.Add(new SurveyResultRow(RowBackground, "", _FilteredSurveyList.Where(s => s.q2 == (i + 1)).Count(),
                    _FilteredSurveyList.Where(s => s.q2 == (i + 1) && s.gender == "M").Count(),
                    _FilteredSurveyList.Where(s => s.q2 == (i + 1) && s.gender == "F").Count(),
                    _FilteredSurveyList.Where(s => s.q2 == (i + 1) && s.age >= 18 && s.age <= 24).Count(),
                    _FilteredSurveyList.Where(s => s.q2 == (i + 1) && s.age >= 25 && s.age <= 39).Count(),
                    _FilteredSurveyList.Where(s => s.q2 == (i + 1) && s.age >= 40 && s.age <= 59).Count(),
                    _FilteredSurveyList.Where(s => s.q2 == (i + 1) && s.age >= 60).Count(),
                    _FilteredSurveyList.Where(s => s.q2 == (i + 1) && s.cabin_type == "Economy").Count(),
                    _FilteredSurveyList.Where(s => s.q2 == (i + 1) && s.cabin_type == "Business").Count(),
                    _FilteredSurveyList.Where(s => s.q2 == (i + 1) && s.cabin_type == "First").Count(),
                    _FilteredSurveyList.Where(s => s.q2 == (i + 1) && s.arrival == "AUH").Count(),
                    _FilteredSurveyList.Where(s => s.q2 == (i + 1) && s.arrival == "BAH").Count(),
                    _FilteredSurveyList.Where(s => s.q2 == (i + 1) && s.arrival == "DOH").Count(),
                    _FilteredSurveyList.Where(s => s.q2 == (i + 1) && s.arrival == "RUH").Count(),
                    _FilteredSurveyList.Where(s => s.q2 == (i + 1) && s.arrival == "CAI").Count()));
            }


            for (int i = 0; i < 7; i++)
            {

                SolidColorBrush RowBackground;

                RowBackground = i % 2 == 0 ? Brushes.LightBlue : Brushes.LightGray;


                Q3StackPanel.Children.Add(new SurveyResultRow(RowBackground, "", _FilteredSurveyList.Where(s => s.q3 == (i + 1)).Count(),
                    _FilteredSurveyList.Where(s => s.q3 == (i + 1) && s.gender == "M").Count(),
                    _FilteredSurveyList.Where(s => s.q3 == (i + 1) && s.gender == "F").Count(),
                    _FilteredSurveyList.Where(s => s.q3 == (i + 1) && s.age >= 18 && s.age <= 24).Count(),
                    _FilteredSurveyList.Where(s => s.q3 == (i + 1) && s.age >= 25 && s.age <= 39).Count(),
                    _FilteredSurveyList.Where(s => s.q3 == (i + 1) && s.age >= 40 && s.age <= 59).Count(),
                    _FilteredSurveyList.Where(s => s.q3 == (i + 1) && s.age >= 60).Count(),
                    _FilteredSurveyList.Where(s => s.q3 == (i + 1) && s.cabin_type == "Economy").Count(),
                    _FilteredSurveyList.Where(s => s.q3 == (i + 1) && s.cabin_type == "Business").Count(),
                    _FilteredSurveyList.Where(s => s.q3 == (i + 1) && s.cabin_type == "First").Count(),
                    _FilteredSurveyList.Where(s => s.q3 == (i + 1) && s.arrival == "AUH").Count(),
                    _FilteredSurveyList.Where(s => s.q3 == (i + 1) && s.arrival == "BAH").Count(),
                    _FilteredSurveyList.Where(s => s.q3 == (i + 1) && s.arrival == "DOH").Count(),
                    _FilteredSurveyList.Where(s => s.q3 == (i + 1) && s.arrival == "RUH").Count(),
                    _FilteredSurveyList.Where(s => s.q3 == (i + 1) && s.arrival == "CAI").Count()));
            }


            for (int i = 0; i < 7; i++)
            {

                SolidColorBrush RowBackground;

                RowBackground = i % 2 == 0 ? Brushes.LightBlue : Brushes.LightGray;


                Q4StackPanel.Children.Add(new SurveyResultRow(RowBackground, "", _FilteredSurveyList.Where(s => s.q4 == (i + 1)).Count(),
                    _FilteredSurveyList.Where(s => s.q4 == (i + 1) && s.gender == "M").Count(),
                    _FilteredSurveyList.Where(s => s.q4 == (i + 1) && s.gender == "F").Count(),
                    _FilteredSurveyList.Where(s => s.q4 == (i + 1) && s.age >= 18 && s.age <= 24).Count(),
                    _FilteredSurveyList.Where(s => s.q4 == (i + 1) && s.age >= 25 && s.age <= 39).Count(),
                    _FilteredSurveyList.Where(s => s.q4 == (i + 1) && s.age >= 40 && s.age <= 59).Count(),
                    _FilteredSurveyList.Where(s => s.q4 == (i + 1) && s.age >= 60).Count(),
                    _FilteredSurveyList.Where(s => s.q4 == (i + 1) && s.cabin_type == "Economy").Count(),
                    _FilteredSurveyList.Where(s => s.q4 == (i + 1) && s.cabin_type == "Business").Count(),
                    _FilteredSurveyList.Where(s => s.q4 == (i + 1) && s.cabin_type == "First").Count(),
                    _FilteredSurveyList.Where(s => s.q4 == (i + 1) && s.arrival == "AUH").Count(),
                    _FilteredSurveyList.Where(s => s.q4 == (i + 1) && s.arrival == "BAH").Count(),
                    _FilteredSurveyList.Where(s => s.q4 == (i + 1) && s.arrival == "DOH").Count(),
                    _FilteredSurveyList.Where(s => s.q4 == (i + 1) && s.arrival == "RUH").Count(),
                    _FilteredSurveyList.Where(s => s.q4 == (i + 1) && s.arrival == "CAI").Count()));
            }

        }

        private void ApplyFilters()
        {
            _FilteredSurveyList = _SurveyList.Where(DateFilter).Where(AgeFilter).Where(GenderFilter).ToList();

            var test = _SurveyList.Where(DateFilter).ToList();
            var test1 = _SurveyList.Where(AgeFilter).ToList();
            var test2 = _SurveyList.Where(GenderFilter).ToList();

        }


        private void DateComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string SelectedDate = e.AddedItems[0].ToString();

            if (SelectedDate == "Any Date")
            {
                DateFilter = s=> true;
                ApplyFilters();
                SelectResults();
                UpdateGraphs();
                return;
            }


            DateFilter = s => s.Date.ToString("Y", CultureInfo.InvariantCulture) == SelectedDate;
            ApplyFilters();
            SelectResults();
            UpdateGraphs();

        }

        private void GenderCheckBox_Changed(object sender, RoutedEventArgs e)
        {

            MaleColumn.Width = GenderCheckBox.IsChecked == true ? new GridLength(1, GridUnitType.Star) : new GridLength(0);
            FemaleColumn.Width = GenderCheckBox.IsChecked == true ? new GridLength(1, GridUnitType.Star) : new GridLength(0);

            if(GenderComboBox != null)
            {
                GenderComboBox.Visibility = GenderCheckBox.IsChecked == true ? Visibility.Visible : Visibility.Hidden;
                GenderComboBox.SelectedIndex = 0;
            }



        }

        private void AgeCheckBox_Changed(object sender, RoutedEventArgs e)
        {
            AgeGroup1Column.Width = AgeCheckBox.IsChecked == true ? new GridLength(1, GridUnitType.Star) : new GridLength(0);
            AgeGroup2Column.Width = AgeCheckBox.IsChecked == true ? new GridLength(1, GridUnitType.Star) : new GridLength(0);
            AgeGroup3Column.Width = AgeCheckBox.IsChecked == true ? new GridLength(1, GridUnitType.Star) : new GridLength(0);
            AgeGroup4Column.Width = AgeCheckBox.IsChecked == true ? new GridLength(1, GridUnitType.Star) : new GridLength(0);

            if (AgeComboBox != null)
            {
                AgeComboBox.Visibility = AgeCheckBox.IsChecked == true ? Visibility.Visible : Visibility.Hidden;
                AgeComboBox.SelectedIndex = 0;
            }

            

        }

        private void GenderComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.AddedItems[0].ToString() == "Any Gender")
            {
                GenderFilter = s => true;
                MaleColumn.Width = new GridLength(1, GridUnitType.Star);
                FemaleColumn.Width = new GridLength(1, GridUnitType.Star);
            }
            else
            {
                GenderFilter = s => s.gender == e.AddedItems[0].ToString();

                switch (e.AddedItems[0].ToString())
                {
                    case "M":
                        MaleColumn.Width = new GridLength(1, GridUnitType.Star);
                        FemaleColumn.Width = new GridLength(0);
                        break;
                    case "F":
                        MaleColumn.Width = new GridLength(0);
                        FemaleColumn.Width = new GridLength(1, GridUnitType.Star);
                        break;
                }

            }

            ApplyFilters();
            SelectResults();
            UpdateGraphs();

        }

        private void AgeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AgeGroup1Column.Width = new GridLength(0);
            AgeGroup2Column.Width = new GridLength(0);
            AgeGroup3Column.Width = new GridLength(0);
            AgeGroup4Column.Width = new GridLength(0);


            switch (e.AddedItems[0].ToString())
            {
                case "All ages":
                    AgeFilter = s => true;
                    AgeGroup1Column.Width = new GridLength(1, GridUnitType.Star);
                    AgeGroup2Column.Width = new GridLength(1, GridUnitType.Star);
                    AgeGroup3Column.Width = new GridLength(1, GridUnitType.Star);
                    AgeGroup4Column.Width = new GridLength(1, GridUnitType.Star);
                    break;
                case "18-24":
                    AgeFilter = s => s.age >= 18 && s.age <= 24;
                    AgeGroup1Column.Width = new GridLength(1, GridUnitType.Star);
                    break;
                case "25-39":
                    AgeFilter = s => s.age >= 25 && s.age <= 39;
                    AgeGroup2Column.Width = new GridLength(1, GridUnitType.Star);
                    break;
                case "40-59":
                    AgeFilter = s => s.age >= 40 && s.age <= 59;
                    AgeGroup3Column.Width = new GridLength(1, GridUnitType.Star);
                    break;
                case "60+":
                    AgeFilter = s => s.age >= 60;
                    AgeGroup4Column.Width = new GridLength(1, GridUnitType.Star);
                    break;


            }


            ApplyFilters();
            SelectResults();
            UpdateGraphs();

        }
    }
}
