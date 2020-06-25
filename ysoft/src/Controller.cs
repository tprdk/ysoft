using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ysoft.src
{
    class Controller
    {
        public static readonly string admin = "yönetici";

        public static bool isValid(string str, string mustBe)
        {
            if (mustBe.Equals(MainWindow.stringValid))
            {
                return str.All(c => (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'));
            }
            else
            {
                return str.All(c => (c >= '0' && c <= '9'));
            }
        }

        public static bool checkAllSpaces(string str)
        {
            return !(str.Equals("")) && str.All(c => c != ' ');
        }

        public static int setSalaryOfEmployee(int id)
        {
            List<SalaryPlan> salaryPlans = Database.getSalaryPlans();
            foreach (SalaryPlan salary in salaryPlans)
            {
                if(salary.Id == id)
                {
                    return salary.Amount;
                }
            }
            return 0;
        }
        
        public static int addEmployeeToProject(Employee emp)
        {
            List<Project> projects = Database.getProject();              //Bütün projeler databaseden çekilir
            List<Role> roles = Database.getRole();
            
            if (roles[emp.RoleId - 1].Name.Equals(admin))                // admin ekleme durumu
            {
                foreach (Project project in projects)
                {
                    if (!project.containsAdmin(roles))
                    {
                        project.addToProject(emp);                       //Boş olan projeye çalışan eklenir
                        return project.Id;
                    }
                }
                return -1;
            }
            else
            {
                foreach (Project project in projects)
                {
                    if (!project.hasEnoughEmployee())
                    {
                        project.addToProject(emp);                       //Minimumu dolmamış olan projeye kişi eklenir
                        return project.Id;                               //eklenen projenin id si maine döndürülür
                    }
                }
                foreach (Project project in projects)
                {
                    if (!project.isFull())
                    {
                        project.addToProject(emp);                       //Boş olan projeye çalışan eklenir
                        return project.Id;                               //eklenen projenin id si maine döndürülür
                    }
                }
                return -1;                                      //-1 döndürülmesi durumu uygun projenin bulunmaması durumudur.
            }                                       
        }
        
        public static bool isUserExist(string username, string password)
        {
            List<User> users = Database.getUser();
            foreach (User user in users)
            {
                if (user.Username.Equals(username) && user.Password.Equals(password))
                {
                    return true;
                }
            }
            return false;
        }

        public static List<Employee> fillProjectEmployees(int id)
        {
            return Database.getProjectEmployees(id);
        }

        public static List<SalaryPlan> getSalaryList()
        {
            return Database.getSalaryPlans();
        }

        public static List<Role> getRoleList()
        {
            return Database.getRole();
        }

        public static bool saveEmployeeToDb(Employee employee)
        {
            return Database.createEmployee(employee);
        }

        public static bool saveProjectToDb(Project project)
        {
            return Database.saveProject(project);
        }
    }
}
