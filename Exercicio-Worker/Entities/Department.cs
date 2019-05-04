using System;

namespace Exercicio_Worker.Entities
{
    public class Department 
    {
        private string name1;

        public String NameDept { get; set; }

        public Department(string nameDept) 
        {
            NameDept = nameDept;
        }

        public Department()
        {

        }

        public override string ToString()
        {
            return "Name: " + NameDept;
        }


    }

   
    
}
