using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ysoft.src
{
    class Database
    {
        //private List<Project> project;
        private static List<Employee> employees;
        private static List<Project> projects;
        private static List<User> users;
        private static List<Role> roles;
        private static List<SalaryPlan> salaryPlans;
        private static Employee employee;
        private static Project project;
        private static Role role;
        private static SalaryPlan salaryPlan;

        public static bool saveProject(Project project)         // name, max , min
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database2.mdb");
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("insert into project(pname,pstart,pend,minemp,maxemp) values('" + project.Name + "','" + project.Begin + "','" + project.End + "','" + project.MinEmp + "','" + project.MaxEmp + "')", baglanti);
            try
            {
                komut.ExecuteNonQuery();
            }
            catch (OleDbException exp)
            {
                Console.WriteLine(exp.StackTrace);
                Console.WriteLine("Exception hatası");
                return false;
            }
            baglanti.Close();
            return true;
        }
        public static List<Project> getProject()
        {
            projects = new List<Project>();
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database2.mdb");
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("Select * from project");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                // id, name,begin, end,  minEmp, maxEmp
                Project pr = new Project(Convert.ToInt32(oku[0]), 
                                         oku[1].ToString(),oku[2].ToString(),
                                         oku[3].ToString(), Convert.ToInt32(oku[4]),
                                         Convert.ToInt32(oku[5]));
                projects.Add(pr);
            }
            baglanti.Close();
            return projects;
        }

        public static List<Role> getRole()
        {
            roles = new List<Role>();
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database2.mdb");
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("Select * from role");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                Role rl = new Role();
                rl.Id = Convert.ToInt32(oku[0]);
                rl.Name = oku[1].ToString();
                roles.Add(rl);
            }
            baglanti.Close();
            return roles;
        }
        public static List<Employee> getProjectEmployees(int projectid)         // name, max , min
        {
            employees = new List<Employee>();
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database2.mdb");
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("Select * from employee where pnumber=(" + projectid + ")");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                Employee emp = new Employee();
                emp.Id = Convert.ToInt32(oku[0]);               //id geliyor
                emp.Name = oku[1].ToString();            
                emp.Surname = oku[2].ToString();
                emp.RoleId = Convert.ToInt32(oku[3]);
                emp.SalaryId = Convert.ToInt32(oku[4]);
                emp.Salary = Convert.ToInt32(oku[5]);
                emp.ProjectId = Convert.ToInt32(oku[6]);
                employees.Add(emp);
            }
            baglanti.Close();
            return employees;
        }

        public static List<Employee> getEmployee()
        {
            employees = new List<Employee>();
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database2.mdb");
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("Select * from employee");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                Employee emp = new Employee();
                emp.Id = Convert.ToInt32(oku[0]);              
                emp.Name = oku[1].ToString();
                emp.Surname = oku[2].ToString();
                emp.RoleId = Convert.ToInt32(oku[3]);
                emp.SalaryId = Convert.ToInt32(oku[4]);
                emp.Salary = Convert.ToInt32(oku[5]);
                emp.ProjectId = Convert.ToInt32(oku[6]);
                employees.Add(emp);
            }
            baglanti.Close();
            return employees;
        }

        public static bool createEmployee(Employee emp)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database2.mdb");
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("insert into employee(fname,lname,role_id,salary_plan,salary,pnumber) values('" + emp.Name + "','" + emp.Surname + "'," + emp.RoleId + "," + emp.SalaryId + ",'" + emp.Salary + "'," + emp.ProjectId + ")", baglanti);
            try
            {
                komut.ExecuteNonQuery();
            }
            catch (OleDbException exp)
            {
                Console.WriteLine(exp.StackTrace);
                Console.WriteLine("Exception hatası");
            }
            baglanti.Close();
            return true;
        }

        public static List<User> getUser()
        {
            users = new List<User>();
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database2.mdb");
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("Select * from ik");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                User user = new User();
                user.Username = oku[0].ToString();
                user.Password = oku[1].ToString();
                users.Add(user);
            }
            baglanti.Close();
            return users;
        }

        public static List<SalaryPlan> getSalaryPlans()
        {
            salaryPlans = new List<SalaryPlan>();
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database2.mdb");
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("Select * from salaryPlan ");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                SalaryPlan salaryPlan = new SalaryPlan();
                salaryPlan.Id = Convert.ToInt32(oku[0]);
                salaryPlan.Name = oku[1].ToString();
                salaryPlan.Amount = Convert.ToInt32(oku[2]);
                salaryPlans.Add(salaryPlan);
            }
            baglanti.Close();
            return salaryPlans;
        }

    }
}