using System;
using System.Windows;

namespace SalaryHomework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var reply = new Reply();
            SalaryInfo salaryInfo;
            if (TryGetSalaryInfo(out salaryInfo,
                txtBoxSalary.Text,
                cmbBoxDistrictCoeff.Text,
                txtBoxWorkedDays.Text,
                txtBoxSpentDays.Text,
                txtBoxPrize.Text))
            {
                reply.fullSalary.Content = salaryInfo.FullSalary.ToString();
                reply.personalTax.Content = salaryInfo.PersonalTax.ToString();
                reply.actualSalary.Content = salaryInfo.ActualSalary.ToString();
                reply.Show();
            }
        }

        private bool TryGetSalaryInfo(out SalaryInfo salaryInfo,
            string salary,
            string districtCoeff,
            string workedDays,
            string spentDays,
            string prize)
        {
            try
            {
                salaryInfo = GetSalaryInfo(salary, districtCoeff, workedDays, spentDays, prize);
            }
            catch (FormatException)
            {
                MessageBox.Show("Incorrect input!");
                salaryInfo = new SalaryInfo();
                return false;
            }
            return true;
        }

        private SalaryInfo GetSalaryInfo(string salary,
            string districtCoeff,
            string workedDays,
            string spentDays,
            string prize)
        {
            return new SalaryInfo(double.Parse(salary),
                double.Parse(districtCoeff) / 100,
                double.Parse(prize),
                int.Parse(workedDays),
                int.Parse(spentDays));
        }
    }
}
