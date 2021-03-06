﻿using System;
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
    /// showEmployees.xaml etkileşim mantığı
    /// </summary>
    public partial class showEmployees : Window
    {
        private List<Employee> employeeList;
        public showEmployees()
        {
            InitializeComponent();
            employeeList = Database.getEmployee();
            this.dataGrid.ItemsSource = employeeList;
        }

        private void backBttn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Menu menu = new Menu();
            menu.Show();
        }
    }
}
