using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Session4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Surveys> SurveyList;

        SurveySummary Summary { get; set; }

        

        public MainWindow()
        {
            InitializeComponent();

            Session4Entities entities = new Session4Entities();

            SurveyList = entities.Surveys.ToList();            

            Summary = new SurveySummary
            {
                RecordAmount = SurveyList.Count(),
                MaleAmount = SurveyList.Where(s => s.gender == "M").Count(),
                FemaleAmount = SurveyList.Where(s => s.gender == "F").Count(),
                AgeGroup1Amount = SurveyList.Where(s => s.age >= 18 && s.age <= 24).Count(),
                AgeGroup2Amount = SurveyList.Where(s => s.age >= 25 && s.age <= 39).Count(),
                AgeGroup3Amount = SurveyList.Where(s => s.age >= 40 && s.age <= 59).Count(),
                AgeGroup4Amount = SurveyList.Where(s => s.age >= 60).Count(),
                EconomyCabinAmount = SurveyList.Where(s => s.cabin_type == "Economy").Count(),
                BusinessCabinAmount = SurveyList.Where(s => s.cabin_type == "Business").Count(),
                FirstCabinAmount = SurveyList.Where(s => s.cabin_type == "First").Count(),
                AuhAmount = SurveyList.Where(s => s.arrival == "AUH").Count(),
                BahAmount = SurveyList.Where(s => s.arrival == "BAH").Count(),
                DohAmount = SurveyList.Where(s => s.arrival == "DOH").Count(),
                RuhAmount = SurveyList.Where(s => s.arrival == "RUH").Count(),
                CaiAmount = SurveyList.Where(s => s.arrival == "CAI").Count(),


            };

            DataContext = Summary;


            MainFrame.Content = new SummaryPage(Summary,SurveyList);

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DetailedResultsButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new DetailedResultsPage(SurveyList);
            this.Width = 1300;
            this.Height = 900;

            

        }

        private void SummaryButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new SummaryPage(Summary, SurveyList));
            this.Width = 1000;
            this.Height = 430;
        }
    }


    public class SurveySummary
    {

        public int RecordAmount { get; set; }

        public int MaleAmount { get; set; }

        public int FemaleAmount { get; set; }

        public int AgeGroup1Amount { get; set; }
        public int AgeGroup2Amount { get; set; }
        public int AgeGroup3Amount { get; set; }
        public int AgeGroup4Amount { get; set; }

        public int EconomyCabinAmount { get; set; }
        public int BusinessCabinAmount { get; set; }
        public int FirstCabinAmount { get; set; }

        public int AuhAmount { get; set; }
        public int BahAmount { get; set; }
        public int DohAmount { get; set; }
        public int RuhAmount { get; set; }
        public int CaiAmount { get; set; }


    }

}
