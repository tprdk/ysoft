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

namespace ysoft
{
    /// <summary>
    /// Menu.xaml etkileşim mantığı
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void addEmployeeBttn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            AddEmployeeWindow addEmpWin = new AddEmployeeWindow();
            addEmpWin.Show();
        }

        private void addProjectBttn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            AddProjects addProjects = new AddProjects();
            addProjects.Show();
        }

        private void showEmployeeBttn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            showEmployees showEmp = new showEmployees();
            showEmp.Show();
        }

        private void showProjectBttn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ShowProjects showPr = new ShowProjects();
            showPr.Show();
        }

        private void finishProjectBttn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void backBttn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mw = new MainWindow();
            mw.Show();
        }
    }
}
