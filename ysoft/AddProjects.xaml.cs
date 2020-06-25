using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// AddProjects.xaml etkileşim mantığı
    /// </summary>
    public partial class AddProjects : Window
    {
        public static readonly string stringValid = "string";
        public static readonly string intValid = "int";

        string projectName, minEmp_str, maxEmp_str, endTime, beginTime;
        int minEmp, maxEmp;

        public AddProjects()
        {
            InitializeComponent();
        }

        private void backBttn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Menu menu = new Menu();
            menu.Show();
        }

        private void saveProjectBttn_Click(object sender, RoutedEventArgs e)        
        {
            if (controlFields())
            {
                if (createProject())
                {
                    MessageBox.Show("Project is created successfully.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Project could not be created.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private bool controlFields()
        {
            projectName = project_name_text.Text.Trim();
            minEmp_str = min_emp_text.Text.Trim();
            maxEmp_str = max_emp_text.Text.Trim();

            beginTime = DateTime.Today.ToShortDateString();
            try
            {
                endTime = date.SelectedDate.Value.Date.ToShortDateString();
            }
            catch (Exception e)
            {
                MessageBox.Show("Please pick an end date.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            Console.WriteLine(beginTime);
            Console.WriteLine(endTime);

            if (Controller.checkAllSpaces(projectName) && 
                Controller.checkAllSpaces(minEmp_str) && Controller.checkAllSpaces(maxEmp_str))
            {
                if (Controller.isValid(minEmp_str, intValid) && Controller.isValid(minEmp_str, intValid))
                {
                    Console.WriteLine("valid");
                    minEmp = int.Parse(minEmp_str);
                    maxEmp = int.Parse(maxEmp_str);
                    return true;
                }
                else
                {
                    if (Controller.isValid(minEmp_str, intValid))
                    {
                        MessageBox.Show("Maximum Employee field only allows numbers.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    { 
                        MessageBox.Show("Minimum Employee field only allows numbers.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    return false;
                }
            }
            else
            {
                MessageBox.Show("All fields have to be filled.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
        }
        private bool createProject()
        {
            Project project = new Project(projectName, maxEmp, minEmp, beginTime, endTime);
            return Controller.saveProjectToDb(project);
        }
    }
}
