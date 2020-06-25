using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ysoft.src
{
	class Role
	{
		private int id;
		private string name;

		public Role()
		{

		}
		public Role(string name)
		{
			this.name = name;
		}

		public Role(int id, string name)
		{
			this.id = id;
			this.name = name;
		}

		public string Name { get { return name; } set { name = value; } }

		public int Id { get { return id; } set { id = value; } }

	}
}
