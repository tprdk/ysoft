using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ysoft.src
{
	class Employee
	{

		private string name;
		private string surname;
		private int roleId;
		private int id;
		private int projectId;
		private int salaryId;
		private int salary;
		private int compensationPlan;
		private int compensationAmount;

		public Employee()
		{

		}
		public Employee(string name, string surname, int roleId, int salaryId)
		{
			this.name = name;
			this.surname = surname;
			this.roleId = roleId;
			this.salaryId = salaryId;
		}

		public string Name { get { return name; } set { name = value; } }

		public string Surname { get { return surname; } set { surname = value; } }

		public int RoleId { get { return roleId; } set { roleId = value; } }

		public int Id { get { return id; } set { id = value; } }

		public int ProjectId { get { return projectId; } set { projectId = value; } }

		public int Salary { get { return salary; } set { salary = value; } }

		public int SalaryId { get { return salaryId; } set { salaryId = value; } }

		public int CompensationPlan { get { return compensationPlan; } set { compensationPlan = value; } }

		public int CompensationAmount { get { return compensationAmount; } set { compensationAmount = value; } }

	}
}
