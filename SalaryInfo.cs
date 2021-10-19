using System;

namespace SalaryHomework
{
    class SalaryInfo
    {
        private readonly double salary;
        private readonly double districtCoeff;
        private readonly double prize;
        private readonly int workedDays;
        private readonly int spentDays;

        public double FullSalary => Math.Round((salary * districtCoeff * workedDays / spentDays) + prize, 2);

        public double ActualSalary => Math.Round(FullSalary - PersonalTax, 2);

        public double PersonalTax => Math.Round(FullSalary * 0.13, 2);

        public SalaryInfo() : this(0, 0, 0, 0, 0)
        {

        }

        public SalaryInfo(double salary, double districtCoeff, double prize, int workedDays, int spentDays)
        {
            this.salary = salary;
            this.districtCoeff = districtCoeff;
            this.prize = prize;
            this.workedDays = workedDays;
            this.spentDays = spentDays;
        }
    }
}
