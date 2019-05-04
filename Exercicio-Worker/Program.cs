using Exercicio_Worker.Entities;
using Exercicio_Worker.Entities.Enums;
using System;
using System.Globalization;

namespace Exercicio_Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 
            Console.Write("Enter department's name: ");
            string nameDept = Console.ReadLine();
            Console.WriteLine("Enter worker data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkLevel level = (WorkLevel)Enum.Parse(typeof(WorkLevel), Console.ReadLine());
            Console.Write("BaseSalary: ");
            Double baseSalary = Double.Parse(Console.ReadLine());

            Department dept = new Department(nameDept);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.WriteLine();

            Console.Write("How many contracts to this worker ?");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter #" + i + " contract data: ");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Value per hour: ");
                Double valuePerHour = Double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.WriteLine("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);
            }

            Console.WriteLine();
            Console.Write("Enter month and year to calculate income(MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));
            Console.WriteLine("Name : " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.NameDept);
            Console.WriteLine("Income for " + monthAndYear + ": "
                + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));
            #endregion
        }
    }
}
