using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ysoft.src
{
	class SalaryPlan
	{
		private string name;
		private int id;
		private int amount;

		public SalaryPlan()
		{

		}

		public SalaryPlan(string name)
		{
			this.name = name;
		}

		public SalaryPlan(string name, int amount)
		{
			this.name = name;
			this.amount = amount;
		}

		public int Amount { get { return amount; } set { amount = value; } }

		public int Id { get { return id; } set { id = value; } }

		public string Name { get { return name; } set { name = value; } }

		int calculateSalary()
		{
			return this.Amount;
		}
	}
}
