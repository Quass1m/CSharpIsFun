using System;

namespace CSharpIsFun.Features
{
    /// <summary>
    /// Example of C# Currying
    /// </summary>
    /// <see cref="https://devstyle.pl/2018/04/30/jak-i-po-co-pisac-funkcyjnie-w-c-sharp/"/>
    /// <see cref="https://devstyle.pl/2018/06/14/funkcyjna-kompozycja-w-c-sharp/"/>
    public static class Currying
    {
        public static Func<Employee, double> CalculateTax(Func<Employee, double> getTaxRate) =>
                employee => employee.Salary * getTaxRate(employee);

        public static Func<Employee, double> GetTaxRateCalculationMethod(Employee employee)
        {
            if (employee.IsSelfEmployed)
            {
                return GetLinearTaxRate;
            }
            else
            {
                return GetProgressiveTaxRate;
            }

            double GetLinearTaxRate(Employee _) => 0.19;

            double GetProgressiveTaxRate(Employee e) => e.Salary > 32000 ? 0.32 : 0.19;
        }

        public static double GetTaxForEmployee(Employee employee)
            => CalculateTax(GetTaxRateCalculationMethod(employee))(employee);
    }

    public class Employee
    {
        public long Id { get; set; }
        public double Salary { get; set; }
        public bool IsSelfEmployed { get; set; }
    }
}