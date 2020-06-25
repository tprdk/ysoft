using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ysoft.src;

namespace ysoft
{
    /// <summary>
    /// AddEmployeeWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        public static readonly string stringValid = "string";
        public static readonly string intValid = "int";

        string name, surname;
        int roleId, salaryId, projectId;

        private void backBttn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Menu menu = new Menu();
            menu.Show();
        }

        public AddEmployeeWindow()
        {
            InitializeComponent();
            initComboBoxes();
        }

        private void initComboBoxes()
        {
            List<string> roleNames = new List<string>();
            List<Role> roleList = Controller.getRoleList();
            foreach (Role role in roleList)
            {
                roleNames.Add(role.Name);
            }
            cmb_role.ItemsSource = roleNames;


            List<string> salaryNames = new List<string>();
            List<SalaryPlan> salaryList = Controller.getSalaryList();

            foreach (SalaryPlan salary in salaryList)
            {
                salaryNames.Add(salary.Name);
            }
            cmb_salary.ItemsSource = salaryNames;
        }
        private void salary_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(cmb_salary.SelectedIndex.ToString());
            salaryId = cmb_salary.SelectedIndex + 1;
        }

        private void role_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(cmb_role.SelectedIndex.ToString());
            roleId = cmb_role.SelectedIndex + 1;                               // combo box items 0,1,2 olarak 
        }                                                                       // roller 1,2,3 gibi hesaplandı

        private void saveBttn_Click(object sender, RoutedEventArgs e)
        {
            if (controlFields())
            {
                if (createEmployee())
                {
                    List<Project> pr = Database.getProject();
                    MessageBox.Show("Employee is created successfully. \n" +
                        "Employee added to "+ pr[projectId - 1].Name, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Employee could not be created.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private bool createEmployee()
        {
            Employee employee = new Employee(name, surname, roleId, salaryId);
            employee.Salary = Controller.setSalaryOfEmployee(employee.SalaryId);
            projectId = Controller.addEmployeeToProject(employee);

            if(projectId != -1)
            {
                employee.ProjectId = projectId;
                return Controller.saveEmployeeToDb(employee);
            }
            else
            {
                MessageBox.Show("There is no available project.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        private bool controlFields()
        {
            name = name_text.Text.Trim();
            surname = surname_text.Text.Trim();
            Console.WriteLine(name);
            Console.WriteLine(surname);
            if (Controller.checkAllSpaces(name) && Controller.checkAllSpaces(surname))
            {
                if (Controller.isValid(name, stringValid) && Controller.isValid(surname, stringValid))
                {
                    Console.WriteLine("valid");
                    return true;
                }
                else
                {
                    if (Controller.isValid(name, stringValid))
                    {
                        MessageBox.Show("Surname field only allows letters.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Name field only allows letters.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    // valid değil
                    return false;
                }
            }
            else
            {
                MessageBox.Show("All fields have to be filled.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
        }
    }
}
