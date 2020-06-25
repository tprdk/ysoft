using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ysoft.src
{
    class Project
    {

        private string name;
        private int id;
        private int maxEmp;
        private int minEmp;
        private string begin;
        private string end;
        private List<Employee> employees;

        public Project()
        {

        }
        public Project(int id, string name, string begin, string end, int minEmp, int maxEmp)
        {
            this.id = id;
            this.name = name;
            this.maxEmp = maxEmp;
            this.minEmp = minEmp;
            this.begin = begin;
            this.end = end;
            this.employees = new List<Employee>();
            this.fillEmployees();
        }
        public Project(string name, int maxEmp, int minEmp, string begin, string end)
        {
            this.name = name;
            this.maxEmp = maxEmp;
            this.minEmp = minEmp;
            this.begin = begin;
            this.end = end;
            this.employees = new List<Employee>();
        }

        public string Name { get { return name; } set { name = value; } }

        public int Id { get { return id; } set { id = value; } }

        public int MaxEmp { get { return maxEmp; } set { maxEmp = value; } }

        public int MinEmp { get { return minEmp; } set { minEmp = value; } }

        public string Begin { get { return begin; } set { begin = value; } }

        public string End { get { return end; } set { end = value; } }

        public List<Employee> getEmployees()
        {
            return employees;
        }

        public bool isFull()
        {
            return (this.employees.Count == this.MaxEmp) ;
        }

        public bool containsAdmin(List<Role> roles)
        {
            foreach (Employee employee in this.getEmployees())
            {
                if (roles[employee.RoleId - 1].Name.Equals(Controller.admin))
                {
                    return true;
                }
            }
            return false;
        }

        public bool hasEnoughEmployee()
        {
            return this.employees.Count >= this.minEmp ;
        }

        public void addToProject(Employee employee)
        {
            this.employees.Add(employee);
        }

        public void fillEmployees()
        {
            this.employees = Controller.fillProjectEmployees(this.Id);
        }
    }
}
