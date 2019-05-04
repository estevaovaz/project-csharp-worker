using Exercicio_Worker.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Exercicio_Worker.Entities
{
    public class Worker 
    {
        public string Name { get; set; }
        public WorkLevel Level { get; set; }
        public Double BaseSalary { get; set; }
        public Department Department { get; set; }
        public List<HourContract> Contracts { get; private set; } = new List<HourContract>();

        public Worker(string name, WorkLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
            Contracts = new List<HourContract>();

        }

        public Worker()
        {

        }

        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }

        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public Double Income(int year, int month)
        {
            double sum = BaseSalary;
            foreach (HourContract contract in Contracts)
            {
                if (contract.Date.Year == year && contract.Date.Month == month)
                {
                    sum += contract.totalValue();
                    //BaseSalary = BaseSalary + contract.totalValue();
                }
            }
            return sum;
        }

        public override string ToString()
        {
            return "Name: "
                + Name
                + ", "
                + "Level: "
                + Level
                + ", "
                + "BaseSalary: "
                + BaseSalary.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
