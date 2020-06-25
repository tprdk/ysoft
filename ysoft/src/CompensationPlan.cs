using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ysoft.src
{
	class CompensationPlan
	{
		private int id;
		private string name;
		private int amount;

		public CompensationPlan(string name, int amount)
		{
			this.amount = amount;
			this.name = name;
		}

		public int Id { get; set; }

		public string Name { get; set; }

		public int Amount { get; set; }

		public static int calculateAmount()         // Bir internet servisinden bu değer geliyor	
		{
			return 20000;
		}
	}
}
